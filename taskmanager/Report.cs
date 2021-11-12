using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanager
{
    class Report
    {
        public string text;
        DateTime dueDate;
        Worker worker;
        public Worker author //свойство читающее работягу
        {
            get
            {
                return worker;
            }
            set
            {

            }
        }
        public Report(string Text, Worker Worker) //конструктор описывающий отчёт
        {
            dueDate = DateTime.Now;
            text = Text;
            worker = Worker;
        }
    }
}
