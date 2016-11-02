using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBStudentDAL : IDataAccessLayer
    {
        public List<DALStudent> GetStudents(object args)
        {
            StudentsEntities ctx = new StudentsEntities();

            List<DALStudent> students = new List<DALStudent>();

            foreach (var s in students)
            {
                students.Add(new DALStudent()
                {
                    Birthday = s.Birthday,
                    id = s.id,
                    Name = s.Name
                });
            }

            return students;
        }
    }
}
