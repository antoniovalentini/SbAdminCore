using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SbAdminCore.Web.Models;
using SbAdminCore.Web.ViewModels;

namespace SbAdminCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Employee> _employees;

        public HomeController(IHostingEnvironment env)
        {
            _employees = new List<Employee>();
            FetchEmployees(env);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blank()
        {
            return View();
        }

        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View(new TablesViewModel{Employees = new List<Employee>(_employees)});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NotFound()
        {
            return View();
        }

        private void FetchEmployees(IHostingEnvironment env)
        {
            _employees.Clear();
            var path = Path.Combine(env.ContentRootPath, "App_Data\\emps.xml");
            var doc = new XmlDocument();
            doc.Load(path);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes){
                var emp = new Employee
                {
                    Name = node.ChildNodes[0].InnerText,
                    Position = node.ChildNodes[1].InnerText,
                    Office = node.ChildNodes[2].InnerText,
                    Age = node.ChildNodes[3].InnerText,
                    StartDate = node.ChildNodes[4].InnerText,
                    Salary = node.ChildNodes[5].InnerText,
                };
                _employees.Add(emp);
            }
        }
    }
}
