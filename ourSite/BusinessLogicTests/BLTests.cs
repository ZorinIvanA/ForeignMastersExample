using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace BusinessLogicTests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void TestGetStudensShouldSuccess()
        {
            var file = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                "\\" + "1.xml";
            Student[] students = new Student[2]
            {
                new Student(){
                    Id = 1, Name = "Ivan", 
                    Birthday = DateTime.Parse("01.01.1985")
                },
                                new Student(){
                    Id = 2, Name = "Vladimir", 
                    Birthday = DateTime.Parse("01.02.1985")
                },
            };


            DataContractSerializer ser =
                new DataContractSerializer(typeof(Student[]));
            XmlWriter writer = XmlWriter.Create(file);
            try
            {
                ser.WriteObject(writer, students);                
            }
            catch
            {
                throw;
            }
            finally
            {
                writer.Close();
            }

            var studentsResult = StudentsLogic.GetStudentsFromXml(file);

            Assert.IsNotNull(studentsResult);
            Assert.AreEqual(2, studentsResult.Count);

        }
    }
}
