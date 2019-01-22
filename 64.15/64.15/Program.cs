using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._15
{
    public class List
    {
        List<int> list = new List<int>();
        int mid, index;
        public int bsearch(List<int> lst, int value) //двоичный поиск индекса по условию*
        {
            int low = 0;
            int high = list.Count - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (list[mid] <= value & list[mid + 1] >= value) // условие*
                    return mid + 1;
                else if (value > list[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return 0;
        }
        public void Add(int x)
        {
            if (list.Count >= 2)
            {
                if (list[list.Count - 1] > x)
                    index = bsearch(list, x);
                else
                    index = list.Count;
                list.Insert(index, x);

                Console.WriteLine("Отсортированный список list:");
                foreach (int a in list)
                    Console.Write(a + "\t");
                Console.WriteLine();
                if (list.Count % 2 != 0)
                    mid = list[list.Count / 2];
                else
                    mid = (list[(list.Count - 1) / 2] + list[(list.Count - 1) / 2 + 1]) / 2;
                if ((list[(list.Count - 1) / 2] + list[(list.Count - 1) / 2 + 1]) % 2 != 0 & list.Count % 2 == 0)
                    Console.WriteLine("Значение медианы списка = " + mid + ".5");
                else
                    Console.WriteLine("Значение медианы списка = " + mid);
                Console.WriteLine();
            }
            if (list.Count <= 1)
            {
                list.Add(x);
                list.Sort();
                Console.WriteLine("Отсортированный список list:");
                foreach (int a in list)
                    Console.Write(a + "\t");
            }
        }

        public void Del(int x)
        {
            index = list.BinarySearch(x);
            list.RemoveAt(index);
            if (list.Count >= 2)
            {
                Console.WriteLine("Список list:");
                foreach (int a in list)
                    Console.Write(a + "\t");
                list.Sort();
                Console.WriteLine();
                if (list.Count % 2 != 0)
                    mid = list[list.Count / 2];
                else
                    mid = (list[(list.Count - 1) / 2] + list[(list.Count - 1) / 2 + 1]) / 2;
                if ((list[(list.Count - 1) / 2] + list[(list.Count - 1) / 2 + 1]) % 2 != 0 & list.Count % 2 == 0)
                    Console.WriteLine("Значение медианы списка = " + mid + ".5");
                else
                    Console.WriteLine("Значение медианы списка = " + mid);
                Console.WriteLine();
            }
        }
    }
    class Program
    {
       
        static void Main()
        {
            int x, i, number;
            List q = new List();
            for (i = 1; i <= 100; i++)
            {
                Console.WriteLine("Введите 1, если хотите добавить элемент. Введите 2, если хотите удалить элемент.");
                number = Convert.ToInt32(Console.ReadLine());
                if (number == 1)
                {
                    Console.WriteLine("Введите значение элемента, который хотите добавить");
                    x = Convert.ToInt32(Console.ReadLine());
                    q.Add(x);
                    Console.WriteLine();
                }
                if (number == 2)
                {
                    Console.WriteLine("Введите значение элемента, которое хотите удалить");
                    x = Convert.ToInt32(Console.ReadLine());
                    q.Del(x);
                    Console.WriteLine();
                }
                if (number < 1 || number > 2)
                {
                    Console.WriteLine("Ошибка");
                    break;
                }
            }

        }
    }
}
