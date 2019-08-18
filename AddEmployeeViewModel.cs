using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.ViewModels
{
    class AddEmployeeViewModel : Conductor<object>
    {
        private string _firstName = "";
        private string _middleInitial = "";
        private string _lastName = "";
        private int _month = 0;
        private int _day = 0;
        private int _year = 0;
        private decimal _initialVacationHrs = 0.00m;
        private decimal _initialSickHrs = 0.00m;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSubmitEmployee);
            }
        }

        public string MiddleInitial
        {
            get { return _middleInitial; }
            set
            {
                _middleInitial = value;
                NotifyOfPropertyChange(() => MiddleInitial);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSubmitEmployee);
            }
        }

        public int Month
        {
            get { return _month; }
            set
            {
                _month = value;
                NotifyOfPropertyChange(() => Month);
                NotifyOfPropertyChange(() => CanSubmitEmployee);
            }
        }

        public int Day
        {
            get { return _day; }
            set
            {
                _day = value;
                NotifyOfPropertyChange(() => Day);
                NotifyOfPropertyChange(() => CanSubmitEmployee);
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                NotifyOfPropertyChange(() => Year);
                NotifyOfPropertyChange(() => CanSubmitEmployee);
            }
        }

        public decimal InitialVacationHrs
        {
            get { return _initialVacationHrs; }
            set
            {
                _initialVacationHrs = value;
                NotifyOfPropertyChange(() => InitialVacationHrs);
            }
        }

        public decimal InitialSickHrs
        {
            get { return _initialSickHrs; }
            set
            {
                _initialSickHrs = value;
                NotifyOfPropertyChange(() => InitialSickHrs);
            }
        }


        public bool CanSubmitEmployee
        {
            get
            {
                if (FirstName.Length > 0 && LastName.Length > 0 && Month > 0 && Day > 0 && Year > 1900)
                {
                    return true;
                }
                else
                {
                    return false;
                }
 
            }
        }


        public void SubmitEmployee()
        {

        }

        public void CancelBtn()
        {

        }
    }
}
