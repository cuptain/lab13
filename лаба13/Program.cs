using Libriary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Hierarchy;
using System;

namespace лаба13
{
    class Program
    {
        public static TestCollections t;
        public static int Size = 1; //Размер коллекции

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            t = CreateCollection(out Size);
            string[] menu = {
                "Пересоздать коллекции", "Удалить элемент", "Добавить элемент",
                "Время поиска элемента для каждой коллекции",
                "Напечатать коллекции", "Выход"
            };
            while (true)
            {
                var sw = Use.Menu("Выберите действие:", menu);
                switch (sw)
                {
                    case 0:
                        t = CreateCollection(out Size);
                        break;
                    case 1:
                        Delete();
                        Continue();
                        break;
                    case 2:
                        Add();
                        Continue();
                        break;
                    case 3:
                        Search();
                        Continue();
                        break;
                    case 4:
                        t.Output();
                        Continue();
                        break;
                    case 5:
                        return;
                }
            }
        }

        //Создание коллекций
        static TestCollections CreateCollection(out int N)
        {
            Console.WriteLine("Введите количество элементов коллекции:");
            N = Easy.ReadNaturalNum("Количество элементов коллекции");
            TestCollections t;
            return t = new TestCollections(N);
        }

        //Добавление элемента
        public static void Add()
        {
            Console.WriteLine("Введите имя элемента, который хотите добавить (в формате целого числа):");
            int num = Easy.ReadVGran(-1, "Имя элемента");
            Worker w = TestCollections.CreateWorker(num);
            try
            {
                t.Add(w);
                Console.WriteLine("Элемент {0} добавлен в коллекции", w.GetName);
            }
            catch (Exception)
            {
                Console.WriteLine("Элемент {0} уже есть в коллекции", w.GetName);
            }          
        }

        //Удаление элемента
        public static void Delete()
        {
            Console.WriteLine("Введите имя элемента которого хотите удалить (в формате целого числа):");
            int num = Easy.ReadVGran(-1, "Имя элемента");
            Worker w = TestCollections.CreateWorker(num);
            try
            {
                t.Delete(w);
                Console.WriteLine("Элемент {0} удален из коллекции", w.GetName);
            }
            catch (Exception)
            {
                Console.WriteLine("Элемента {0} нет в коллекции", w.GetName);
            }
        }

        #region Поиск

