using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project4.Models;

namespace Project4.Controllers
{
    public class DiskController : Controller
    {


        private DiskContext context { get; set; }

        public DiskController(DiskContext ctx)
        {
            context = ctx;
        }
        public IActionResult index()
        {

            List<Disk> disks = context.Disks.OrderBy(d => d.DiskName).Include(g => g.Genre).Include(t => t.DiskType).Include(s => s.Status).ToList();
            return View(disks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Description).ToList();
            ViewBag.Statuses = context.Statuses.OrderBy(g => g.Description).ToList();
            ViewBag.DiskTypes = context.DiskTypes.OrderBy(g => g.Description).ToList();
            var disk = context.Disks.Find(id);
            return View(disk);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Description).ToList();
            ViewBag.Statuses = context.Statuses.OrderBy(g => g.Description).ToList();
            ViewBag.DiskTypes = context.DiskTypes.OrderBy(g => g.Description).ToList();
            return View("Edit", new Disk());
        }


        [HttpPost]
        public IActionResult Edit(Disk disk)
        {
            if (ModelState.IsValid)
            {
                if (disk.DiskID == 0)
                    context.Disks.Add(disk);
                else
                    context.Disks.Update(disk);
                context.SaveChanges();
                return RedirectToAction("Index", "Disk");
            }
            else
            {
                ViewBag.Action = (disk.DiskID == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.Description).ToList();
                ViewBag.Statuses = context.Statuses.OrderBy(g => g.Description).ToList();
                ViewBag.DiskTypes = context.DiskTypes.OrderBy(g => g.Description).ToList();
                return View(disk);
            }
        }



        // all delete function down here cause fuck that normal convention of putting get up there 


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var disk = context.Disks.Include(g => g.Genre).Include(t => t.DiskType).Include(s => s.Status).FirstOrDefault(g => g.DiskID == id);
            ViewBag.Genre = disk.Genre.Description.ToString();
            ViewBag.Type = disk.DiskType.Description.ToString();

            return View(disk);
        }

        [HttpPost]
        public IActionResult Delete(Disk disk)
        {
            context.Disks.Remove(disk);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
