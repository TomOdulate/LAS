using System;

namespace Tao.LAS.Utils
{
    public class DataLine
    {
        public short PageID { get; set; }
        public string ContentRaw { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public string Target { get; set; }
        public string TargetLink { get; set; }

        public string Age()
        {
            var start = ContentRaw.IndexOf("*", StringComparison.OrdinalIgnoreCase) + 1;
            var end = ContentRaw.IndexOf(" - <A ", StringComparison.OrdinalIgnoreCase);
            return ContentRaw.Substring(start, end - start).Trim();
        }
    }
}