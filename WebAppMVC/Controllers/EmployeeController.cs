using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Interfaces;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

        public ActionResult Index()
        {
            var employees = _employeeService.Get();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            _employeeService.Post(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Employee employee = _employeeService.GetById(id);
            return View("Create", employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            _employeeService.Put(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
