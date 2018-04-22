using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void Solve()
        {
            Intro();

        }
    }
}
