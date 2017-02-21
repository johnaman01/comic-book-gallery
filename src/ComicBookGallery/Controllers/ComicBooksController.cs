using ComicBookGallery.Data;
using ComicBookGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookGallery.Controllers
{
    public class ComicBooksController : Controller
    {
        //1. add a private field for the repository so that the controller can use it!!!
        //via using ComicBookGallery.Data (Line 1), in which our ComicBookRepository class resides 
        private ComicBookRepository _comicBookRepository = null;
        //2. we need an instance of our repository; use constructor...
        //constructors are special methods that are called when an instance of our class is being instantiated
        //we use constructors to initialize instance members...see code block below
        public ComicBooksController()
        {
            _comicBookRepository = new ComicBookRepository();
           
        }

        //int? below is nullable type
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //id.Value below used to get at underlying value when using nullable type
            var comicBook = _comicBookRepository.GetComicBook(id.Value);
                

            return View(comicBook);         
        }
    }
}