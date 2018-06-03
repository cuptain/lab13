using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    //Базовый интерфейс
    interface IPerson:IComparable
    {
        string Return_se_name(); //метод возврата фамилии

        string Return_name(); //метод возврата фамилии

        void Input(); //метод ввода

        void Show(); //метод вывода

        new int CompareTo(object other); //сравнение
    }
}
