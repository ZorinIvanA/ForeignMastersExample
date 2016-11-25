using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// Business Logic contract interface
    /// </summary>
    public interface IBusinessLogic
    {
        IList<BLStudent> GetStudents();

        BLStudent GetStudentById(Int32 id);

        void UpdateStudent(BLStudent student);

        void AddStudent(DALStudent student);

        void DeleteStudentById(int student);
    }
}
