using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStudy.Models;
using PagedList.Mvc;
using PagedList;

namespace TestStudy.Controllers
{
    public class CategoryController : Controller
    {
        private TestDb db = new TestDb();
        // GET: Category
        public ActionResult Index(int ? page,string search="" )
        {
            ViewBag.search = search;
            var c = db.categories.ToList();
            if (search!="")
            {
                c = c.Where(x => x.Name.Contains(search)).ToList();
            }
            return View(c.ToPagedList(page ?? 1, 3));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category Category)
        {
            
            if (Category.Name!=null)
            {
                db.categories.Add(Category);
                db.SaveChanges();
                ViewBag.message = "Added";
            }
            else
            {
                ViewBag.message = "Failed to Add";
            }
            
            return View();
        }
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                ViewBag.message = "Category Not Found";
                return RedirectToAction("Index", "Category");
            }
            Category ct = db.categories.Find(Id);
            return View(ct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category Category)
        {

            if (Category.Name != null)
            {
                db.Entry(Category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.message = "Updated";
            }
            else
            {
                ViewBag.message = "Failed to Update";
            }

            return View();
        }
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                ViewBag.message = "Category Not Found";
                return RedirectToAction("Index", "Category");
            }
            Category ct = db.categories.Find(Id);
            db.categories.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}