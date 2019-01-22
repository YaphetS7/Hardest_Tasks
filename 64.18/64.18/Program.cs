using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._18
{
    class Program
    {
        public static List<int> S(List<int> Q)
        {
            int k, max, i, j;
            List<int> B = new List<int>();
            for (i = 0; i < Q.Count; i++)
            {
                for (j = 0; j <= Q.Count - i - 1; j++)
                {
                    max = Q[i];
                    k = i + j;
                    for (int c = i + 1; c <= k; c++)
                    {
                        if (Q[c] >= max)
                            max = Q[c];
                    }
                    B.Add(max);
                }
            }
            return B;
        }
        static void Main()
        {
            int sum, q;
            Random rand = new Random();
            List<int> A = new List<int>();
            sum = 0;
            Console.WriteLine("Начальный список:");
            for (q = 0; q < 3; q++)
            {
                A.Add(rand.Next(0, 50));
                Console.Write(A[q] + "\t");
            }
            List<int> result = S(S(A));
            Console.WriteLine();
            for (q = 0; q < result.Count; q++)
            {
                sum += result[q];
            }
            Console.WriteLine("Ключевой ключ = " + sum);
        }
    }
}
