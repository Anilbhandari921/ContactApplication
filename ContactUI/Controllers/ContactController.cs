using ContactUI.Models;
using ContactUtilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactUI.Controllers
{
    
    public class ContactController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> con = await Repository.GetAllContacts();
            return View(con);
        }
        public IActionResult Create()
        {
            return View();
        }

        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Contact con)
        {
            Task.Run(()=> Repository.Create(con));
            return View("Thanks", con);
        }

        public async Task<IActionResult> Update(int id)
        {
            Contact objContact = await Task.Run(() => Repository.GetContactDetails(id));
            return View(objContact);
        }

        [HttpPost]
        public IActionResult Update(Contact objContact, int id)
        {
            Task.Run(() => Repository.Update(objContact));

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(long? id)
        {
            Task.Run(() => Repository.DeleteContact(id));
            return RedirectToAction("Index");
        }
    }
}
