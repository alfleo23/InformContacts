using InformContacts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InformContacts.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _dbContext;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(MyDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            // retrieve all contacts from database and pass them in Index View as a model
            var contactsList = _dbContext.Contacts.OrderBy(x => x.LastName).ToList();
            return View(contactsList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Action to display the view to add a contact
        public IActionResult AddContact()
        {
            return View();
        }

        // Action to save the contact passed from the view into database
        [HttpPost]
        public IActionResult AddContact(Contact c)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Contacts.Add(c);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}