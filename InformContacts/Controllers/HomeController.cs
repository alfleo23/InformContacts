using InformContacts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InformContacts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _dbContext;

        public HomeController(MyDbContext context, ILogger<HomeController> logger)
        {
            _dbContext = context;
            _logger = logger;
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
                _logger.LogInformation((EventId) 3, "Contact {c.FirstName} {c.LastName} added", c.FirstName, c.LastName);
                return RedirectToAction("Index");
            }
            return View(c);
        }

        //Get the contact info to edit
        public IActionResult EditContact(int? id)
        {
            if (id == null || id == 0)
            {
                _logger.LogError((EventId) 1, "Contact not valid!!");
                return NotFound();
            }

            var contact = _dbContext.Contacts.Find(id);
            if (contact == null)
            {
                _logger.LogError((EventId) 2, "Contact not found!!");
                return NotFound();
            }

            return View(contact);
        }

        // Action to save the contact passed from the view into database
        [HttpPost]
        public IActionResult EditContact(Contact c)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Contacts.Update(c);
                _dbContext.SaveChanges();
                _logger.LogInformation((EventId) 4, "Contact {c.FirstName} {c.LastName} added", c.FirstName, c.LastName);
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