using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Models;

namespace TimeTracker.ViewModels
{
    public class EmployeesViewModel : Conductor<object>
    {

        private BindableCollection<EmployeeModel> _employees = new BindableCollection<EmployeeModel>();
        private EmployeeModel _selectedEmployee;        

        public EmployeesViewModel()
        {
            ActivateItem(new AddEmployeeViewModel());


            DateTime hire = new DateTime(2011, 09, 12);
            DateTime hire2 = new DateTime(2018, 09, 12);
            DateTime hire3 = new DateTime(2015, 02, 27);
            DateTime hire4 = new DateTime(2016, 10, 31);

            Employees.Add(new EmployeeModel { FirstName = "James", MiddleInitial = "J", LastName = "Foster", HireDate = hire});
            Employees.Add(new EmployeeModel { FirstName = "Jane", MiddleInitial = "L", LastName = "Doe", HireDate = hire2 });
            Employees.Add(new EmployeeModel { FirstName = "John", MiddleInitial = " ", LastName = "Doe", HireDate = hire3 });
            Employees.Add(new EmployeeModel { FirstName = "Jack", MiddleInitial = "O", LastName = "Walker", HireDate = hire4 });
            Employees.Add(new EmployeeModel { FirstName = "Jim", MiddleInitial = "K", LastName = "Doe", HireDate = hire2 });
            Employees.Add(new EmployeeModel { FirstName = "Frank", MiddleInitial = "M", LastName = "Joker", HireDate = hire });

            Employees[0].VacationDays.Add(new VacationDayModel { UsedVacationTime = 8, DateVacationUsed = hire });
            Employees[0].Totals.VacationTimeTotal = 70;
            Employees[0].Totals.SickTimeTotal = 40;
        }

        public BindableCollection<EmployeeModel> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyOfPropertyChange(() => SelectedEmployee);
                NotifyOfPropertyChange(() => CanEditEmployeeBtn);
            }
        }

        public bool CanEditEmployeeBtn
        {
            get
            {
                return SelectedEmployee != null;
            }
            
        }

        public void EditEmployeeBtn()
        {

        }

        public void AddEmployeeBtn()
        {

        }
    }
}
