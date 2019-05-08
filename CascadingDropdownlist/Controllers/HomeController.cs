using CascadingDropdownlist.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropdownlist.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();

            using (StudentDBContext db = new StudentDBContext())
            {
                students = db.Students.ToList();
            }

            return View(students);
        }

        [HttpGet]
        public ActionResult NewUpdateStudent()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult NewUpdateStudent(Student student, int? contry, int? state)
        {
            if (contry != null)
            {
                ViewData["CountryId"] = contry;
            }

            if (state != null)
            {
                ViewData["StateId"] = state;
            }


            if (ModelState.IsValid)
            {
                using (StudentDBContext db = new StudentDBContext())
                {
                    db.Students.Add(student);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}