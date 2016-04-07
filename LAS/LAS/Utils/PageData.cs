using System;
using System.Web;

namespace Tao.LAS.Utils
{
    public class PageData
    {
        public long PageID { get; set; }
        private string _contentRaw;
        private static string CleanPageData(string rawData)
        {
            var newString = string.Empty;

            // Lets remove any non-data lines.
            var splitLines = new[] { "\r\n" };
            string[] lines = rawData.Split(splitLines, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                var newLine = line.Trim();
                if (newLine.StartsWith("<DIV>*", StringComparison.OrdinalIgnoreCase))
                    newString += newLine;
                else
                    if (newLine.StartsWith("*", StringComparison.OrdinalIgnoreCase))
                        newString += "<DIV>" + newLine;
            }

            // Remove anything after the last "</DIV>"
            var end = newString.LastIndexOf("</DIV>", StringComparison.OrdinalIgnoreCase) + 6;
            newString = newString.Substring(0, end);

            return newString;
        }

        public string ContentRaw 
        { 
            get { return _contentRaw; }
            set { _contentRaw = CleanPageData(value); }
        }

        public string EncodeContentRaw()
        {
            return HttpUtility.HtmlEncode(_contentRaw);
        }

        public string[] Data()
        {
            var splitStrings = new[] { "<DIV>", "</DIV>", "<div>", "</div>" };
            return _contentRaw.Split(splitStrings, StringSplitOptions.RemoveEmptyEntries);    
        }

        //TODO: This method needs reworking.  I think LL has changed its site code.
        public string Age()
        {
            var start = _contentRaw.LastIndexOf("<DIV>*", StringComparison.OrdinalIgnoreCase) + 6;
            var end = _contentRaw.LastIndexOf(" - <A ", StringComparison.OrdinalIgnoreCase);
            return _contentRaw.Substring(start, end - start).Replace("less than a minute ago", "<1 min ago").Trim();
        }
    }
}