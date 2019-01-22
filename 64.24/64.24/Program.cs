using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64.FINAL_24_
{
    class Program
    {
        public static int[] change(int k, int score, int[] arr)
        {
            if (score <= k)
            {
                for (int i = score; i <= k; i += score)
                {
                    if (arr[i] == 1)
                        arr[i] = 0;
                    else
                        arr[i] = 1;
                }
            }
            if (k == score)
                return arr;
            else
                return change(k, score + 1, arr);
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int i;
            int k = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[k + 1];
            int[] ans = new int[k + 1];

            Console.WriteLine("Начальные двери в кол-ве " + k + " штук");
            for (i = 1; i <= k; i++)
            {
                arr[i] = 0;
                Console.Write(arr[i] + "\t");
                arr[i] = 1;
            }
            Console.WriteLine();
            if (k != 1)
            {
                ans = change(k, 2, arr);
                Console.WriteLine();
                Console.WriteLine("Конечное положение дверей");
                for (i = 1; i <= k; i++)
                {
                    Console.Write(ans[i] + "\t");
                    if (ans[i] == 1)
                        list.Add(i);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Конечное положение дверей");
                Console.WriteLine(0);
            }
            Console.WriteLine();
            Console.WriteLine("Номера открытых дверей:");
            foreach (int q in list)
                Console.Write(q + "\t");
            Console.ReadLine();

        }
    }
}
