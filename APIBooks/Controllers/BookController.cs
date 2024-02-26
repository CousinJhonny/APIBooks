using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
 

namespace apiBOOKS.Controllers
{


    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetBooks()
        {
            using (Models.TestContext db = new Models.TestContext())
            {
                var list = (from d in db.Books
                            select d).ToList();

                return Ok(list);
            }

            // return "";
        }

        [Route("bookid")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetBookById(int Id)
        {
            using (Models.TestContext db = new Models.TestContext())
            {
                var list = (from d in db.Books 
                            where d.Id.Equals(Id) 
                            select d
                            
                            ).ToList();

                return Ok(list);
            }

            // return "";
        }



        [HttpPost]
        public ActionResult<IEnumerable<string>> InsertBook(Models.Book _model )
        {
            using (Models.TestContext db = new Models.TestContext())
            {
                Models.Book oBook = new Models.Book();
                oBook.Author = _model.Author;
                oBook.Name = _model.Name;
                oBook.Picture = _model.Picture;
                oBook.Genre = _model.Genre;

                db.Books.Add(oBook);
                db.SaveChanges();
                               
            }

            return Ok();    
        }

        [Route("Edit")]
        [HttpPut]
        public ActionResult<IEnumerable<string>> UpdateBook([FromBody] Models.Book _model)
        {
            using (Models.TestContext db = new Models.TestContext())
            {
                Models.Book oBook = db.Books.Find(_model.Id);
               
                oBook.Author = _model.Author;
                oBook.Name = _model.Name;
                oBook.Picture = _model.Picture;
                oBook.Genre = _model.Genre;

                db.Entry(oBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }

            return Ok();
        }


        [HttpDelete]
        public ActionResult<IEnumerable<string>> DeleteBook(Models.Book _model )
        {
            using (Models.TestContext db = new Models.TestContext())
            {
                Models.Book oBook = db.Books.Find(_model.Id);



                db.Books.Remove(oBook);
                db.SaveChanges();

            }

            return Ok();
        }


    }
}
