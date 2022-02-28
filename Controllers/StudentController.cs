using MvcCrudOperation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudOperation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        db_crudEntities dbObj = new db_crudEntities();
        public ActionResult Student(tb_student obj)
        {
            if(obj != null)
            return View(obj);
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tb_student model)
        {
            return View();
        }

        public ActionResult StudentList()
        {
            var res = dbObj.tb_student.ToList();
            return View(res);
        }
        //public ActionResult AddStudent(tb_student model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        tb_student obj = new tb_student();
        //        obj.FirstNAme = model.FirstNAme;
        //        obj.LastName = model.LastName;
        //        obj.FatherName = model.FatherName;
        //        obj.Email = model.Email;
        //        obj.MobileNumber = model.MobileNumber;
        //        obj.Description = model.Description;

        //        dbObj.tb_student.Add(obj);
        //        dbObj.SaveChanges();
        //    }
        //    ModelState.Clear();
        //    return View("Student");
        //}
        public ActionResult Delete(int id)
        {
            var res = dbObj.tb_student.Where(x => x.ID == id).First();
            dbObj.tb_student.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tb_student.ToList();
            return View("StudentList", list);
        }
    }
}