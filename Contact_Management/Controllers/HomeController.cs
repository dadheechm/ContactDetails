using Contact_Management.Models;
using System.Linq;
using System.Web.Mvc;

namespace Contact_Management.Controllers
{
    public class HomeController : Controller
    {
        APIClient _APIClient = new APIClient();
        public ActionResult Index()
        {
            var errorMsg = TempData["ErrorMsg"];
            if (errorMsg != null)
            {
                ViewBag.ErrorMsg = errorMsg;
            }
            var allContacts = _APIClient.GetAllContacts();
            if (allContacts == null)
            {
                allContacts = Enumerable.Empty<ContactModel>();
                ModelState.AddModelError(string.Empty, "Something went wrong.");
            }
            else if(allContacts.Count() == 0)
            {
                ModelState.AddModelError(string.Empty, "No Records Found.");
            }
            return View(allContacts);
        }

        public ActionResult Edit(int _Id)
        {
            ContactModel _ContactModel = null;
            _ContactModel = _APIClient.GetContactById(_Id);
            if (_ContactModel == null)
            {
                TempData["ErrorMsg"] = "No Matching Record Found";
                return RedirectToAction("Index");
            }
            return View(_ContactModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactModel _ContactModel)
        {
            if (!_APIClient.CreateContact(_ContactModel))
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult Edit(ContactModel _ContactModel)
        {
            if(!_APIClient.UpdateContact(_ContactModel))
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int _Id)
        {
            if(!_APIClient.DeleteContact(_Id))
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
