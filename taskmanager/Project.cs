using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanager
{
    class Project
    {
        public string status;
        string description;
        DateTime dueDate;
        Customer customer;
        Worker teamLeader;
        List<Task> tasks;
        public Project(string Description, DateTime time, Customer C, Worker Leader)
        {
            description = Description;
            dueDate = time;
            status = "Проект";
            customer = C;
            teamLeader = Leader;
            tasks = new List<Task>(1);
            Console.WriteLine("Создан проект " + this);
        }

        public void AddTask(Task task) //метод добвялющий задачу в список
        {
            tasks.Add(task);
        }
        public override string ToString() //переопределяем метод чтобы потом было легче его выводить
        {
            return "\"" + description + "\", статус: \"" + status + "\" срок выполнения " + dueDate.ToString();
        }
    }
}

