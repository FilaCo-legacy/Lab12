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
        public static void Solve()
        {
            Intro();
            Console.WriteLine("Введите количество элементов, которые будут сгенерированы в коллекции:");
            int begLength = Program.ReadNonNegativeNum("Количество элементов");
            Stack taskCollection = GenerateStack(begLength);
        }
    }
}
