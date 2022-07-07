using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC__Movie.Models;
using MVC__Movie.Data;
using Microsoft.EntityFrameworkCore;

namespace MVC__Movie.Controllers
{
    public class CustomersController : Controller  
    {
        ApplicationDbContext Context;
        public CustomersController(ApplicationDbContext c)
        {
            Context = c;
        }
        [Authorize(Roles = "admin")]      //From SQL Db

        public IActionResult Index()
        {
            var CustomerList = Context.Customers.ToList();
            return View(CustomerList);
        }
        [Authorize]                         //From SQL Db

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult Create(string name, string address, string telefonnumber)
        {
            Customer Customer = new Customer();
            Customer.Name = name;
            Customer.Address = address;
            Customer.TelefonNumber = telefonnumber;
            Context.Customers.Add(Customer);
            Context.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Customer Customer = Context.Customers.Include(x => x.Movies).FirstOrDefault(x => x.Id == id); 
            return View(Customer);
        }
        //Extra Viewmodel-------------nedan----------------!!!!!!!!!!!!!!!!
        private List<ViewModelAllDetails> movieperson = new List<ViewModelAllDetails>();

        public IActionResult AllDetails(int? id)
        //public IActionResult AllDetails()
        {

            ViewModelAllDetails vmAllDetails = new ViewModelAllDetails();
            //Customer Customer = new Customer();
            //Customer.Id = 10;
            //Customer.Name = "Peter Pan";
            //vmAllDetails.Customer = Customer;
            //Movie Movie = new Movie();
            //Movie.Id = 10;
            //Movie.Title = "Cooling";
            //Movie.Genre = "Humor";
            //vmAllDetails.Movie = Movie;
            //return View(vmAllDetails);

            //---------------------------------------------
            // or getting it from Database example -under. !!!!!!!!!!

            Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == id);
            vmAllDetails.Customer = Customer;
            Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == id);
            vmAllDetails.Movie = Movie;
            //Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == 1);
            //vmAllDetails.Customer = Customer;
            //Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == 1);
            //vmAllDetails.Movie = Movie;
            return View(vmAllDetails);
        }
        //nedan kopierat från MovieController fortsätt 29/6!!!!!!!!!!!!!!!!!!!
        public IActionResult Edit(int? id)
        {
            Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == id);
            return View(Customer);
        }
        [HttpPost]
        public IActionResult Edit(int id, string name, string address, string telefonnumber)
        {
            Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == id);
            Customer.Name = name;
            Customer.Address = address;
            Customer.TelefonNumber = telefonnumber;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == id);
            return View(Customer);
        }
        [HttpPost]
        public IActionResult DeleteYes(int? id)
        {
            Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == id);
            Context.Remove(Customer);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
