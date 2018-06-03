using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Libriary;

namespace Hierarchy
{
    //Производный от Person
    class Worker : Person, IPerson, IComparable
    {
        protected int experience;
        protected long salary;

        //Получение стажа
        public int GetExperience
        {
            get { return experience; }
            protected set { experience = value; }
        }

        //Получение зарплаты
        public long GetSalary
        {
            get { return salary; }
            protected set { salary = value; }
        }

        //Конструктор без параметров
        public Worker() : base()
        {
            experience = 0;
            salary = 0;
        }

        //Конструктор с параметрами
        public Worker(string Name, string Surname, int Experience, long Salary) : base(Name, Surname)
        {
            experience = Experience;
            salary = Salary;
        }

        //Вывод рабочего
        public override void Show()
        {
            /*string srok = experience.ToString();
            if ((srok == "1") || (srok == "21") || (srok == "31") || (srok == "41"))
                Console.WriteLine(surname + " " + name + "\nСтаж: " + srok + " год\nЗарплата: " +
                    salary + " тыс. руб.\n");
            if ((srok[srok.Length - 1] == '2') || (srok[srok.Length - 1] == '3') || (srok[srok.Length - 1] == '4'))
                Console.WriteLine(surname + " " + name + "\nСтаж: " + srok + " года\nЗарплата: " +
                    salary + " тыс. руб.\n");
            else
                Console.WriteLine(surname + " " + name + "\nСтаж: " + srok + " лет\nЗарплата: " +
                    salary + " тыс. руб.\n");*/
            Console.WriteLine(surname + " " + name + "\nСтаж: " + experience + "\nЗарплата: " + salary + " тыс. руб.\n");
        }

        //Ввод рабочего
        public override void Input()
        {
            string[] input = null;

            string inputFI = Easy.EnterName("Введите Фамилию и Имя рабочего, которого необходимо найти: ");

            Console.WriteLine("Введите стаж рабочего: ");
            int exp = Easy.ReadVGran(1, 50, "Стаж рабочего");

            Console.WriteLine("Введите зарплату рабочего: ");
            int money = Easy.ReadVGran(10000, 200000, "Зарплата рабочего");

            input = inputFI.Split(' ');

            name = input[1];
            surname = input[0];
            experience = exp;
            salary = money;
        }
    }
}
