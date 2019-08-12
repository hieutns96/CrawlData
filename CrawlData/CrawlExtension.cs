using HtmlAgilityPack;
using System.Collections.Generic;

namespace CrawlData
{
    public static class CrawlExtension
    {
        public static ResponseData[] getContent(string url)
        {

            HtmlWeb web = new HtmlWeb();
            var responsesData = new List<ResponseData>();
            var htmlDoc = web.Load(url);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//ul/li/div/div[contains(@class, 'searchResult__373c0__2UyNw')]");
            foreach (var node in nodes)
            {
               
                var html = node.OuterHtml;
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                //get node data
                var name = doc.DocumentNode.SelectSingleNode("//h3/a");
                var rating = doc.DocumentNode.SelectSingleNode(
                    "//div/span/div[contains(@class, 'lemon--div__373c0__1mboc')]");
                var address = doc.DocumentNode.SelectSingleNode(
                    "//div[contains(@class,'lemon--div__373c0__1mboc container__373c0__19wDx u-padding-l2 border-color--default__373c0__2oFDT')]");
                var phone = doc.DocumentNode.SelectSingleNode(
                    "//div/div/p[contains(@class, 'lemon--p__373c0__3Qnnj')]");
                //parse data to object
                if (name != null)
                {
                    var responseData = new ResponseData();
                    responseData.Rating = rating.Attributes["aria-label"].Value;
                    responseData.Name = name.InnerHtml ;
                    responseData.Address = address.InnerText.Replace(phone.InnerHtml, "");
                    responseData.Phone = phone.InnerHtml;
                    responsesData.Add(responseData);
                }

            }
            return responsesData.ToArray();
        }
    }
}
