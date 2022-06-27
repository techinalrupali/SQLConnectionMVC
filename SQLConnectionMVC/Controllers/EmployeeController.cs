using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLConnectionMVC.Models;
using Microsoft.AspNetCore.Http;

namespace SQLConnectionMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDal context = new EmployeeDal();
        public IActionResult List()
        {
            ViewBag.EmployeeList = context.GetAllEmployee();
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
            Employee e = new Employee();
            e.Name = form["name"];
            e.Salary = Convert.ToDecimal(form["salary"]);
            e.Department = form["department"];
            int res = context.Save(e);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = new Employee();
            ViewBag.Name = emp.Name;
            ViewBag.Salary = emp.Salary;
            ViewBag.Department = emp.Department;
            ViewBag.Id =emp.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Employee emp = new Employee();
            emp.Name = form["name"];
            emp.Salary = Convert.ToDecimal(form["salary"]);
            emp.Department = form["department"];
            emp.Id = Convert.ToInt32(form["id"]);
            int res = context.Update(emp);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee emp = context.GetEmployeeById(id);
            ViewBag.Name = emp.Name;
            ViewBag.Salary = emp.Salary;
            ViewBag.Department = emp.Department;
            ViewBag.Id = emp.Id;
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

