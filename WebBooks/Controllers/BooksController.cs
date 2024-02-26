using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBooks.Models;
using apiBOOKS;
using System.Net.Http.Headers;
using System.IO;
using System;
using System.Security.Cryptography.Xml;
using apiBOOKS;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Azure;
using System.Net;
using System.Text;

namespace WebBooks.Controllers
{
    public class BooksController : Controller
    {


        public IActionResult Index()
        {
            WebBooks.Models.ListBooks books = new WebBooks.Models.ListBooks();
            // HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:7192/book");


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7192/book");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {

                var contents = response.Content.ReadAsStringAsync().Result;
                List<apiBOOKS.Models.Book> x = JsonConvert.DeserializeObject<List<apiBOOKS.Models.Book>>(contents);


                books = new WebBooks.Models.ListBooks();
                books.Books = x;


            }





            return View(books);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            apiBOOKS.Models.Book mybook = new apiBOOKS.Models.Book();



            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7192/book/bookid?id=" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {

                var contents = response.Content.ReadAsStringAsync().Result;
                List<apiBOOKS.Models.Book> x = JsonConvert.DeserializeObject<List<apiBOOKS.Models.Book>>(contents);


                mybook = x.First();


            }



            return View(mybook);
        }

        [HttpPost]
        public IActionResult Edit(apiBOOKS.Models.Book _book)
        {
            //string json = JsonConvert.SerializeObject(_book);

            //using (WebClient client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //    var response = client.UploadString("https://localhost:7192/book/Edit", json);
            //}

            string json = JsonConvert.SerializeObject(_book);

             

            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = client.UploadString("https://localhost:7192/book/Edit", json);
            }




            //if (response.IsSuccessStatusCode  )
            //{
            //    return View("Index");
            //}
            //else
            //{
                return View("Edit");
            //}

         

        }

        [HttpGet]
        public IActionResult Insert()
        {
            apiBOOKS.Models.Book mybook = new apiBOOKS.Models.Book();




            return View(mybook);
        }

        [HttpPost]
        public IActionResult Insert(apiBOOKS.Models.Book _book)
        {
            //string json = JsonConvert.SerializeObject(_book);

            //using (WebClient client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //    var response = client.UploadString("https://localhost:7192/book/Edit", json);
            //}

            string json = JsonConvert.SerializeObject(_book);



            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = client.UploadString("https://localhost:7192/book/Edit", json);
            }




            //if (response.IsSuccessStatusCode  )
            //{
            //    return View("Index");
            //}
            //else
            //{
            return View("Edit");
            //}



        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            apiBOOKS.Models.Book mybook = new apiBOOKS.Models.Book();



            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7192/book/bookid?id=" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {

                var contents = response.Content.ReadAsStringAsync().Result;
                List<apiBOOKS.Models.Book> x = JsonConvert.DeserializeObject<List<apiBOOKS.Models.Book>>(contents);


                mybook = x.First();


            }



            return View(mybook);
        }



    }
}