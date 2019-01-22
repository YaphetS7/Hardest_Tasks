using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._16
{
    class Program
    {
        static void Main()
        {
            int i, p, k, a;
            List<int> list = new List<int>();
            List<int> ost = new List<int>();
            List<int> del = new List<int>();
            List<int> kandidati = new List<int>();
            Random rand = new Random();
            int N = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < N; i++)
                list.Add(rand.Next(1, 11));

            foreach (int j in list)
                Console.Write(j + "\t");
            Console.WriteLine();

            ost.Add(0);
            for (i = 0; i < list.Count() - 1; i++)
            {
                if (list[i] < list[i + 1])
                {
                    del.Add(i + 1);
                }
                else
                {
                    ost.Add(i + 1);
                }

            }

            k = 1;

            while (del.Count != 0)
            {
                Console.WriteLine("Индексы удаляемых элементов на день номер " + k);
                foreach (int j in del)
                    Console.Write(j + "\t");
                Console.WriteLine();

                kandidati.Clear();

                for (i = 0; i < del.Count; i++)
                {

                    p = 0;

                    while (ost[p] < del[i])
                    {
                        p++;
                        if (p == ost.Count - 1)
                            break;
                    }
                    if (p != 0)
                        p--;


                    if (list[ost[p]] < list[ost[p + 1]] & p != 0)
                    {
                        kandidati.Add(ost[p + 1]);
                        ost.RemoveAt(p + 1);
                    }

                }
                del = kandidati.GetRange(0, kandidati.Count);
                k++;
            }

            Console.WriteLine("Всего понадобится " + (k - 1) + " дней");
        }
    }
}