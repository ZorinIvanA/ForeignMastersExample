using StudentsFromAPIBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktopConsumer
{
    public class MainPageViewModel
    {
        public List<StudentModel> Students { get; set; }
        public ICommand AddCommand { get; set; }

        public MainPageViewModel()
        {
            Students = new List<desktopConsumer.StudentModel>();
        }

        public void Init()
        {
            var logic = new APIBusinessLogic();
            var studentsFromBL = logic.GetStudents();

            foreach (var blStundet in studentsFromBL)
            {
                StudentModel model = new StudentModel()
                {
                    Name = blStundet.Name,
                    Birthday = blStundet.Birthday
                };

                Students.Add(model);
            }

            AddCommand = new AddCommandClass();
        }


    }

    public class AddCommandClass : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var logic = new APIBusinessLogic();
            logic.AddStudent(new Contracts.BLStudent()
            {
                Name = "Michael",
                Birthday = DateTime.Parse("05.06.2009"),
                Id = 0
            });
        }
    }
}
