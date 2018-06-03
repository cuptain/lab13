using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using FuncThat;

namespace Hierarchy
{
    class Administration : Worker, ICloneable
    {
        protected string address;

        //Получение адреса
        public string GetAddress
        {
            get { return address; }
            protected set { address = value; }
        }

        //Конструктор без параметров
        public Administration() : base()
        {
            address = "";
        }

        //Конструктор с параметрами
        public Administration(string Name, string Surname, int Experience, long Salary, string Address) 
            : base (Name, Surname, Experience, Salary)
        {
            address = Address;
        }

        //Вывод администратора
        public override void Show()
        {
            /*string srok = experience.ToString();
            if ((srok == "1") || (srok == "21") || (srok == "31") || (srok == "41"))
                Console.WriteLine(surname + " " + name + "\nСтаж: " + srok + " год\nЗарплата: " + 
                    salary + " тыс. руб." + "\nРаботает в администрации по адресу: " + address + "\n");
            if ((srok[srok.Length - 1] == '2') || (srok[srok.Length - 1] == '3') || (srok[srok.Length - 1] == '4'))
                Console.WriteLine(surname + " " + name + "\nСтаж: " + srok + " года\nЗарплата: " + 
                    salary + " тыс. руб." + "\nРаботает в администрации по адресу: " + address + "\n");
            else
                Console.WriteLine(surname + " " + name + "\nСтаж: " + srok + " лет\nЗарплата: " + 
                    salary + " тыс. руб." + "\nРаботает в администрации по адресу: " + address + "\n");*/
            Console.WriteLine(surname + " " + name + "\nСтаж: " + experience + "\nЗарплата: " + salary + " тыс. руб." + "\nРаботает в администрации по адресу: " + address + "\n");
        }

        //Ввод инженера
        public override void Input()
        {
            string[] input = null;
            string ad = "";

            string inputFI = Easy.EnterName("Введите Фамилию и Имя инженера, которого необходимо найти: ");

            Console.WriteLine("Введите стаж инженерп: ");
            int exp = Easy.ReadVGran(1, 5, "Стаж инженера");

            Console.WriteLine("Введите зарплату инженера: ");
            int money = Easy.ReadVGran(5000, 100000, "Зарплата инженера");

            Regex regex = new Regex(@"(?<!\S)\b[у][л][.][ ][А-Я][а-я]+[,][ ][д][.][ ][1-9]\d*[а-я]*(?!\S)\b");
            bool ok = true;
            while (ok)
            {
                Console.Write("Введите адрес администрации, в которой работает сотрудник: ");
                ad = Console.ReadLine();
                if (regex.IsMatch(ad))
                {
                    ok = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите адрес в формате \"ул. *** д. **\"");
                }
            }

            input = inputFI.Split(' ');

            name = input[1];
            surname = input[0];
            experience = exp;
            salary = money;
            address = ad;
        }

        //Поверхностное копирование
        public Administration SurfaceCopying()
        {
            return (Administration)this.MemberwiseClone();
        }

        //Глубокое копирование
        public object Clone()
        {
            return new Administration(this.name, this.surname, this.experience, this.salary, this.address);
        }
    }
}
