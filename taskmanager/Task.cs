using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanager
{
    class Task
    {
        public string status;
        string description;
        DateTime dueDate;
        Worker leader;
        Worker worker;
        public Report report;
        string post;
        public string Post
        {
            get
            {
                return post;
            }
            set
            {

            }
        }
        public Task(string Description, DateTime time, string Post, Worker Worker, Worker Leader)
        {
            description = Description;
            dueDate = time;
            post = Post;
            status = "Назначена";
            worker = Worker;
            leader = Leader;
            Console.WriteLine("Создана задача \"" + description + "\" назначена " + worker);
        }
        public override string ToString()
        {
            return "\"" + description + "\"";
        }
    }
}
