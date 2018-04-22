using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    class Program
    {
        public static bool CheckReg(string str, string pattern)
        {
            Regex reg = new Regex(pattern);
            if (str == "")
                return false;
            return reg.IsMatch(str);
        }
        public static int Menu(string headLine, params string[] paragraphs)
        {
            Console.Clear();
            Console.WriteLine(headLine);
            int paragraph = 0, x = 2, y = 2, oldParagraph = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < paragraphs.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + i);
                Console.Write("{0}. {1}",i+1,paragraphs[i]);
            }
            bool choice = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + oldParagraph);
                Console.Write("{0}. {1}",oldParagraph+1, paragraphs[oldParagraph] + " ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + paragraph);
                Console.Write("{0}. {1}",paragraph+1, paragraphs[paragraph]);

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
                if (paragraph >= paragraphs.Length)
                    paragraph = 0;
                else if (paragraph < 0)
                    paragraph = paragraphs.Length - 1;
                if (choice)
                {
                    Console.ForegroundColor = ConsoleColor.White;
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