        //Поиск элементов
        public static void Search()
        {
            int middleIndex;
            long time1, time2, time3, time4, time5, time6;
            if (Size % 2 == 1) middleIndex = Size / 2;
            else middleIndex = Size / 2 - 1;

            //Для списков
            Person pBeg = new Person(t._listPerson.First());
            string strBeg = t._listString.First();

            Person pMiddle = new Person(t._listPerson.ElementAt(middleIndex));
            string strMiddle = t._listString.ElementAt(middleIndex);

            Person pLast = new Person(t._listPerson.Last());
            string strLast = t._listString.Last();

            Person pUnexist = new Person("Афанасий", "Подмышкин");
            Worker wUnexist = new Worker("Афанасий", "Подмышкин", 300, 1488);
            string strUnexist = "боль";

            //Для словарей
            KeyValuePair<Person, Worker> dictHeritageBeg = new
                KeyValuePair<Person, Worker>(new Person(t._dictionaryHeritage.First().Key), new Worker(t._dictionaryHeritage.First().Value));
            KeyValuePair<string, Worker> dictStringBeg = new
                KeyValuePair<string, Worker>(t._dictionaryString.First().Key, new Worker(t._dictionaryString.First().Value));

            KeyValuePair<Person, Worker> dictHeritageMiddle = new
                KeyValuePair<Person, Worker>(new Person(t._dictionaryHeritage.ElementAt(middleIndex).Key), new Worker(t._dictionaryHeritage.ElementAt(middleIndex).Value));
            KeyValuePair<string, Worker> dictStringMiddle = new
                KeyValuePair<string, Worker>(t._dictionaryString.ElementAt(middleIndex).Key, new Worker(t._dictionaryString.ElementAt(middleIndex).Value));

            KeyValuePair<Person, Worker> dictHeritageLast = new
                KeyValuePair<Person, Worker>(new Person(t._dictionaryHeritage.Last().Key), new Worker(t._dictionaryHeritage.Last().Value));
            KeyValuePair<string, Worker> dictStringLast = new
                KeyValuePair<string, Worker>(t._dictionaryString.Last().Key, new Worker(t._dictionaryString.Last().Value));

            KeyValuePair<Person, Worker> dictHeritageUnexist = new KeyValuePair<Person, Worker>(new Person("Афанасий", "Подмышкин"), new Worker("Афанасий", "Подмышкин", 300, 1488));
            KeyValuePair<string, Worker> dictStringUnexist = new KeyValuePair<string, Worker>("Афанасий", new Worker("Афанасий", "Подмышкин", 300, 1488));

            Console.WriteLine("Время поиска первого элемента:");
            FindLists(t._listPerson, t._listString, pBeg, strBeg, out time1, out time2);
            FindDictionaries(t._dictionaryHeritage, t._dictionaryString, dictHeritageBeg, dictStringBeg, out time3, out time4, out time5, out time6);
            TimeShow(time1, time2, time3, time4, time5, time6);

            Console.WriteLine("\nВремя поиска элемента, находящегося в середине:");
            FindLists(t._listPerson, t._listString, pMiddle, strMiddle, out time1, out time2);
            FindDictionaries(t._dictionaryHeritage, t._dictionaryString, dictHeritageMiddle, dictStringMiddle, out time3, out time4, out time5, out time6);
            TimeShow(time1, time2, time3, time4, time5, time6);

            Console.WriteLine("\nВремя поиска последнего элемента:");
            FindLists(t._listPerson, t._listString, pLast, strLast, out time1, out time2);
            FindDictionaries(t._dictionaryHeritage, t._dictionaryString, dictHeritageLast, dictStringLast, out time3, out time4, out time5, out time6);
            TimeShow(time1, time2, time3, time4, time5, time6);

            Console.WriteLine("\nВремя поиска несуществующего элемента:");
            FindLists(t._listPerson, t._listString, pUnexist, strUnexist, out time1, out time2);
            FindDictionaries(t._dictionaryHeritage, t._dictionaryString, dictHeritageUnexist, dictStringUnexist, out time3, out time4, out time5, out time6);
            TimeShow(time1, time2, time3, time4, time5, time6);
        }

        //Поиск определённого элемента в списках
        static void FindLists(List<Person> pList, List<string> strList, Person p, string str, out long time1, out long time2)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool ok = pList.Contains(p);
            time1 = watch.ElapsedTicks;
            watch.Stop();

            watch.Restart();
            ok = strList.Contains(str);
            time2 = watch.ElapsedTicks;
        }

        //Поиск определённого элемента в словарях
        static void FindDictionaries(Dictionary<Person, Worker> dictHeritage, Dictionary<string, Worker> dictString,
                            KeyValuePair<Person, Worker> pairHeritage, KeyValuePair<string, Worker> pairString,
                            out long dictHeritageKeyTime, out long dictHeritageValueTime, out long dictStringKeyTime, 
                            out long dictStringValueTime)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool ok = dictHeritage.ContainsKey(pairHeritage.Key);
            watch.Stop();
            dictHeritageKeyTime = watch.ElapsedTicks;

            watch.Restart();
            ok = dictHeritage.ContainsValue(pairHeritage.Value);
            watch.Stop();
            dictHeritageValueTime = watch.ElapsedTicks;

            watch.Restart();
            ok = dictString.ContainsKey(pairString.Key);
            watch.Stop();
            dictStringKeyTime = watch.ElapsedTicks;

            watch.Restart();
            ok = dictString.ContainsValue(pairString.Value);
            watch.Stop();
            dictStringValueTime = watch.ElapsedTicks;
        }

        //Вывод времени
        static void TimeShow(long time1, long time2, long time3, long time4, long time5, long time6)
        {
            Console.WriteLine("List<Person>: " + time1);
            Console.WriteLine("List<string>: " + time2);
            Console.WriteLine("Dictionary<Person, Worker> (Key): " + time3);
            Console.WriteLine("Dictionary<Person, Worker> (Value): " + time4);
            Console.WriteLine("Dictionary<string, Worker> (Key): " + time5);
            Console.WriteLine("Dictionary<string, Worker> (Value): " + time6);
        }

        #endregion

        //Промежуточная функция
        public static void Continue() 
        {
            Console.WriteLine("\nДля продолжения нажмите клавишу Enter...");
            Console.CursorVisible = false;
            Console.ReadLine();
        }       
    }
}