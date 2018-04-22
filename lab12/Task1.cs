using System;
using System.Collections;
using System.Linq;
using System.Text;
using Ships;

namespace lab12
{
    class Task1
    {
        /// <summary>
        /// Процедура вывода на экран основной информации по задаче
        /// </summary>
        private static void Intro()
        {
            Console.WriteLine(@"Постановка задачи 1:

1. Создать коллекцию Stack, в которую добавить объекты иерархии классов Ships.
2. Используя меню, реализовать в программе добавление и удаление объектов коллекции.
3. Разработать и реализовать три запроса:
    а. Вывод характеристик самого быстроходного судна (всех судов, если их несколько).
    б. Вывод количества судов, которые были выпущены ранее 1970 года.
    в. Вывод всех корветов с пустым боезапасом.
4. Выполнить перебор элементов коллекции с помощью метода foreach. 
5. Выполнить клонирование коллекции.
6. Выполнить сортировку коллекции (если коллекция не отсортирована) и поиск заданного элемента в коллекции.");
            Console.WriteLine("\nДля продолжения работы нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
        }
        private static Stack GenerateStack(int length)
        {
            Stack nStack = new Stack(length * 2);
            for (int i = 0; i < length; i++)
                switch(Program.rnd.Next(0,3))
                {
                    case 0:
                        nStack.Push(new SailingShip());
                        break;
                    case 1:
                        nStack.Push(new SteamShip());
                        break;
                    case 2:
                        nStack.Push(new Corvette());
                        break;
                }
            return nStack;
        }
        private static void PrintStack(Stack curStack)
        {
            Console.WriteLine("Количество элементов в коллекции: {0}", curStack.Count);
            foreach (Ship x in curStack)
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
        private static void PushElem(Stack curStack)
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
            switch(Program.Menu("Выберите метод генерации элемента", "Ввод с клавиатуры", "С помощью ДСЧ"))
            {
                case 0:
                    InputElemFromKeyboard(nElem);
                    break;
            }
            Console.WriteLine("Добавляемый элемент:\n");
            nElem.Show();
            curStack.Push(nElem);
        }
        private static void PopElem(Stack curStack)
        {
            Console.WriteLine("Удаляемый элемент:\n");
            (curStack.Pop() as Ship).Show();
        }
        private static int MaxSpeedOfAll(Stack curStack)
        {
            int maxSpeed = -1;
            foreach (Ship x in curStack)
                if (x.MaxSpeed > maxSpeed)
                    maxSpeed = x.MaxSpeed;
            return maxSpeed;
        }
        private static void PrintAllTheFastest(Stack curStack)
        {
            int maxSpeed = MaxSpeedOfAll(curStack);
            Console.WriteLine(@"Максимальная скорость корабля в коллекции: {0} узлов
Корабли, развившие эту скорость:",maxSpeed);
            foreach (Ship x in curStack)
                if (x.MaxSpeed == maxSpeed)
                {
                    Console.WriteLine("+--------------------------------------+");
                    x.Show();
                }
            Console.WriteLine("+--------------------------------------+");
        }
        private static void CountShipsOlder1970(Stack curStack)
        {
            int count = 0;
            foreach (Ship x in curStack)
                if (DateTime.Parse(x.DateReleased) < new DateTime(1970, 1, 1))
                    count++;
            Console.WriteLine("Количество кораблей, выпущенных ранее 1970ого года: {0}", count);
        }
        private static void PrintAllEmptyCorvettes(Stack curStack)
        {
            Console.WriteLine("корветы с пустым боезапасом:");
            bool flag = false;
            foreach (Ship x in curStack)
            {
                if (x is Corvette)
                {
                    if ((x as Corvette).NumOfShells == 0)
                    {
                        Console.WriteLine("+--------------------------------------+");
                        x.Show();
                        flag = true;
                    }
                }
            }
            if (!flag)
                Console.WriteLine("Таких нет! Все корветы заряжены и готовы к бою!");
            else
            Console.WriteLine("+--------------------------------------+");
        }
        private static void EnumItems(Stack curStack)
        {
            int iter = 0;
            foreach(Ship x in curStack)
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
        private static void GetClone(Stack curStack)
        {
            switch (Program.Menu("Какую копию Вы хотите получить?", "Стандартным методом Stack.Clone()",
                "Более глубокое поэлементное клонирование"))
            {
                case 0:
                    Stack shallowClone = (Stack)curStack.Clone();
                    Console.WriteLine("Поверхностный клон коллекции:");
                    PrintStack(shallowClone);
                    break;
                case 1:
                    Stack deeperClone = new Stack(curStack.Count);
                    object[] nArr = curStack.ToArray();
                    for (int i = nArr.Length -1; i >= 0; i--)
                        deeperClone.Push((nArr[i] as Ship).ShallowClone());
                    Console.WriteLine("Клон коллекции:");
                    PrintStack(deeperClone);
                    break;
            }
        }
        private static Stack SortStack(Stack curStack)
        {
            object[] arr = curStack.ToArray();
            switch(Program.Menu("Выберите параметр для сортировки коллекции", "Максимальная скорость", "Дата выпуска"))
            {
                case 0:
                    Array.Sort(arr, new CompareByMaxSpeed());
                    break;
                case 1:
                    Array.Sort(arr, new CompareByDateReleased());
                    break;
            }
            Console.WriteLine("Результат сортировки коллекции:");
            foreach(Ship x in arr)
            {
                Console.WriteLine("+--------------------------------------+");
                x.Show();
            }
            Console.WriteLine("+--------------------------------------+");
            curStack.Clear();
            for (int i = arr.Length - 1; i >= 0; i--)
                curStack.Push(arr[i]);
            return curStack;
        }
        private static bool IsSortedByMaxSpeed(Stack curStack)
        {
            Ship prefElem = null;
            foreach(Ship x in curStack)
            {
                if (prefElem != null && prefElem.MaxSpeed > x.MaxSpeed)
                    return false;
                prefElem = x;
            }
            return true;
        }
        private static bool IsSortedByDateReleased(Stack curStack)
        {
            Ship prefElem = null;
            foreach (Ship x in curStack)
            {
                if (prefElem != null && DateTime.Parse(prefElem.DateReleased) > DateTime.Parse(x.DateReleased))
                    return false;
                prefElem = x;
            }
            return true;
        }
        private static void FindElem(Stack curStack)
        {
            int ind = -1;
            object cur = new Corvette("", "", 1, 20, 1, 1, 0);
            object[] curArr = curStack.ToArray();
            switch (Program.Menu("Выберите параметр для поиска элемента в коллекции", "Максимальная скорость", 
                "Дата выпуска"))
            {
                case 0:
                    if (!IsSortedByMaxSpeed(curStack))
                    {
                        Console.WriteLine("Коллекция не отсортирована по максимальной скорости! Отсортировать?(y/n)");
                        bool check = false;
                        while(!check)
                            switch(Console.ReadLine())
                            {
                                case string k when k == "yes" || k == "Yes" || k == "y" || k =="Y"|| k=="YES":
                                    Array.Sort(curArr, new CompareByMaxSpeed());
                                    curStack.Clear();
                                    for (int i = curArr.Length - 1; i >= 0; i--)
                                        curStack.Push(curArr[i]);
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
                    if (!IsSortedByDateReleased(curStack))
                    {
                        Console.WriteLine("Коллекция не отсортирована по дате выпуска! Отсортировать?(y/n)");
                        bool check = false;
                        while (!check)
                            switch (Console.ReadLine())
                            {
                                case string k when k == "yes" || k == "Yes" || k == "y" || k == "Y" || k == "YES":
                                    Array.Sort(curArr, new CompareByDateReleased());
                                    curStack.Clear();
                                    for (int i = curArr.Length - 1; i >= 0; i--)
                                        curStack.Push(curArr[i]);
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
            Stack taskCollection = GenerateStack(begLength);
            while (true)
            {
                switch (Program.Menu("Выберите действие", "Показать коллекцию", "Добавить элемент в коллекцию", 
                    "Удалить элемент из коллекции", "Вывести самые быстроходные суда в коллекции", 
                    "Вывести количество судов, выпущенных ранее 1970 года","Вывести все корветы с пустым боезапасом", 
                    "Перебрать элементы коллекции", "Клонировать коллекцию","Отсортировать коллекцию", 
                    "Найти элемент коллекции по параметру", "Вернуться к выбору задания","Выход"))
                {
                    case 0:
                        Console.WriteLine("Сейчас коллекция выглядит так:\n");
                        PrintStack(taskCollection);
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
                        taskCollection = SortStack(taskCollection);
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
