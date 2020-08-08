using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipzy.Json
{
    public class VideoQuality
    {
        public string __typename { get; set; }
        public int frameRate { get; set; }
        public string quality { get; set; }
        public string sourceURL { get; set; }
    }

    public class Clip
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public IList<VideoQuality> videoQualities { get; set; }
    }
    public class Data
    {
        public Clip clip { get; set; }
    }

    public class Extensions
    {
        public int durationMilliseconds { get; set; }
        public string operationName { get; set; }
        public string requestID { get; set; }
    }
    public class ClipJsonObj
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
    }
}
