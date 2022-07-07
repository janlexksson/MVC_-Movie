using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC__Movie.Data;
using MVC__Movie.Models;

namespace MVC__Movie.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext Context;
        public MoviesController(ApplicationDbContext c)
        {
            Context = c;
        }

        [Authorize(Roles = "admin")]

        public IActionResult Index()

        {
            var MovieList = Context.Movies.Include(x => x.Customer).ToList();
            return View(MovieList);
        }
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(Context.Customers, "Id", "Name");
            ; return View();
        }
        [HttpPost]
        //public IActionResult Create(string title, string genre, string picurl, *int Customerid*/)
        public IActionResult Create(string title, string genre, string picurl, int customerid)
        {
            Movie Movie = new Movie();
            Movie.Title = title;
            Movie.Genre = genre;
            Movie.PicUrl = picurl;
            //Movie.CustomerId = Customerid;

            Movie.CustomerId = customerid;
            Context.Movies.Add(Movie);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int? id)
        { //Testar

            Movie Movie = Context.Movies.Include(x => x.Customer).FirstOrDefault(x => x.Id == id);  //Original
            Movie = Context.Movies.SingleOrDefault(x => x.Id == id);  //Original
            


            return View(Movie);
        }
        public IActionResult Edit(int? id)
        {
            ViewData["CustomerId"] = new SelectList(Context.Customers, "Id", "Name");
            Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == id);
            return View(Movie);
        }
        [HttpPost]
        public IActionResult Edit(int id, string title, string genre, int customerid)
        {
            Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == id);
            Movie.Id = id;
            Movie.Title = title;
            Movie.Genre = genre;
            Movie.CustomerId = customerid;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == id);
            return View(Movie);
        }
        [HttpPost]
        public IActionResult DeleteYes(int? id)
        {
            Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == id);
            Context.Remove(Movie);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Rent(int? id)
        {

            //Movie Movie = Context.Movies.Include(x => x.Customer).FirstOrDefault(x => x.Id == id);
            var Movie = Context.Movies.Include(x => x.Customer).FirstOrDefault(x => x.Id == id);
            return View(Movie);



        }
       
    }
}
