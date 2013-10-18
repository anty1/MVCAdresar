using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmegaSoftware_Adresar_kontakata.Models;

namespace OmegaSoftware_Adresar_kontakata.Controllers
{
    public class ContactsController : Controller
    {
        private AdresarContext db = new AdresarContext();

        //
        // GET: /Contacts/

        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        //
        // GET: /Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contacts/Create

        public ActionResult Create()
        {
            var contact = new Contact();
            contact.CreatePhoneNumbers(1);
            return View(contact);
        }

        //
        // POST: /Contacts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            /*if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            AdresarContext db = new AdresarContext();

            if (ModelState.IsValid)
            {
                foreach (ContactNumber phone in contact.Numbers.ToList())
                {
                    if (phone.DeletePhone == true)
                    {
                        // Delete Phone Numbers which is marked to remove
                        contact.Numbers.Remove(phone);
                    }
                }
                
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            //return View(contact);
        }

        //
        // GET: /Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contacts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();

                foreach (var item in contact.Numbers)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            var phones = db.ContactNumbers.Where(i => i.ContactID == contact.ContactID);
            DeleteChilds(phones);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void DeleteChilds(IEnumerable<ContactNumber> phones)
        {
            foreach (var item in phones)
            {
                db.ContactNumbers.Remove(item);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}