using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project4.Models;

namespace Project4.Controllers
{
    public class CartController : Controller
    {
        private DiskContext context { get; set; }

        public CartController(DiskContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var diskhasborrowers = context.BorrowedDisks.Include(g => g.Disk).Include(g => g.Borrower).OrderBy(g => g.Disk.DiskName)
                .ToList();
            return View(diskhasborrowers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            DiskHasBorrowerViewModel checkout = new DiskHasBorrowerViewModel();
            checkout.BorrowedDate = DateTime.Now;
            checkout.Disks = context.Disks.OrderBy(d => d.DiskName).ToList();
            checkout.Borrowers = context.Borrowers.OrderBy(b => b.LastName).ToList();
            return View("Edit", checkout);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var dhb = context.BorrowedDisks.Find(id);
            DiskHasBorrowerViewModel checkout = new DiskHasBorrowerViewModel();
            checkout.Disks = context.Disks.OrderBy(d => d.DiskName).ToList();
            checkout.Borrowers = context.Borrowers.OrderBy(d => d.LastName).ToList();
            checkout.BorrowedDiskID = dhb.BorrowedDiskID;
            checkout.BorrowerID = dhb.BorrowerID;
            checkout.DiskID = dhb.DiskID;
            checkout.BorrowedDate = dhb.BorrowedDate;
            checkout.ReturnedDate = dhb.ReturnedDate;
            return View(checkout);
        }


        [HttpPost]
        public IActionResult Edit(DiskHasBorrowerViewModel dhbvm)
        {
            DiskHasBorrower checkout = new DiskHasBorrower();
            if (ModelState.IsValid)
            {
                checkout.BorrowedDiskID = dhbvm.BorrowedDiskID;
                checkout.BorrowerID = dhbvm.BorrowerID;
                checkout.DiskID = dhbvm.DiskID;
                checkout.BorrowedDate = dhbvm.BorrowedDate;
                checkout.ReturnedDate = dhbvm.ReturnedDate;
                if(checkout.BorrowedDiskID == 0)
                {
                    context.BorrowedDisks.Add(checkout);
                }
                else
                {
                    context.BorrowedDisks.Update(checkout);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            ViewBag.Action = (dhbvm.BorrowedDiskID == 0) ? "Add" : "Edit";
            return View(dhbvm);
        }
    }
}
