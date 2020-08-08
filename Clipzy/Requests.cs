using Clipzy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Clipzy.Storage;
namespace Clipzy
{
    public class Requests
    {
        public void PullClipData(string clipId)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://gql.twitch.tv/gql");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Client-Id", "kimne78kx3ncx6brgo4mv6wki5h1ko");

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                streamWriter.Write("[{\"operationName\":\"VideoAccessToken_Clip\",\"variables\":{\"slug\":\"" + clipId + "\"},\"extensions\":{\"persistedQuery\":{\"version\":1,\"sha256Hash\":\"9bfcc0177bffc730bd5a5a89005869d2773480cf1738c592143b5173634b7d15\"}}}]");

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                cj = JsonConvert.DeserializeObject<ClipJsonObj[]>(streamReader.ReadToEnd());
        }
    }
}
