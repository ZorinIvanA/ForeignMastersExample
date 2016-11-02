﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ourSite.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public String Name { get; set; }
        public Int32 Age { get; set; }

        public StudentModel()
        {

        }

        public StudentModel(Int32 id)
        {
            var file = "D:\\1.xml";

            var student = StudentsLogic.GetStudentById(file, id);
            this.id = student.Id;
            this.Name = student.Name;
            this.Age = Convert.ToInt32((DateTime.Now - student.Birthday).Days / 365);
        }

        public void Edit()
        {
            Student student = new Student()
            {
                Name = this.Name,
                Id = this.id
            };

            StudentsLogic.EditStudent("D:\\1.xml", student);
        }
    }

    public class StudentsListModel
    {
        public IList<StudentModel> Students { get; set; }

        public StudentsListModel()
        {

            var studentsFromLogic = StudentsLogic.GetStudentList();
            Students = new List<StudentModel>();
            foreach (var student in studentsFromLogic)
            {
                Students.Add(new StudentModel()
                {
                    id = student.Id,
                    Name = student.Name,
                    Age = Convert.ToInt32((DateTime.Now - student.Birthday).Days / 365)
                });
            }
        }

        public static void AddStudent(StudentModel model)
        {
            var student = new Student()
            {
                Name = model.Name,
                Birthday = DateTime.Now
            };

            StudentsLogic.AddStudent(student);
        }
    }



}