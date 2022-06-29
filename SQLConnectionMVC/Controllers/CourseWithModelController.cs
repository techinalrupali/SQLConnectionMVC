using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLConnectionMVC.Models;

namespace SQLConnectionMVC.Controllers
{
    public class CourseWithModelController : Controller
    {
        CourseDal cd = new CourseDal();
        // GET: CourseWithModelController
        public ActionResult Index()
        {
            var model = cd.GetAllCourse();
            return View(model);
        }

        // GET: CourseWithModelController/Details/5
        public ActionResult Details(int id)
        {
            var course = cd.GetCourseById(id);
            return View(course);
        }
        // GET: CourseWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                cd.Save(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = cd.GetCourseById(id);
            return View(course);
        }

        // POST: CourseWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            try
            {
                cd.Update(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Course course= cd.GetCourseById(id);
            return View(course);
        }

        // POST: CourseWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                cd.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
