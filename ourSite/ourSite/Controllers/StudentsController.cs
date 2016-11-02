using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ourSite.Models;

namespace ourSite.Controllers
{
    public class StudentsController : Controller
    {
        StudentsListModel _model = new StudentsListModel();

        // GET: Students        
        public ActionResult Index(StudentsListModel model = null)
        {
            _model = new StudentsListModel();

            return View(_model);
        }

        public ActionResult Details(int id)
        {
            var student = new StudentModel(id);

            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = new StudentModel(id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel sentStudent)
        {
            sentStudent.Edit();

            //_model.Students.FirstOrDefault(x => x.id == sentStudent.id).Name = sentStudent.Name;
            //_model.Students.FirstOrDefault(x => x.id == sentStudent.id).Age = sentStudent.Age;

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            StudentsListModel.AddStudent(model);

            return RedirectToAction("Index");
        }
    }
}