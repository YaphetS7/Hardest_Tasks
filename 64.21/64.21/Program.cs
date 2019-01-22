using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._21
{
    class Program
    {
        public static void check(List<int> list)
        {
            int i, q, temp, index;
            byte plus;
            string s;
            temp = 1;
            byte[] arr = new byte[4001];
            for (i = 0; i < list.Count; i++)
            {
                plus = 1;
                while (list[i] > temp * 8)
                    temp++;
                index = list[i] - (temp - 1) * 8;
                s = Convert.ToString(arr[temp], 2);
                while (s.Length < 8)
                    s = '0' + s;
                if (s[s.Length - index] == '1')
                    Console.WriteLine(index + (temp - 1) * 8);
                else
                {
                    for (q = 1; q < index; q++)
                        plus *= 2;
                    arr[temp] += plus;
                }
                s = "";
                temp = 1;
            }


        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 9; i++)
                list.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Начальный список:");
            foreach (int q in list)
                Console.Write(q + "\t");
            Console.WriteLine();
            Console.WriteLine("Повторяющиеся значения:");
            check(list);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
