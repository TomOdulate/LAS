using System.Collections.Generic;

namespace Tao.LAS.Utils
{
    public class PageDataMgr
    {
        public List<PageData> PageData = new List<PageData>();

        public void AddPageData(string pageId, string rawData)
        {
            // convert the pageId to short.
            short id;
            if (!short.TryParse(pageId, out id))
                return;  // TODO: probably need to react to this error.

            PageData.Add(new PageData { ContentRaw = rawData, PageID = id });
        }

    }
}