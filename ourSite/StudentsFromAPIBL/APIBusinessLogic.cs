using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StudentsFromAPIBL
{
    /// <summary>
    /// Business logic, which gets data from Web API
    /// </summary>
    public class APIBusinessLogic : IBusinessLogic
    {
        String APIUrl = "http://localhost:43967/api/students";

        public void AddStudent(DALStudent student)
        {
            HttpClient client = new HttpClient();

            //var response = client.PutAsync(APIUrl, ).Result;
        }

        public void DeleteStudentById(int student)
        {
            throw new NotImplementedException();
        }

        public BLStudent GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<BLStudent> GetStudents()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(APIUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var students = (IList<DALStudent>)response.Content.ReadAsAsync<IList<DALStudent>>().Result;
                IList<BLStudent> result = new List<BLStudent>();
                foreach (var st in students)
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

            throw new Exception();
        }

        public void UpdateStudent(BLStudent student)
        {
            throw new NotImplementedException();
        }
    }
}
