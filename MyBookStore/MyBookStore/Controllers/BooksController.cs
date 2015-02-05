using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using MyBookStore.Models;
using MyBookStore.DataModel;
namespace MyBookStore.Controllers
{
    public class BooksController : Controller
    {
        #region public static members

        public static string Key = "08964e27966e4ca99eb0029ac4c4c217";
        public static string Isbn = "9788741201122";

        #endregion

        #region methods

        //
        // Get Method
        [HttpGet]
        public ActionResult GetBookByIsbn()
        {
            return View();

        }

        /// <summary>
        /// Method GetBookBYISBN
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetBookByIsbn(string jsonString)
        {
            var retval = JsonConvert.DeserializeObject<List<BookisbnModel>>(jsonString);
            var context = new MyBookStoreEntities();
            var model = new List<Book>();
            foreach (var id in retval)
            {
                //first check if reocrds in database then return from database 
                var result = context.Books.FirstOrDefault(x => x.ISBN == id.ISBN);
                if (result != null)
                {
                    var get = new Book();
                    get.ISBN = result.ISBN;
                    get.ImageUrl = result.ImageUrl;
                    get.Checked = result.Checked;
                    get.BookId = result.BookId;
                    get.ReleaseDate = result.ReleaseDate;
                    get.Titlte = result.Titlte;
                    model.Add(get);
                }
                else
                {
                    var client = new HttpClient();
                    var url = "http://api.saxo.com/v1/products/products.json?key=08964e27966e4ca99eb0029ac4c4c217&isbn=" + id.ISBN;

                    client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

                    var response = client.GetAsync(url).Result;
                    // var resultContent = response.Content.ReadAsStringAsync().Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        var responseMessage = "Response status code does not indicate success: " + (int)response.StatusCode + " (" + response.StatusCode + " )";
                        //log error
                        return null;
                    }
                    var responseBody = response.Content.ReadAsStreamAsync().Result;
                    var sr = new StreamReader(responseBody);
                    var mystr = sr.ReadToEnd();
                    dynamic m = JsonConvert.DeserializeObject(mystr);
                    var books = m.products;
                    // for each books that is coming from api
                    foreach (var book in books)
                    {
                        //to save the bokks record in database
                        var newBook = new Book();
                        newBook.ISBN = id.ISBN;
                        newBook.BookId = Convert.ToString(book["id"]);
                        newBook.Titlte = Convert.ToString(book["title"]);
                        newBook.ImageUrl = Convert.ToString(book["imageurl"]);
                        newBook.ReleaseDate = book["releasedate"];
                        //newBook.Publisher = models.Publisher;
                        newBook.Checked = false;
                        newBook.DateCreated = DateTime.Now;
                        newBook.IsDeleted = false;
                        context.Books.Add(newBook);
                        context.SaveChanges();

                        //add books to outer model to merge books records
                        model.Add(newBook);
                    }
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// this method save the checked status in database on checkbox click
        /// </summary>
        /// <param name="id"></param>
        /// <param name="checkStatus"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveChecked(string id, string checkStatus)
        {
            var context = new MyBookStoreEntities();
            Book book = context.Books.FirstOrDefault(x => x.ISBN == id);
            if (book != null) book.Checked = Convert.ToBoolean(checkStatus);
            context.SaveChanges();
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
