using System;
using System.Text.RegularExpressions;

namespace Hierarchy
{
    public class Person : IPerson
    {
        protected string name, surname;

        //Получение имени
        public string GetName => name;

        //Получение фамилии
        public string GetSurname => surname;

        //Конструктор без параметров
        public Person()
        {
            name = "";
            surname = "";
        }

        public string Return_name()
        {
            return name;
        }

        public string Return_se_name()
        {
            return surname;
        }

        //Конструктор с параметрами
        public Person(string Name, string Surname)
        {
            name = Name;
            surname = Surname;
        }

        //Вывод
        public virtual void Show()
        {
            Console.WriteLine(surname + " " + name);
        }

        //Ввод
        public void Input()
        {
            string[] input;
            var inputFi = "";
            var regex = new Regex(@"^[А-Я][а-я]{1,}[ ][А-Я]{1}[а-я]{1,}$");
            var ok = true;
            while (ok)
            {
                Console.Write("Введите ФИ рабочего, которого необходимо найти: ");
                inputFi = Console.ReadLine();
                if (regex.IsMatch(inputFi))
                    ok = false;
                else
                    Console.WriteLine("Введите фамилию и имя в правильном формате (Фффф Ииии)");
            }

            input = inputFi.Split(' ');

            name = input[1];
            surname = input[0];
        }
        
        //Сравнение
        public int CompareTo(object other)
        {
            Person person = other as Person;
            return String.Compare(GetSurname + " " + GetName, person.GetSurname + " " + person.GetName);
        }

        public IPerson GetSelf => new Person();

        public Person BasePerson => this;

        public IPerson Create(IPerson person)
        {
            return new Person((Person)person);
        }

        public Person(Person person)
        {
            name = person.name;
            surname = person.surname;
        }

        public override string ToString()
        {
            return surname + " " + name;
        }
    }
}
