using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanager
{
    class Worker
    {
        string name;
        string post;
        public List<Worker> subordinates = new List<Worker>(); //вводим лист подчинённых у работника
        public List<Task> tasks = new List<Task>(1); //вводим лист заданий
        Worker Leader; //вводим лидера среди работников
        public Worker(string Name, string Post) //конструктор принимающий имя и пост сотрудника
        {
            name = Name;
            post = Post;
        }
        public void AddTask(Task task) //метод добавляющий задачу в список задач и выводящий статус 
        {
            tasks.Add(task);
            task.status = "В работе";
            Console.WriteLine(task + " " + task.status);
        }
        public bool TakeTask(string Post, out Worker worker, Worker TeamLeader)
            //метод принимающий задачу и проверяющий если пост подходит, то задачу берёт сам работник
           //потом проверяет ли среди его подчинённых работник который может взять это задание, если у него нет задач
           //если таких сотрудников нет то задача просто не создаётся

        {
            if (Post == post)
            {
                worker = this;
                Leader = TeamLeader;
                return true;
            }
            if (subordinates.Count > 0)
            {
                foreach (Worker S in subordinates)
                {
                    if ((S.TakeTask(Post, out worker, this)) && (S.tasks.Count == 0))
                    {
                        Console.WriteLine(name + " делегировал задачу " + S.name);
                        return true;
                    }
                }
            }
            worker = null;
            return false;
        }
        public void CreateTask(string Description, DateTime time, string Post, Customer Customer, Project project)
            //метод создающий задачу у сотрудников
        {
            if (project.status == "Проект")
            {
                bool flag = false;// есть ли среди подчинённых кто-то, кто может задачу выполнить
                foreach (Worker S in subordinates)
                {
                    if (S.TakeTask(Post, out Worker worker, this))
                    {
                        if (S.tasks.Count > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            Task task = new Task(Description, time, Post, worker, this);
                            project.AddTask(task);
                            worker.AddTask(task);
                            return;
                        }
                    }
                }
                if (flag) foreach (Worker S in subordinates)
                    {
                        if (S.TakeTask(Post, out Worker worker, this))
                        {
                            Task task = new Task(Description, time, Post, worker, this);
                            project.AddTask(task);
                            worker.AddTask(task);
                        }
                    }
            }
        }
        public void AddSubordinate(Worker worker) //добавляет подчинённых в список
        {
            subordinates.Add(worker);
        }
        public bool AcceptReport(Report report)
        {
            Random R = new Random();
            if (R.Next(10) < 5)
            {
                return false;
            }
            else
                return true;
        }
        void CreateReport(string text, Task task) //метод для писания отчётов
            //первоначально версия отчётов 1, если нчачальнику не нравится(зависит от рандома) 
            //то сотрудник переделывает версию отчёта, но отчёт по задаче только 1
        {
            task.status = "На проверке";
            int version = 1;
            Report report = new Report(text, this);
            task.report = report;
            Console.WriteLine("создан отчёт по задаче " + task + " Версия " + version + " " + text);
            while (!Leader.AcceptReport(report))
            {
                version++;
                Console.WriteLine("создан отчёт по задаче " + task + " Версия " + version + " " + text);
            }
            report.text = "Версия " + version + " " + text;
            task.status = "Выполнена";
            Console.WriteLine(task + " " + task.status);
        }
        public void DoWork(string[] textReport) //метод заставляющий людей работать и писать отчёты по работе
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                CreateReport(textReport[i], tasks[i]);
            }
        }
       
        public override string ToString()
        {
            return name + " " + post;
        }
    }
   
}
