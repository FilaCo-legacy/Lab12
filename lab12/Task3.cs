using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    class Task3
    {

        public static void Intro()
        {
            Console.WriteLine(@"Постановка задачи 3:

1. Реализовать  обобщенную коллекцию MySortedDictionary<T>. 
   Для коллекции реализовать конструкторы:
    а. public MySortedDictionary() - предназначен для создания пустой коллекции с заранее определенной 
       начальной емкостью.
    б. public MySortedDictionary (int capacity) - создает пустую коллекцию с начальной емкостью, заданной параметром 
       capacity.
    в. public MySortedDictionary (MySortedDictionary ancDict) - служит для создания коллекции, которая 
       инициализируется элементами и емкостью коллекции, заданной параметром ancDict.
    Для всех коллекций реализовать интерфейсы IEnumerable и IEnumertor.
2. Написать демонстрационную программу, в которой создаются коллекции, и демонстрируется работа всех реализованных 
   методов.");
            Console.WriteLine("\nДля продолжения работы нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
        }
        private static MySortedDictionary<Ship, Corvette> GenerateDictionary(int length)
        {
            MySortedDictionary<Ship, Corvette> nDict = new MySortedDictionary<Ship, Corvette>();
            for (int i = 0; i < length; i++)
            {
                Corvette cur = new Corvette();
                nDict.Add(new KeyValuePair<Ship, Corvette>(cur, cur));
            }
            return nDict;
        }
        private static void PrintDict(MySortedDictionary<Ship, Corvette> curDict)
        {
            Console.WriteLine("Количество элементов в коллекции: {0}", curDict.Count);
            curDict.Show();
        }
        private static void InputName(Corvette elem)
        {
            Console.WriteLine("Введите имя нового корабля (оставьте пустым для генерации с помощью ДСЧ):");
            string inpStr = Console.ReadLine();
            if (inpStr != "")
                elem.Name = inpStr;
        }
        private static void InputMaxSpeed(Corvette elem)
        {
            Console.WriteLine("Введите максимальную скорость в узлах (оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.MaxSpeed = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputDateReleased(Corvette elem)
        {
            Console.WriteLine("Введите дату выпуска корабля в формате дд/мм/гггг или дд.мм.гггг" +
                "(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.DateReleased = inpStr;
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputEnginePower(Corvette elem)
        {
            Console.WriteLine("Введите мощность двигателя парохода в л.с.(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.EnginePower = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputNumOfPipes(Corvette elem)
        {
            Console.WriteLine("Введите количество труб парохода(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.NumOfPipes = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputNumOfGuns(Corvette elem)
        {
            Console.WriteLine("Введите количество пушек корвета(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.NumOfGuns = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputNumOfShells(Corvette elem)
        {
            Console.WriteLine("Введите боезапас корвета(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.NumOfShells = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }

        private static void InputElemFromKeyboard(Corvette elem)
        {
            InputName(elem);
            InputMaxSpeed(elem);
            InputDateReleased(elem);
            InputEnginePower(elem);
            InputNumOfPipes(elem);
            InputNumOfGuns(elem);
            InputNumOfShells(elem);
        }
        private static void AddElem(MySortedDictionary<Ship, Corvette> curDict)
        {
            Corvette nElem = new Corvette();
            switch (Program.Menu("Выберите метод генерации элемента", "Ввод с клавиатуры", "С помощью ДСЧ"))
            {
                case 0:
                    InputElemFromKeyboard(nElem);
                    break;
            }
            curDict.Add(new KeyValuePair<Ship, Corvette>(nElem, nElem));
            Console.WriteLine("Добавляемый элемент:\n");
            nElem.Show();
        }
        private static void DeleteElem(MySortedDictionary<Ship, Corvette> curDict)
        {
            Ship delElem = new Corvette();
            Console.WriteLine("Введите ключ:");
            InputMaxSpeed(delElem as Corvette);
            InputDateReleased(delElem as Corvette);
            InputName(delElem as Corvette);
            Console.WriteLine("Ключ удаляемого элемента:\n");
            delElem.Show();
            if (!curDict.ContainsKey(delElem))
                Console.WriteLine("Элемента с таким ключом нет в коллекции");
            else
                curDict.Remove(delElem);

        }
        private static void EnumItems(MySortedDictionary<Ship, Corvette> curDict)
        {
            int iter = 0;
            foreach (Ship x in curDict)
            {
                Console.WriteLine("Корабль №{0}", iter + 1);
                Console.WriteLine("+--------------------------------------+");
                x.Show();
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("Нажмите стрелку \"вправо\" для того, чтобы перейти к следующему элементу\n" +
                    "Нажмите ESC, чтобы выйти из перебора");
                bool flag = false;
                while (!flag)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.RightArrow:
                            flag = true;
                            break;
                        case ConsoleKey.Escape:
                            return;
                    }
                }
                iter++;
                Console.Clear();
            }
        }
        private static void GetClone(MySortedDictionary<Ship, Corvette> curDict)
        {
            Console.WriteLine("Поверхностный клон коллекции:");
            PrintDict((MySortedDictionary<Ship,Corvette>)curDict.Clone());
        }
        private static void FindElem(MySortedDictionary<Ship, Corvette> curDict)
        {
            Ship findElem = new Corvette();
            Console.WriteLine("Введите ключ:");
            InputMaxSpeed(findElem as Corvette);
            InputDateReleased(findElem as Corvette);
            InputName(findElem as Corvette);
            Console.WriteLine("Ключ искомого элемента:\n");
            findElem.Show();
            Console.WriteLine("Искомый элемент:");
            if (curDict[findElem] != null)
                curDict[findElem].Show();
        }
        public static void Solve()
        {
            Intro();
            Console.WriteLine("Введите количество элементов, которые будут сгенерированы в коллекции:");
            int begLength = Program.ReadNonNegativeNum("Количество элементов");
            MySortedDictionary<Ship, Corvette> taskCollection = GenerateDictionary(begLength);
            while (true)
            {
                switch (Program.Menu("Выберите действие", "Показать коллекцию", "Добавить элемент в коллекцию",
                    "Удалить элемент из коллекции", "Вывести все возможные ключи", "Вывести все возможные значения",
                    "Перебрать элементы коллекции", "Клонировать коллекцию", 
                    "Найти элемент коллекции по ключу", "Вернуться к выбору задания", "Выход"))
                {
                    case 0:
                        Console.WriteLine("Сейчас коллекция выглядит так:\n");
                        PrintDict(taskCollection);
                        break;
                    case 1:
                        AddElem(taskCollection);
                        break;
                    case 2:
                        DeleteElem(taskCollection);
                        break;
                    case 3:
                        foreach (Ship x in taskCollection.Keys)
                            x.Show();
                        break;
                    case 4:
                        foreach (Corvette x in taskCollection.Values)
                            x.Show();
                        break;
                    case 5:
                        EnumItems(taskCollection);
                        break;
                    case 6:
                        GetClone(taskCollection);
                        break;
                    case 7:
                        FindElem(taskCollection);
                        break;
                    case 8:
                        return;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("\nДля продолжения работы нажмите Enter...");
                Console.ReadLine();
            }
        }
    }
}
