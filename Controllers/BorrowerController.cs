using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project4.Models;

namespace Project4.Controllers
{
    public class BorrowerController : Controller
    {


        private DiskContext context { get; set; }

        public BorrowerController(DiskContext ctx)
        {
            context = ctx;
        }
        public ViewResult index()
        {
            var borrowers = context.Borrowers.OrderBy(g => g.LastName).ThenBy(g => g.FirstName).ToList();

            return View(borrowers);
        }




        [HttpGet]
        public ViewResult Edit(int id)
        {

            ViewBag.Borrowers = context.Borrowers.OrderBy(g => g.LastName).ThenBy(g => g.FirstName).ToList();
            var borrower = context.Borrowers.Find(id);
            return View(borrower);

        }


        [HttpPost]
        public IActionResult Edit(Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                context.Borrowers.Update(borrower);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Please correct all errors.");
                return View(borrower);
            }
        }

        [HttpGet]
        public ViewResult Add() => View(new Borrower());


        [HttpPost]


        public IActionResult Add(Borrower borrower)
        {


            if (ModelState.IsValid)
            {
                context.Borrowers.Add(borrower);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Please correct all errors.");
                return View(borrower);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var borrower = context.Borrowers.Find(id);
            return View(borrower);
        }

        [HttpPost]
        public IActionResult Delete(Borrower borrower)
        {
            context.Borrowers.Remove(borrower);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
