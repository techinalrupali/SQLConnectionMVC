using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLConnectionMVC.Models;

namespace SQLConnectionMVC.Controllers
{
    public class EmployeeWithModelController : Controller
    {
        EmployeeDal ed = new EmployeeDal();
        // GET: EmployeeWithModelController
        public ActionResult Index()
        {
            var model = ed.GetAllEmployee();
            return View(model);
        }

        // GET: EmployeeWithModelController/Details/5
        public ActionResult Details(int id)
        {
            var emp = ed.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmployeeWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                ed.Save(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee emp = ed.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                ed.Update(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = ed.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                ed.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
