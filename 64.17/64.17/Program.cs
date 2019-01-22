using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._17
{

    class Program
    {

        static void swap(ref int q, ref int b)
        {
            int c;
            c = q;
            q = b;
            b = c;
        }

        static void Main(string[] args)
        {
            int j, N, M, i, k, min;
            k = 1;
            M = Convert.ToInt32(Console.ReadLine());
            N = Convert.ToInt32(Console.ReadLine());
            int[,] a = new int[M + 1, N + 1];
            for (i = 0; i < M; i++)
                for (j = 0; j < N; j++)
                {
                    a[i, j] = k;
                    k++;
                    if (j == N - 1)
                        k = i + 2;
                    if (k >= 10)
                        k = 0;
                }
            Console.WriteLine("Начальный массив: ");
            for (i = 0; i < M; i++)
                for (j = 0; j < N; j++)
                {
                    Console.Write(a[i, j] + "\t");
                    if (j == N - 1)
                        Console.WriteLine();
                }

            if (M <= N)
                min = M;
            else
                min = N;


            for (i = 0; i < min / 2; i++)
            {
                int temp;
                temp = a[i, i];
                j = i;
                k = i;
                for (; j < N - i - 1; j++)
                {
                    swap(ref temp, ref a[k, j]);
                }
                for (; k < M - i - 1; k++)
                {
                    swap(ref temp, ref a[k, j]);
                }
                for (; j > i; j--)
                {
                    swap(ref temp, ref a[k, j]);
                }
                for (; k > i; k--)
                {
                    swap(ref temp, ref a[k, j]);
                }
                a[i, i] = temp;
            }



            Console.WriteLine("Конечный массив");
            for (i = 0; i < M; i++)
                for (j = 0; j < N; j++)
                {
                    Console.Write(a[i, j] + "\t");
                    if (j == N - 1)
                        Console.WriteLine();
                }


        }
    }
}
