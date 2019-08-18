using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Models;
using MySql.Data.MySqlClient;
using System.Windows;

namespace TimeTracker.ViewModels
{
    public class EmployeesViewModel : Conductor<object>
    {
        private MySqlConnection conn;
        private string conString;

        private BindableCollection<EmployeeModel> _employees = new BindableCollection<EmployeeModel>();
        private EmployeeModel _selectedEmployee;        


        public EmployeesViewModel()
        {
            ActivateItem(new AddEmployeeViewModel());


            OpenMySql();
            RetrieveEmployees();
            CloseMySql(conn);
            

            //Employees[0].VacationDays.Add(new VacationDayModel { UsedVacationTime = 8, DateVacationUsed = hire });
            //Employees[0].Totals.VacationTimeTotal = 70;
            //Employees[0].Totals.SickTimeTotal = 40;
        }

        private void OpenMySql()
        {
            conString = "server=127.0.0.1;user id=root;pwd=Samuel#11;persistsecurityinfo=True;database=time_tracker";

            conn = new MySqlConnection(conString);
            try
            {
                conn.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
           
        }

        private void CloseMySql(MySqlConnection conn)
        {
            conn.Close();
        }

        private void RetrieveEmployees()
        {
            string query = "SELECT * FROM employee";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string Ids = reader["employee_id"].ToString();
                string FirstNames = reader["first_name"].ToString();
                string MiddleInitials = reader["middle_initial"].ToString();
                string LastNames = reader["last_name"].ToString();
                string HireDates = reader["hire_date"].ToString();
                EmployeeModel test = new EmployeeModel { Id = Ids, FirstName = FirstNames, MiddleInitial = MiddleInitials, LastName = LastNames, HireDate = HireDates };
                Employees.Add(test);
            }

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
