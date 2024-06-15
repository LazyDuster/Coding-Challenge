using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.DataAccess;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /* Upon hitting the submit button, all information filled in on the page gets 
         * POSTed and read. If it's empty or not a valid email, page redirects back.
         */
        [HttpPost]
        public ActionResult Submit()
        {
            Contact contact = new Contact();
            string errorMessage = "";
            bool faulty = false;
            if (string.IsNullOrEmpty(Request.Form["LastName"]))
            {
                errorMessage += "Last Name cannot be empty.";
                faulty = true;
            }
            if (string.IsNullOrEmpty(Request.Form["FirstName"]))
            {
                errorMessage += "First Name cannot be empty.";
                faulty = true;
            }
            if (!ContactsService.IsValidEmail(Request.Form["Email"]))
            {
                errorMessage += "Invalid email address.";
                faulty = true;
            }
            if (faulty)
            {
                ViewBag.errorMessage = errorMessage;
                return View("Index");
            }

            contact.lastName = Request.Form["LastName"];
            contact.firstName = Request.Form["FirstName"];
            contact.emailAddress = Request.Form["Email"];
            ContactsDataAccess.AddContact(contact);
            return View("Success");
        }

        /* GETs all entries of a mailing list under a given last name. Optional SortFlag
         * variable determines whether the list is in ascending or descending order.
         * (1 = Ascending, 0 = Descending)
         */
        [Route("api/contacts")]
        [HttpGet]
        public JsonResult Get(string lastName = null, int sortFlag = 1)
        {
            return Json(ContactsDataAccess.GetContacts(lastName, sortFlag));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
