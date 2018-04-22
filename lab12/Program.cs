using System;
using System.Text.RegularExpressions;

namespace lab12
{
    /// <summary>
    /// Класс, в функции Main которого начинается работа программы
    /// </summary>
    class Program
    {
        public static Random rnd = new Random();
        /// <summary>
        /// Функция проверки соотвествия строки шаблону
        /// </summary>
        /// <param name="str">Строка для проверки</param>
        /// <param name="pattern">Шаблон</param>
        /// <returns>True - строка соотвествует шаблону, иначе false</returns>
        public static bool CheckReg(string str, string pattern)
        {
            Regex reg = new Regex(pattern);
            return reg.IsMatch(str);
        }
        /// <summary>
        /// Функция отображения консольного меню
        /// </summary>
        /// <param name="headLine"> Заголовок меню</param>
        /// <param name="items"> Элементы меню</param>
        /// <returns> Номер выбранного элемента меню (нумерация с нуля) </returns>
        public static int Menu(string headLine, params string[] items)
        {
            Console.Clear();
            Console.WriteLine(headLine);
            int paragraph = 0, x = 2, y = 2, oldParagraph = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + i);
                Console.Write("{0}. {1}",i+1,items[i]);
            }
            bool choice = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + oldParagraph);
                Console.Write("{0}. {1}",oldParagraph+1, items[oldParagraph] + " ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + paragraph);
                Console.Write("{0}. {1}",paragraph+1, items[paragraph]);

                oldParagraph = paragraph;

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        paragraph++;
                        break;
                    case ConsoleKey.UpArrow:
                        paragraph--;
                        break;
                    case ConsoleKey.Enter:
                        choice = true;
                        break;
                    case ConsoleKey k when k >= ConsoleKey.D1 && k <= ConsoleKey.D9:
                        paragraph = (int)k%(int)ConsoleKey.D1;
                        choice = true;
                        break;
                    case ConsoleKey k when k >= ConsoleKey.NumPad1 && k <= ConsoleKey.NumPad9:
                        paragraph = (int)k % (int)ConsoleKey.NumPad1;
                        choice = true;
                        break;
                }
                if (paragraph >= items.Length)
                    paragraph = 0;
                else if (paragraph < 0)
                    paragraph = items.Length - 1;
                if (choice)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorVisible = true;
                    Console.Clear();
                    break;
                }
            }
            Console.Clear();
            Console.CursorVisible = true;
            return paragraph;
        }
        /// <summary>
        /// Функция ввода неотрицательного числа
        /// </summary>
        /// <param name="name">Имя вводимого параметра</param>
        /// <returns>Результат ввода с консоли - неотрицательное число</returns>
        public static int ReadNonNegativeNum(string name)
        {
            int inpNum;
            bool check = false;
            do
            {
                // Вводим целое число
                check = int.TryParse(Console.ReadLine(), out inpNum);
                // Проверка на натуральность
                if (inpNum < 0 || !check)
                    Console.WriteLine(name + " должен(но) быть неотрицательным числом, попробуйте ещё раз:");
            } while (inpNum < 0 || !check);
            return inpNum;
        }
        /// <summary>
        /// Точка старта выполнения программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                switch(Menu("Выберите задание", "Работа с коллекцией (Stack)", 
                    "Работа с обобщённой коллекцией (List<T>)", 
                    "Работа с собственной коллекцией (MySortedDictionary<T>)", "Выход"))
                {
                    case 0:
                        Task1.Solve();
                        break;
                    case 1:
                        Task2.Solve();
                        break;
                    case 2:
                        Task3.Solve();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}
