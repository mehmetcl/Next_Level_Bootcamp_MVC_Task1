using MehmetCIL_Odev1.Context;
using MehmetCIL_Odev1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MehmetCIL_Odev1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        NorthwindContext context = new NorthwindContext();

        List<Employee> employees;
        public IActionResult Index()
        {
            employees = context.Employees.Select(v => new Employee
            {
                EmployeeId = v.EmployeeId,
                FirstName = v.FirstName,
                LastName = v.LastName,
                Title = v.Title,
                Address = v.Address,
            }).ToList();

            return View(employees);
        }

        public IActionResult Orders(int employeeID)
        {


            List<Order> orders = context.Orders.Where(o => o.EmployeeId == employeeID).Select(o => new Order
            {
                EmployeeId = o.EmployeeId,
                CustomerId = o.CustomerId,
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                ShipCountry = o.ShipCountry


            }).ToList();

            //var combinedModels = new Tuple<List<Order>, List<Employee>>(orders, employees);

            return View(orders);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Employee()
        {
            Employee emp = new Employee();

            return View(emp);
        }

        [HttpPost]
        public IActionResult AddEmployees(Employee employee)
        {

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }
        [HttpPost]
        public IActionResult DeleteEmployees(int employeeId)
        {
            //Önceki kayıtları silememe nedenim diğer tablolarla ilişkileri olması.
            Employee emp = context.Employees.SingleOrDefault(x => x.EmployeeId == employeeId);
            if (emp != null)
            {
                context.Employees.Remove(emp);

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}