using System;
using HtmlAgilityPack;

class WebScraper
{

    static void Main(string[] args)
    {
        string url = "https://books.toscrape.com/catalogue/category/books/food-and-drink_33/index.html";

        var web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        Console.WriteLine(doc.DocumentNode.InnerHtml);

    }

}