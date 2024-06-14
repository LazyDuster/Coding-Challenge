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
            if (string.IsNullOrEmpty(Request.Form["LastName"]))
            {
                return this.RedirectToAction("Index");
            }
            contact.lastName = Request.Form["LastName"];
            if (string.IsNullOrEmpty(Request.Form["FirstName"]))
            {
                return this.RedirectToAction("Index");
            }
            contact.firstName = Request.Form["FirstName"];
            if (!ContactsService.IsValidEmail(Request.Form["Email"]))
            {
                return this.RedirectToAction("Index");
            }
            contact.emailAddress = Request.Form["Email"];
            ContactsDataAccess.AddContact(contact);
            return RedirectToAction("Success");
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
