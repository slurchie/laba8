using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanager
{

    class Program
    {

        static void Main(string[] args)
        {
            Customer customer = new Customer("Екатерина Владимировка");
            Worker teamLeader = new Worker("Дина Сергеевна", "Тим лидер");
            teamLeader.AddSubordinate(new Worker("Ильшат", "работяга"));
            teamLeader.AddSubordinate(new Worker("Лиля", "работяга"));
            Worker mainWorker = new Worker("Максим", "главный работяга");
            Worker someWorker = new Worker("Саша", "работяга");
            mainWorker.AddSubordinate(someWorker);
            teamLeader.AddSubordinate(mainWorker);
            teamLeader.AddSubordinate(someWorker);
            teamLeader.AddSubordinate(new Worker("Женя", "работяга"));
            teamLeader.AddSubordinate(new Worker("Наташа", "работяга"));
            teamLeader.AddSubordinate(new Worker("Диана", "работяга"));
            teamLeader.AddSubordinate(new Worker("Лена", "работяга"));
            teamLeader.AddSubordinate(new Worker("Маша", "работяга"));
            teamLeader.AddSubordinate(new Worker("Илья", "работяга"));
            Project project = new Project("Какой-то проект", new DateTime(2022, 2, 2), customer, teamLeader);
            teamLeader.CreateTask("Уволиться", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Выпить чаю", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Выпить кофе", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Поесть", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Поспать", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Работать", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Купить печеньки", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Подвинуть шкаф", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("Полить цветы", new DateTime(2022, 1, 1), "работяга", customer, project);
            teamLeader.CreateTask("не заплакать за весь день", new DateTime(2022, 1, 1), "главный работяга", customer, project);
            project.status = "Исполнение";
            Console.WriteLine(project);
            string[] textReport = { "задача почти выполнена. до дедлайна всё будет сделано", "Задача выполнена" };
            for (int i = 0; i < 10; i++)
            {
                teamLeader.subordinates[i].DoWork(textReport);
            }
            project.status = "Закрыт";
            Console.WriteLine(project);
        }
    }
}

