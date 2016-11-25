using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataAccessLayer;
using System.Data.Entity.Core.Objects;
using Contracts;
using System.Reflection;
using System.IO;

namespace BusinessLogic
{
    public class StudentsLogic : IBusinessLogic
    {
        static IDataAccessLayer _DAL;

        static StudentsLogic()
        {
            _DAL = new DBStudentDAL();

        }

        public IList<BLStudent> GetStudents()
        {
            var studentsInDAL = _DAL.GetStudents(null);
            List<BLStudent> result = new List<BLStudent>();

            foreach (var st in studentsInDAL)
            {
                result.Add(new BLStudent()
                {
                    Id = st.id,
                    Name = st.Name,
                    Birthday = st.Birthday
                });
            }

            return result;

        }

        public static List<Student> GetStudentList()
        {
            var studentsInDAL = _DAL.GetStudents(null);
            List<Student> result = new List<Student>();

            foreach (var st in studentsInDAL)
            {
                result.Add(new Student()
                {
                    Id = st.id,
                    Name = st.Name,
                    Birthday = st.Birthday
                });
            }

            return result;
        }

        public static List<Student> GetStudentsFromXml(String xmlFile)
        {
            StudentsEntities ctx = new StudentsEntities();
            var students = ctx.Students.Select(x => new Student()
            {
                Id = x.StudentID,
                Name = x.StudentName,
                Birthday = (x.Birthday.HasValue) ? x.Birthday.Value : DateTime.MinValue
            }).ToList();

            return students;
            //return GetStudentsFromAxml(xmlFile);
        }

        private static Student GetBLStudentFromDBStudent(Students x)
        {
            return new Student()
            {
                Id = x.StudentID,
                Name = x.StudentName,
                Birthday = (x.Birthday.HasValue) ? x.Birthday.Value : DateTime.MinValue
            };
        }

        public static Student GetStudentById(String xmlFile, Int32 id)
        {
            StudentsEntities ctx = new StudentsEntities();
            var student = ctx.Students.FirstOrDefault(x => x.StudentID == id);
            return GetBLStudentFromDBStudent(student);

            //List<Student> students = GetStudentsFromAxml(xmlFile);
            //return students.FirstOrDefault(x => x.Id == id);
        }

        public static void EditStudent(String xmlFile, Student student)
        {
            StudentsEntities ctx = new StudentsEntities();
            var newStudent = ctx.Students.FirstOrDefault(x => x.StudentID == student.Id);
            newStudent.StudentName = student.Name;
            newStudent.Birthday = student.Birthday;

            ctx.SaveChanges();


            //List<Student> students = GetStudentsFromAxml(xmlFile);

            //var item = students.FirstOrDefault(x => x.Id == student.Id);

            //item.Name = student.Name;
            //item.Birthday = student.Birthday;

            //WriteStudentsListToXml(xmlFile, students);
        }

        private static void WriteStudentsListToXml(String xmlFile, List<Student> students)
        {
            DataContractSerializer ser2 =
                new DataContractSerializer(typeof(List<Student>));
            XmlWriter writer = XmlWriter.Create(xmlFile);
            try
            {
                ser2.WriteObject(writer, students);
            }
            catch
            {
                throw;
            }
            finally
            {
                writer.Close();
            }
        }

        private static List<Student> GetStudentsFromAxml(String xmlFile)
        {
            List<Student> students = new List<Student>();

            DataContractSerializer ser =
new DataContractSerializer(typeof(List<Student>));
            XmlReader reader = XmlReader.Create(xmlFile);
            try
            {
                students = ser.ReadObject(reader) as List<Student>;
            }
            catch
            {
                throw;
            }
            finally
            {
                reader.Close();
            }

            return students;
        }

        public static void AddStudent(Student student)
        {
            StudentsEntities ctx = new StudentsEntities();
            ObjectParameter id = new ObjectParameter("studentId", 0);
            ctx.spAddStudent(student.Name, student.Birthday, 1, id);

            //var newStudent = ctx.Students.FirstOrDefault(x => x.StudentID == student.Id);
            //newStudent.StudentName = student.Name;
            //newStudent.Birthday = student.Birthday;

            //ctx.SaveChanges();
        }
        public void AddStudent(DALStudent student) { }

        public BLStudent GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(BLStudent student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudentById(int student)
        {
            throw new NotImplementedException();
        }
    }
}
