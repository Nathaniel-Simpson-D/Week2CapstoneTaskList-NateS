using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTaskList_NateS
{
    class Program
    {
        static void Main()
        {


            string password = "password";
            bool pass = true;
            Console.WriteLine("This is a demo build the password is:password");

            Console.WriteLine();
            while(pass)
            {
                pass = !(Validator.VerifyPassword(password));
            }
            Console.Clear();
            Console.WriteLine("Welcome to out Task Board.");
            Console.WriteLine("Note that ever option that interacts with a single prexisting task will list the tasks for you");

            List<Task> tasks = CreateOrigList();
            while(true)
            {
                
                Console.WriteLine("1: List Tasks");
                Console.WriteLine("2: Add Task");
                Console.WriteLine("3: Delete Task");
                Console.WriteLine("4: Mark Task Complete");
                Console.WriteLine("5: Edit Task");
                Console.WriteLine("6: Search Tasks by Assignee");
                Console.WriteLine("7: Quit");

                int choice = Validator.GetIntChoice(1, 7);

                if (choice == 0)
                {
                    Console.Clear();
                    PrintTasks(tasks);
                    while (!(Validator.GetYN("Return to menue"))) { }
                    Console.Clear();
                }
                else if (choice == 1)
                {
                    tasks = AddTask(tasks);
                }
                else if (choice == 2)
                {
                    tasks = DeleteTask(tasks);
                }
                else if (choice == 3)
                {
                    tasks = MarkTask(tasks);
                }
                else if (choice == 4)
                {
                    tasks = EditTask(tasks);
                }
                else if (choice == 5)
                {
                    SearchTasks(tasks);
                }
                else if (choice == 6)
                {
                    break;
                }
                
            }
            Console.Clear();
            Validator.EndProgram("Goodbye.");
        }
        public static void PrintTasks(List<Task> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {tasks[i].TaskName}: assigned to {tasks[i].MemberName}");
                Console.WriteLine($"    {tasks[i].Discription,10}");
                Console.WriteLine($"    Status: {tasks[i].Status()}");
                Console.WriteLine($"    Due: {tasks[i].DueDate}");
            }
        }
        public static List<Task> AddTask(List<Task> tasks)
        {
            Console.Clear();
            string taskName =Validator.GetString("What is the name of the task?");
            string teamMem = Validator.VerifyNames("What is the name of the Team member responsable for said task?");
            string descript = Validator.GetString("Describe the task in a breif sentence.");
            string date = Validator.VerifyDate("What day is the task due?");

            Task task = new Task(taskName,teamMem,descript,date);
            tasks.Add(task);
            
            Console.Clear();

            return tasks;

        }
        public static List<Task> DeleteTask(List<Task> tasks)
        {
            Console.Clear();
            PrintTasks(tasks);
            Console.WriteLine("What task would you like to delete(enter reference number)?");
            int choice = Validator.GetIntChoice(1,tasks.Count);
            bool confirm = Validator.GetYN($"Are you sure you want to delete {tasks[choice].TaskName}");
            if (confirm)
            {
                tasks.RemoveAt(choice);
            }
            Console.Clear();
            return tasks;

        }
        public static List<Task> MarkTask(List<Task> tasks)
        {
            Console.Clear();
            PrintTasks(tasks);
            Console.WriteLine("What task would you like to mark as complete(enter reference number)?");
            int choice = Validator.GetIntChoice(1, tasks.Count);
            bool confirm = Validator.GetYN($"Are you sure you want to Mark {tasks[choice].TaskName} as Complete?");
            if (confirm)
            {
                tasks[choice].Status(true);
            }
            Console.Clear();
            return tasks;
        }
        public static List<Task> EditTask(List<Task> tasks)
        {

            Console.Clear();
            PrintTasks(tasks);
            Console.WriteLine("What task would you like to edit?");
            int choice = Validator.GetIntChoice(1, tasks.Count);
            bool confirm = Validator.GetYN($"Are you sure you want to edit {tasks[choice].TaskName}?");
            if (confirm)
            {
                Console.Clear();
                tasks[choice].Edit();
            }
            Console.Clear();
            return tasks;
        }
        public static void SearchTasks(List<Task> tasks)
        {
            Console.Clear();
            string search = Validator.VerifyNames("What is the name of the asignee your searching for(use proper capitilization and both first and last name)?");
            foreach (Task t in tasks)
            {
                
                int i = 0;
                if (t.MemberName == search)
                {
                    Console.WriteLine($"{i + 1}) {t.TaskName}: assigned to {t.MemberName}");
                    Console.WriteLine($"    Discription:{t.Discription,10}");
                    Console.WriteLine($"    Status: {t.Status()}");
                    Console.WriteLine($"    Due: {t.DueDate}");
                    i++;
                }
                
            }
            bool done = true;
            while (done)
            {
                done = !(Validator.GetYN("Return to menue?"));
            }
            Console.Clear();
        }
        public static List<Task> CreateOrigList()
        {
            List<Task> list = new List<Task>();
            Task task1 = new Task("Grade Capstone 2", "Stephen Jedlicki", "Give everybody full credit", "07/30/2019");
            Task task2 = new Task("Grade Assesment 2", "Stephen Jedlicki", "Give everybody full credit", "07/30/2019");
            Task task3 = new Task("Get to Sleep", "Nate Simpson", "You need to get up in the morning.","07/29/2019");
            Task task4 = new Task("Clean", "Amilia Oliver", "Stop leaving messes and clean up after yourseld","00/00/0000");

            list.Add(task1);
            list.Add(task2);
            list.Add(task3);
            list.Add(task4);

            return list;

        }


    }
}
