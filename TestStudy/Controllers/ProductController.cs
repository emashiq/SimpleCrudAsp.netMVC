using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStudy.Models;

namespace TestStudy.Controllers
{
    public class ProductController : Controller
    {
        private TestDb db = new TestDb();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}