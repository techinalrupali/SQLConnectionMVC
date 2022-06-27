using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLConnectionMVC.Models;
using Microsoft.AspNetCore.Http;

namespace SQLConnectionMVC.Controllers
{
    public class CourseController : Controller
    {
        CourseDal context = new CourseDal();
        public IActionResult List()
        {
            ViewBag.CourseList = context.GetAllCourse();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Course c = new Course();
            c.CourseName = form["name"];
            c.CourseFees = Convert.ToDecimal(form["fees"]);
            int res = context.Save(c);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course course = new Course();
            ViewBag.Name = course.CourseName;
            ViewBag.Fees = course.CourseFees;
            ViewBag.Id = course.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Course course= new Course();
            course.CourseName = form["name"];
            course.CourseFees = Convert.ToDecimal(form["fees"]);
            course.Id = Convert.ToInt32(form["id"]);
            int res = context.Update(course);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course course = context.GetCourseById(id);
            ViewBag.Name = course.CourseName;
            ViewBag.Fees = course.CourseFees;
            ViewBag.Id = course.Id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
    }
}

