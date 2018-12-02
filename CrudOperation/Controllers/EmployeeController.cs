using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private CompanyEntities db =  new CompanyEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAllEmp()
        {
            return View(GetAllEmployees());
        }
        IEnumerable<Employee> GetAllEmployees()
        {
            using (CompanyEntities db = new CompanyEntities())
            {
                return db.Employees.ToList<Employee>();
            }

        }
    
       [Route("Employee/AddOrEdit/{id}")]
   
        public ActionResult AddOrEdit(int id=0)
        {
            Employee Emp = new Employee();
            if (id != 0)
            {
              Emp  = db.Employees.Find(id);
            }
            return View(Emp);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Employee Emp)
        {
            if (Emp.ImageUpload != null)

            {
                string filename = Path.GetFileNameWithoutExtension(Emp.ImageUpload.FileName);
                string extension = Path.GetExtension(Emp.ImageUpload.FileName);
                filename = filename + DateTime.Now.ToString("mmyydd") + extension;
                Emp.ImagePath= "~/AppFiles/Images/" + filename;
                Emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), filename));
            }
            using (CompanyEntities db=new CompanyEntities())
            { if (Emp.EmployeeID == 0) {
                    db.Employees.Add(Emp);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Emp).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }
            return RedirectToAction("Index");
        }





        public ActionResult Delete(int?id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("ViewAllEmp");
        }

        public ActionResult Details(int ?id)
        {
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }
    }
}