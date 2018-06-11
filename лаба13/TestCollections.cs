using System;
using System.Collections.Generic;
using System.Diagnostics;
using Libriary;
using Hierarchy;

namespace лаба13
{
    class TestCollections
    {
        public Dictionary<Person, Worker> _dictionaryHeritage { get; } //<TKey/TValue>
        public Dictionary<string, Worker> _dictionaryString { get; } //<string/TValue>
        public List<Person> _listPerson { get; } //<TKey>
        public List<string> _listString { get; } //<string>

        public static Random rnd = new Random(); //random

        public TestCollections(int size) //Создание коллекции
        {
            _listPerson = new List<Person>();
            _listString = new List<string>();
            _dictionaryHeritage = new Dictionary<Person, Worker>(size);
            _dictionaryString = new Dictionary<string, Worker>(size);

            for (int count = 0; count < size; count++)
            {
                Worker w = CreateWorker(count);
                Person p = new Person(w.GetName, w.GetSurname);
                _listPerson.Add(p);
                _dictionaryHeritage.Add(p, w);
                _listString.Add(w.GetName.ToString());
                _dictionaryString.Add(w.GetName.ToString(), w);
            }
        }

        public static Worker CreateWorker(int a) //Создание рабочего
        {
            int key = a.GetHashCode();
            if (key < 0) key = Math.Abs(key);
            Worker w = new Worker(String.Format("n{0}", key), String.Format("s{0}", key),
                rnd.Next(1, 50), rnd.Next(10, 21) * 1000);
            return w;
        }

        //Добавить элемент
        public void Add(Worker w)
        {
            bool ok = _listString.Contains(w.GetName.ToString());
            if (!ok)
            {
                Person p = new Person(w.GetName, w.GetSurname);
                _listPerson.Add(p);
                _dictionaryHeritage.Add(p, w);

                _listString.Add(w.GetName.ToString());
                _dictionaryString.Add(w.GetName.ToString(), w);
            }
            else throw new Exception();
        }

        //Удалить элемент
        public void Delete(Worker w)
        {
            bool ok = _listString.Contains(w.GetName.ToString());
            if (ok)
            {
                Person p = new Person(w.GetName, w.GetSurname);
                _listPerson.Remove(p);
                _dictionaryHeritage.Remove(p);

                _listString.Remove(w.GetName.ToString());
                _dictionaryString.Remove(w.GetName.ToString());
            }
            else throw new Exception();
        }

        //Вывести элементы коллекции
        public void Output()
        {
            Console.WriteLine("List<Person>:");
            foreach (Person p in _listPerson)
                p.Show();

            Console.WriteLine();
            Console.WriteLine("List<String>:");
            foreach (string str in _listString)
                Console.WriteLine(str);

            Console.WriteLine();
            Console.WriteLine("Dictionary<Person, Worker>:");
            foreach (KeyValuePair<Person, Worker> str in _dictionaryHeritage)
                Console.WriteLine("Ключ: {0} \n Значение: {1}", str.Key, str.Value);

            Console.WriteLine();
            Console.WriteLine("Dictionary<String, Worker>:");
            foreach (KeyValuePair<string, Worker> str in _dictionaryString)
                Console.WriteLine("Ключ: {0} \n Значение: {1}", str.Key, str.Value);
        }
             
    }
}
