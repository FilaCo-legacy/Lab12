using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    class Task2
    {
        public static void Intro()
        {
            Console.WriteLine(@"Постановка задачи 2:

1. Создать обобщенную  коллекцию List<T>, в которую добавить объекты иерархии классов Ships.
2. Используя меню, реализовать в программе добавление и удаление объектов коллекции.
3. Разработать и реализовать три запроса:
    а. Вывод характеристик самого быстроходного судна (всех судов, если их несколько).
    б. Вывод количества судов, которые были выпущены ранее 1970 года.
    в. Вывод всех корветтов с пустым боезапасом.
4. Выполнить перебор элементов коллекции с помощью метода foreach. 
5. Выполнить клонирование коллекции.
6. Выполнить сортировку коллекции (если коллекция не отсортирована) и поиск заданного элемента в коллекции.");
            Console.WriteLine("\nДля продолжения работы нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
        }
        private static List<Ship> GenerateList(int length)
        {
            List<Ship> nList = new List<Ship>(length * 2);
            for (int i = 0; i < length; i++)
                switch (Program.rnd.Next(0, 3))
                {
                    case 0:
                        nList.Add(new SailingShip());
                        break;
                    case 1:
                        nList.Add(new SteamShip());
                        break;
                    case 2:
                        nList.Add(new Corvette());
                        break;
                }
            return nList;
        }
        private static void PrintList(List<Ship> curList)
        {
            Console.WriteLine("Количество элементов в коллекции: {0}", curList.Count);
            foreach (Ship x in curList)
            {
                Console.WriteLine("+--------------------------------------+");
                x.Show();
            }
            Console.WriteLine("+--------------------------------------+");
        }
        private static void InputName(Ship elem)
        {
            Console.WriteLine("Введите имя нового корабля (оставьте пустым для генерации с помощью ДСЧ):");
            string inpStr = Console.ReadLine();
            if (inpStr != "")
                elem.Name = inpStr;
        }
        private static void InputMaxSpeed(Ship elem)
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
        private static void InputDateReleased(Ship elem)
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
        private static void InputEnginePower(SteamShip elem)
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
        private static void InputNumOfPipes(SteamShip elem)
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
        private static void InputNumOfSails(SailingShip elem)
        {
            Console.WriteLine("Введите количество парусов корабля(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.NumOfSails = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputNumOfMasts(SailingShip elem)
        {
            Console.WriteLine("Введите кол-во мачт парусника(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.NumOfMasts = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputElemFromKeyboard(Ship elem)
        {
            InputName(elem);
            InputMaxSpeed(elem);
            InputDateReleased(elem);
            if (elem is SteamShip)
            {
                InputEnginePower(elem as SteamShip);
                InputNumOfPipes(elem as SteamShip);
                if (elem is Corvette)
                {
                    InputNumOfGuns(elem as Corvette);
                    InputNumOfShells(elem as Corvette);
                }
            }
            if (elem is SailingShip)
            {
                InputNumOfSails(elem as SailingShip);
                InputNumOfMasts(elem as SailingShip);
            }
        }
        private static int InputPos(List<Ship> curList)
        {
            bool check = false;
            int pos;
            do
            {
                check = Int32.TryParse(Console.ReadLine(), out pos);
                if (!check || pos < 1 || pos > curList.Count)
                {
                    Console.WriteLine("Позиция должна быть натуральным числом");
                    check = false;
                }
            } while (!check);
            return pos;
        }
        private static void AddOnPos(List<Ship> curList, Ship nElem)
        {
            Console.WriteLine("Введите позицию, на которую необходимо добавить элемент:");
            int pos = InputPos(curList);
            List<Ship> nList = new List<Ship>(curList.Capacity + 1);
            nList.AddRange(curList.GetRange(0, pos));
            nList.Add(nElem);
            nList.AddRange(curList.GetRange(pos, curList.Count - pos));
            curList = nList;
        }
        private static void AddElem(List<Ship> curList)
        {
            Ship nElem = null;
            switch (Program.Menu("Выберите тип добавляемого элемента", "Пароход", "Парусник", "Корвет"))
            {
                case 0:
                    nElem = new SteamShip();
                    break;
                case 1:
                    nElem = new SailingShip();
                    break;
                case 2:
                    nElem = new Corvette();
                    break;
            }
            switch (Program.Menu("Выберите метод генерации элемента", "Ввод с клавиатуры", "С помощью ДСЧ"))
            {
                case 0:
                    InputElemFromKeyboard(nElem);
                    break;
            }
            switch(Program.Menu("Выберите место вставки элемента", "В начало", "В конец", "На позицию"))
            {
                case 0:
                    List<Ship> nList = new List<Ship>(curList.Capacity + 1);
                    nList.Add(nElem);
                    nList.AddRange(curList);
                    break;
                case 1:
                    curList.Add(nElem);
                    break;
                case 2:
                    AddOnPos(curList, nElem);
                    break;
            }
            Console.WriteLine("Добавляемый элемент:\n");
            nElem.Show();
        }
        private static void DeleteElem(List<Ship> curList)
        {
            Ship delElem = null;
            switch(Program.Menu("Каким образом выбрать удаляемый элемент?", "Позиция","Значение"))
            {
                case 0:
                    Console.WriteLine("Введите позицию, с которой необходимо удалить элемент");
                    int pos = InputPos(curList);
                    Console.WriteLine("Удаляемый элемент:\n");
                    curList[pos - 1].Show();
                    curList.RemoveAt(pos - 1);
                    break;
                case 1:
                    InputElemFromKeyboard(delElem);
                    Console.WriteLine("Удаляемый элемент:\n");
                    delElem.Show();
                    if (!curList.Remove(delElem))
                        Console.WriteLine("Элемента с такими полями нет в коллекции");
                    break;
            }
        }
        private static int MaxSpeedOfAll(List<Ship> curList)
        {
            int maxSpeed = -1;
            foreach (Ship x in curList)
                if (x.MaxSpeed > maxSpeed)
                    maxSpeed = x.MaxSpeed;
            return maxSpeed;
        }
        private static void PrintAllTheFastest(List<Ship> curList)
        {
            int maxSpeed = MaxSpeedOfAll(curList);
            Console.WriteLine(@"Максимальная скорость корабля в коллекции: {0} узлов
Корабли, развившие эту скорость ({1} штук):", maxSpeed, curList.Count(x=>x.MaxSpeed==maxSpeed));
            foreach (Ship x in curList.FindAll(x=>x.MaxSpeed==maxSpeed))
            {
                Console.WriteLine("+--------------------------------------+");
                x.Show();
            }
            Console.WriteLine("+--------------------------------------+");
        }
        private static void CountShipsOlder1970(List<Ship> curList)
        {
            Console.WriteLine("Количество кораблей, выпущенных ранее 1970ого года: {0}", 
                curList.Count(x=> DateTime.Parse(x.DateReleased) < new DateTime(1970, 1, 1)));
        }
        private static void PrintAllEmptyCorvettes(List<Ship> curList)
        {
            Console.WriteLine("Корветы с пустым боезапасом:");
            if (curList.Count(x => x is Corvette && (x as Corvette).NumOfShells == 0) == 0)
                Console.WriteLine("Таких нет! Все корветы заряжены и готовы к бою!");
            else
            {
                foreach (Corvette x in curList.FindAll(x => x is Corvette && (x as Corvette).NumOfShells == 0))
                {
                    Console.WriteLine("+--------------------------------------+");
                    x.Show();
                }                
                Console.WriteLine("+--------------------------------------+");
            }
        }
        private static void EnumItems(List<Ship> curList)
        {
            int iter = 0;
            foreach (Ship x in curList)
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
        private static void GetClone(List<Ship> curList)
        {
            switch (Program.Menu("Какую копию Вы хотите получить?", "Стандартным методом List.Clone()",
                "Более глубокое поэлементное клонирование"))
            {
                case 0:
                    List<Ship> shallowClone = (List<Ship>)curList.Clone();
                    Console.WriteLine("Поверхностный клон коллекции:");
                    PrintList(shallowClone);
                    break;
                case 1:
                    List deeperClone = new List(curList.Count);
                    object[] nArr = curList.ToArray();
                    for (int i = nArr.Length - 1; i >= 0; i--)
                        deeperClone.Push((nArr[i] as Ship).ShallowClone());
                    Console.WriteLine("Клон коллекции:");
                    PrintList(deeperClone);
                    break;
            }
        }
        private static List SortList(List curList)
        {
            object[] arr = curList.ToArray();
            switch (Program.Menu("Выберите параметр для сортировки коллекции", "Максимальная скорость", "Дата выпуска"))
            {
                case 0:
                    Array.Sort(arr, new CompareByMaxSpeed());
                    break;
                case 1:
                    Array.Sort(arr, new CompareByDateReleased());
                    break;
            }
            Console.WriteLine("Результат сортировки коллекции:");
            foreach (Ship x in arr)
            {
                Console.WriteLine("+--------------------------------------+");
                x.Show();
            }
            Console.WriteLine("+--------------------------------------+");
            curList.Clear();
            for (int i = arr.Length - 1; i >= 0; i--)
                curList.Push(arr[i]);
            return curList;
        }
        private static bool IsSortedByMaxSpeed(List curList)
        {
            Ship prefElem = null;
            foreach (Ship x in curList)
            {
                if (prefElem != null && prefElem.MaxSpeed > x.MaxSpeed)
                    return false;
                prefElem = x;
            }
            return true;
        }
        private static bool IsSortedByDateReleased(List curList)
        {
            Ship prefElem = null;
            foreach (Ship x in curList)
            {
                if (prefElem != null && DateTime.Parse(prefElem.DateReleased) > DateTime.Parse(x.DateReleased))
                    return false;
                prefElem = x;
            }
            return true;
        }
        private static void FindElem(List curList)
        {
            int ind = -1;
            object cur = new Corvette("", "", 1, 20, 1, 1, 0);
            object[] curArr = curList.ToArray();
            switch (Program.Menu("Выберите параметр для поиска элемента в коллекции", "Максимальная скорость",
                "Дата выпуска"))
            {
                case 0:
                    if (!IsSortedByMaxSpeed(curList))
                    {
                        Console.WriteLine("Коллекция не отсортирована по максимальной скорости! Отсортировать?(y/n)");
                        bool check = false;
                        while (!check)
                            switch (Console.ReadLine())
                            {
                                case string k when k == "yes" || k == "Yes" || k == "y" || k == "Y" || k == "YES":
                                    Array.Sort(curArr, new CompareByMaxSpeed());
                                    curList.Clear();
                                    for (int i = curArr.Length - 1; i >= 0; i--)
                                        curList.Push(curArr[i]);
                                    check = true;
                                    break;
                                case string k when k == "no" || k == "No" || k == "n" || k == "N" || k == "NO":
                                    Console.WriteLine("Извините, но поиск в неотсортированной коллекции невозможен");
                                    return;
                                default:
                                    Console.WriteLine("Коллекция не отсортирована по максимальной скорости! " +
                                        "Отсортировать?(y/n)");
                                    break;
                            }
                    }
                    Console.WriteLine("Введите искомую максимальную скорость");
                    while (true)
                    {
                        try
                        {
                            (cur as Ship).MaxSpeed = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    ind = Array.BinarySearch(curArr, cur, new CompareByMaxSpeed());
                    break;
                case 1:
                    if (!IsSortedByDateReleased(curList))
                    {
                        Console.WriteLine("Коллекция не отсортирована по дате выпуска! Отсортировать?(y/n)");
                        bool check = false;
                        while (!check)
                            switch (Console.ReadLine())
                            {
                                case string k when k == "yes" || k == "Yes" || k == "y" || k == "Y" || k == "YES":
                                    Array.Sort(curArr, new CompareByDateReleased());
                                    curList.Clear();
                                    for (int i = curArr.Length - 1; i >= 0; i--)
                                        curList.Push(curArr[i]);
                                    check = true;
                                    break;
                                case string k when k == "no" || k == "No" || k == "n" || k == "N" || k == "NO":
                                    Console.WriteLine("Извините, но поиск в неотсортированной коллекции невозможен");
                                    return;
                                default:
                                    Console.WriteLine("Коллекция не отсортирована по дате выпуска! Отсортировать?(y/n)");
                                    break;
                            }
                    }
                    Console.WriteLine("Введите искомую дату выпуска");
                    while (true)
                    {
                        try
                        {
                            (cur as Ship).DateReleased = Console.ReadLine();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    ind = Array.BinarySearch(curArr, cur, new CompareByDateReleased());
                    break;
            }
            if (ind < 0)
                Console.WriteLine("Элемент с такими параметрами отсутствует");
            else
            {
                Console.WriteLine("Элемент, удовлетворяющий заданным параметрам:");
                Console.WriteLine("+--------------------------------------+");
                (curArr[ind] as Ship).Show();
                Console.WriteLine("+--------------------------------------+");
            }
        }
        public static void Solve()
        {
            Intro();
            Console.WriteLine("Введите количество элементов, которые будут сгенерированы в коллекции:");
            int begLength = Program.ReadNonNegativeNum("Количество элементов");
            List taskCollection = GenerateList(begLength);
            while (true)
            {
                switch (Program.Menu("Выберите действие", "Показать коллекцию", "Добавить элемент в коллекцию",
                    "Удалить элемент из коллекции", "Вывести самые быстроходные суда в коллекции",
                    "Вывести количество судов, выпущенных ранее 1970 года", "Вывести все корветы с пустым боезапасом",
                    "Перебрать элементы коллекции", "Клонировать коллекцию", "Отсортировать коллекцию",
                    "Найти элемент коллекции по параметру", "Вернуться к выбору задания", "Выход"))
                {
                    case 0:
                        Console.WriteLine("Сейчас коллекция выглядит так:\n");
                        PrintList(taskCollection);
                        break;
                    case 1:
                        PushElem(taskCollection);
                        break;
                    case 2:
                        PopElem(taskCollection);
                        break;
                    case 3:
                        PrintAllTheFastest(taskCollection);
                        break;
                    case 4:
                        CountShipsOlder1970(taskCollection);
                        break;
                    case 5:
                        PrintAllEmptyCorvettes(taskCollection);
                        break;
                    case 6:
                        EnumItems(taskCollection);
                        break;
                    case 7:
                        GetClone(taskCollection);
                        break;
                    case 8:
                        taskCollection = SortList(taskCollection);
                        break;
                    case 9:
                        FindElem(taskCollection);
                        break;
                    case 10:
                        return;
                    case 11:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("\nДля продолжения работы нажмите Enter...");
                Console.ReadLine();
            }
        }
    }
}
