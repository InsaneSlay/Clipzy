using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static Clipzy.Storage;
namespace Clipzy
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e) { new Save_As(textEdit1.Text.Split('/').Last()).Show(); textEdit1.Text = ""; }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    textEdit2.Text = fbd.SelectedPath;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textEdit2.Text))
                Properties.Settings.Default.outputDir = textEdit2.Text + "//";
            else
                Properties.Settings.Default.outputDir = "";

            Properties.Settings.Default.Save();
            XtraMessageBox.Show("Output Saved", "Clipzy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e) => Process.Start("http://www.twitter.com/OTSlay");
        private void hyperlinkLabelControl2_Click(object sender, EventArgs e) => Process.Start("http://www.instagram.com/OTSlayer");
    }
}
