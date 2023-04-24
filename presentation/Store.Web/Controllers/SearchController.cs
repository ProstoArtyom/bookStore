using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepository BookRepository;

        public SearchController(IBookRepository bookRepository)
        {
            this.BookRepository = bookRepository;
        }
        
        public IActionResult Index(string query)
        {
            var books = BookRepository.GetAllByTitle(query);
            
            return View(books);
        }
    }
}