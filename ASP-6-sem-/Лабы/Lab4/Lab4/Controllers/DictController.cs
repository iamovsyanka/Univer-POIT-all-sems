using Lab4.Models;
using Lab4.Repository;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class DictController : Controller
    {
        private ContactRepository contactRepository = new ContactRepository();

        public ActionResult Index()
        {
            return View(contactRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ActionName("Add")]
        public ActionResult AddSave(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.Create(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var contact = contactRepository.Get(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Update")]
        public ActionResult UpdateSave(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.Update(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var contact = contactRepository.Get(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(int id)
        {
            contactRepository.Remove(contactRepository.Get(id));

            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}