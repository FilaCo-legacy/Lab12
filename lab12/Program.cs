using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    class Program
    {
        static int Menu(string headLine, params string[] paragraphs)
        {
            Console.Clear();
            Console.WriteLine(headLine);
            int paragraph = 0, x = 2, y = 2, oldParagraph = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < paragraphs.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + i);
                Console.Write(paragraphs[i]);
            }
            bool choice = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + oldParagraph);
                Console.Write(paragraphs[oldParagraph] + " ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + paragraph);
                Console.Write(paragraphs[paragraph]);

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
        }
    }
}
