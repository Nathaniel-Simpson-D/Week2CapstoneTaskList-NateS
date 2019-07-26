using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTaskList_NateS
{
    public class Task
    {
        #region fields
        //Fields
        //  members
        private string taskName;
        private string memName;
        private string discripsion;
        private string dueDate;
        private bool status;
        #endregion

        #region properties
        //Properties
        //  construcors
        public Task(string _task, string _name, string _discript,string _date )
        {

            taskName = _task;
            memName = _name;
            discripsion = _discript;
            dueDate = _date;
            status = false;
        }
        public Task()
        {
            status = false;
        }
        //  methods
        public string TaskName
        {
            get
            {
                return taskName;
            }
            set
            {
                taskName = value;
            }
        }
        public string MemberName
        {
            get
            {
                return memName;
            }
            set
            {
                memName = value;
            }
        }
        public string Discription
        {
            get
            {
                return discripsion;
            }
            set
            {
                discripsion = value;
            }
        }
        public string DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        public string Status()
        {
            if (status)
            {
                return "Complete";
            }
            else
            {
                return "Incomplete";
            }
        }
        public void Status(bool update)
        {
            status = update;
        }
        public void Edit()
        {
            bool changeName = Validator.GetYN("would you like to change the name?");
            if (changeName)
            {
                taskName = Validator.GetString("What is the new name?");
            }

            bool changeAssigned = Validator.GetYN("Would you like to assign it to another person?");
            if (changeAssigned)
            {
                memName = Validator.VerifyNames("What is the name of the new assignee?");
            }

            bool changeDes = Validator.GetYN("would you like to change the discription?");
            if(changeDes)
            {
                discripsion = Console.ReadLine();
            }

            bool changeDate = Validator.GetYN("would you like to change due date?");
            if(changeDate)
            {
                dueDate = Validator.VerifyDate("What is the new due date?");
            }
        }
        #endregion

    }
}
