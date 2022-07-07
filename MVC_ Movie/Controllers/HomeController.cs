using Microsoft.AspNetCore.Mvc;
using MVC__Movie.Models;
using System.Diagnostics;

namespace MVC__Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //public IActionResult Details(int id)
        //{
        //    Customer Customer = Context.Customers.Include(x => x.Movies).FirstOrDefault(x => x.Id == id);
        //    return View(Customer);
        //}
        //Extra Viewmodel-------------nedan----------------!!!!!!!!!!!!!!!!
        private List<ViewModelAllDetails> vmAllDetails = new List<ViewModelAllDetails>();

        public IActionResult AllDetails(int? id = null)
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

            //Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == id);
            //vmAllDetails.Customer = Customer;
            //Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == id);
            //vmAllDetails.Movie = Movie;
            //Customer Customer = Context.Customers.FirstOrDefault(x => x.Id == 1);
            //vmAllDetails.Customer = Customer;
            //Movie Movie = Context.Movies.FirstOrDefault(x => x.Id == 1);
            //vmAllDetails.Movie = Movie;
            return View(vmAllDetails);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}