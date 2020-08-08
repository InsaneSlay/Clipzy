using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static Clipzy.Storage;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Clipzy
{
    public partial class Save_As : XtraForm
    {
        WebClient client = new WebClient();
        Stopwatch sw = new Stopwatch();
        public string clipid = "";
        public Save_As(string clipID)
        {
            InitializeComponent();
            clipid = clipID;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Save_As_Load(object sender, EventArgs e)
        {
            new Requests().PullClipData(clipid);
            textEdit1.Text = cj[0].data.clip.videoQualities[0].sourceURL.Split('/').Last().Split('.')[0];
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(cj[0].data.clip.videoQualities[0].sourceURL), $"{Properties.Settings.Default.outputDir}{textEdit1.Text}.mp4");
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Close();
        }
        private string updateSize(double bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
