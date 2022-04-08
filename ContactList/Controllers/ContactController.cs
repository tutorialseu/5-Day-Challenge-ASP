using ContactList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{
    public class ContactController : Controller
    {
        private static int uniqueId = 0;

        readonly static List<Contact> contacts = new List<Contact>()
        {
            new Contact()
            {
                Id = uniqueId++,
                Name = "Marc",
                PhoneNumber = "02734838374",
                Email = "marc@m-dev.com",
                Website = "https://marc-m-dev.com"
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(model: contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact newContact)
        {
            newContact.Id = uniqueId++;
            contacts.Add(newContact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int contactId)
        {
            var contact = contacts.SingleOrDefault(contact => contact.Id == contactId);

            return View(model: contact);
        }

        [HttpPost]
        public IActionResult Delete(int contactId)
        {
            var contact = contacts.SingleOrDefault(contact => contact.Id == contactId);

            contacts.Remove(contact);

            return RedirectToAction("Index");
        }
    }
}
