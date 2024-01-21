using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> list = null;

        public EmployeeController()
        {
            if (list == null)
            {
                list = new List<Employee>()
                {
                    new Employee() { Id = 1, Name = "Animesh", Address = " Delhi", Doj = DateTime.Parse("07/12/2023"), Password = "123456", ReTypePassword = "1234456", Age = 23, JoiningYear = 2023 },
                    new Employee() { Id = 2, Name = "Divyanshu", Address = " Lucknow", Doj = DateTime.Parse("08/12/2023"), Password = "1234567", ReTypePassword = "1234567", Age = 18, JoiningYear = 2023 }
                };

            }
        }
        public IActionResult Index()
        {
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            list.Add(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Employee employee = list.Where( x => x.Id == id).FirstOrDefault();
            if(employee == null)
            {
                return View(employee);
            }
            else
            {
                ViewBag.msg = "No record found";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            foreach(Employee emp in list)
            {
                if(emp.Id == employee.Id)
                {
                    emp.Name = employee.Name;
                    emp.Address = employee.Address;
                    emp.Doj = employee.Doj;
                    employee.Password = employee.Password;
                    emp.ReTypePassword = employee.ReTypePassword;
                    emp.Age = employee.Age;
                    emp.JoiningYear = employee.JoiningYear;
                    break;
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete (int? id)
        {
            if(!id.HasValue)
            {
                ViewBag.msg = " PLease provide a ID"; 
                return View();
            }

            else
            {
                var employee = list.Where(x=> x.Id == id).FirstOrDefault();
                if(employee == null)
                {
                    ViewBag.msg = "There is no record with this ID";
                    return View();
                }
                else
                {
                    return View(employee);
                }

            }
        }

        [HttpPost]

        public IActionResult Delete (Employee employee, int id) 
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if(temp != null)
            {
                list.Remove(temp);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Display(int? id)
        {
            if(!id.HasValue)
            {
            
                ViewBag.msg = "PLease provide a ID";
                return View();
            }
            else
            {
                var employee = list.Where(x=>x.Id == id).FirstOrDefault();
                if(employee == null)
                {
                    ViewBag.msg = "There is no record with this ID";
                    return View();
                }
                else
                {
                    return View(employee);
                }
            }
        }
    }
}
