using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCRUDOP.Controllers
{
    public class HomeController : Controller
    {
        mvccrudopEntities _context = new mvccrudopEntities();

        public ActionResult Index()
        {
            var listdata = _context.Students.ToList();
            return View(listdata);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Inserted Sucessfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student model)
        {
            var data = _context.Students.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentName = model.StudentName;
                data.StudentFees = model.StudentFees;
                data.StudentCity = model.StudentCity;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}