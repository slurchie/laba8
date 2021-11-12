using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methodichka
{
        class bankTransaction
        {
            readonly DateTime time; //readonly означает чтоприсвоение значения полю
                                    //может происходить только при объявлении или в конструкторе
                                    //этого класса
        readonly decimal sum;
            public bankTransaction(decimal sum)
            {
                this.sum = sum;
                time = DateTime.Now;
            }
            public override string ToString() //переопределяем чтобы было легче использовать при переопределениии
            {
                return $"{time} {sum}";
            }
        }
    }
