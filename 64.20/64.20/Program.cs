using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._20
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, k, min, imin, c, m;
            imin = 0;
            c = 0;
            Random rand = new Random();
            List<int> list = new List<int>();
            List<int> reverse = new List<int>();
            Console.WriteLine("Начальный список:");
            for (i = 1; i <= 10; i++)
            {
                list.Add(rand.Next(0, 50));
                Console.Write(list[i - 1] + "\t");
            }
            Console.WriteLine();
            k = list.Count - 1;
            for (i = list.Count - 1; i >= 0; i--)
            {
                m = i;
                min = list[i];
                while (m >= 0)
                {
                    if (list[m] <= min)
                    {
                        min = list[m];
                        imin = m;
                    }
                    m--;
                }
                if (i != list.Count - 1)
                    list.Reverse(imin + 1, list.Count - imin - 1);
                list.Reverse(imin, list.Count - imin);

                k--;
                i = k + 1;
                c++;
            }
            list.Reverse();

            Console.WriteLine();
            Console.WriteLine("Отсортированный список");
            foreach (int q in list)
                Console.Write(q + "\t");
            Console.ReadLine();
        }
    }
}
