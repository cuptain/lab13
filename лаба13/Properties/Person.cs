using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    abstract class Person : IPerson, IComparable
    {
        public string name, surname;

        //Получение имени
        public string GetName
        {
            get { return name; }
        }

        //Получение фамилии
        public string GetSurname
        {
            get { return surname; }
        }

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
        abstract public void Input();
        
        //Сравнение
        public int CompareTo(object other)
        {
            Person person = other as Person;
            return String.Compare(GetSurname + " " + GetName, person.GetSurname + " " + person.GetName);
        }
    }
}
