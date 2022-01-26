using System;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace scraper
{
    class WebScraper
    {

        static void Main(string[] args)
        {
            string url = "https://books.toscrape.com/catalogue/category/books/food-and-drink_33/index.html";
            var links = GetBookLinks(url);

            Console.WriteLine(GetDocument(url).DocumentNode.InnerHtml);
        }

        //Retrieves all the books on the page
        static List<string> GetBookLinks(string url)
        {
            var doc = GetDocument(url);
            var linkNodes = doc.DocumentNode.SelectNodes("//h3/a");

            var baseUri = new Uri(url);
            var links = new List<string>();
            foreach (var node in linkNodes)
            {
                var link = node.Attributes["href"].Value;
                link = new Uri(baseUri, link).AbsolutePath;
                links.Add(link);
            }
            return links;
        }
        //Grabs the url page we want to parse through
        static HtmlDocument GetDocument(string url)
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            return doc;
        }
    }
}