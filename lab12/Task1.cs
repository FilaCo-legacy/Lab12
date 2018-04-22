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
    в. Вывод всех корветтов с пустым боезапасом.
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
        }
        private static void PushElem(Stack curStack)
        {

        }
        private static void PrintAllTheFastest(Stack curStack)
        {

        }
        private static void CountShipsOlder1970(Stack curStack)
        {

        }
        private static void PrintAllEmptyCorvettes(Stack curStack)
        {

        }
        private static void ShowEnumCollection(Stack curStack)
        {

        }
        private static void GetClone(Stack curStack)
        {

        }
        private static Stack SortStack(Stack curStack)
        {
            return null;
        }
        private static void FindElem(Stack curStack)
        {

        }
        public static void Solve()
        {
            Intro();
            Console.WriteLine("Введите количество элементов, которые будут сгенерированы в коллекции:");
            int begLength = Program.ReadNonNegativeNum("Количество элементов");
            Stack taskCollection = GenerateStack(begLength);
            switch(Program.Menu("Выберите действие", "Добавить элемент в коллекцию", "Удалить элемент из коллекции",
                "Вывести самые быстроходные суда в коллекции", "Вывести количество судов, выпущенных ранее 1970 года",
                "Вывести все корветты с пустым боезапасом", "Перебрать элементы коллекции", "Клонировать коллекцию",
                "Отсортировать коллекцию", "Найти элемент коллекции по параметру", "Вернуться к выбору задания",
                "Выход"))
            {
                case 0:
                    PushElem(taskCollection);
                    break;
                case 1:
                    taskCollection.Pop();
                    break;
                case 2:
                    PrintAllTheFastest(taskCollection);
                    break;
                case 3:
                    CountShipsOlder1970(taskCollection);
                    break;
                case 4:
                    PrintAllEmptyCorvettes(taskCollection);
                    break;
                case 5:
                    ShowEnumCollection(taskCollection);
                    break;
                case 6:
                    GetClone(taskCollection);
                    break;
                case 7:
                    taskCollection = SortStack(taskCollection);
                    break;
                case 8:
                    FindElem(taskCollection);
                    break;
                case 9:
                    return;
                case 10:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
