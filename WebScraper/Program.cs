using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using CsvHelper;

namespace scraper
{
    class WebScraper
    {

        static void Main(string[] args)
        {
            string url = "https://books.toscrape.com/catalogue/category/books/food-and-drink_33/index.html";
            var links = GetBookLinks(url);
            List<Book> books = GetBooks(links);
            Export(books);
        }

        private static void Export(List<Book> books)
        {
            using (var writer = new StreamWriter("./books.csv"))
            using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(books);
            }
        }

        //Retrieve book information and input
        static List<Book> GetBooks(List<string> links)
        {
            var books = new List<Book>();
            foreach(var link in links)
            {
                var doc = GetDocument(link);
                var book = new Book();
                book.Title = doc.DocumentNode.SelectSingleNode("//h1").InnerText;
                var xpath = "//*[@class=\"col-sm-6 product_main\"]/*[@class=\"price_color\"]";
                book.Price = doc.DocumentNode.SelectSingleNode(xpath).InnerText;
                xpath = "//*[@class=\"instock availability\"]";
                book.Avl = doc.DocumentNode.SelectSingleNode(xpath).InnerText.Trim();
                books.Add(book);
            }
            return books;
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
                link = new Uri(baseUri, link).AbsoluteUri;
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