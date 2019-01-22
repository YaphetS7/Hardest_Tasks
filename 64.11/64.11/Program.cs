using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._11
{
    class Program
    {



        static void Main()
        {
            Random rand = new Random();
            int[] randarr(int Q) //заполняем массив рандомными значениями от 1 до N 
            {
                int w, t, u, p;
                int[] arr1 = new int[Q + 1];
                for (w = 1; w <= Q; w++) // заполнение массива от 1 до N последовательно
                    arr1[w] = w;

                for (w = 1; w <= 10000; w++) // перемешивание массива
                {
                    t = arr1[2];
                    u = rand.Next(1, Q + 1);
                    arr1[2] = arr1[u];
                    arr1[u] = t;
                }
                return arr1;
            }


            int k, i, j, N, z, x, y, c, min, n, g;
            bool check;
            min = 0;
            c = 0;
            check = false;
            N = Convert.ToInt32(Console.ReadLine()); //считываем размер массива
            int[] arr = new int[N + 1];
            arr = randarr(N);

            for (i = 1; i <= N; i++)
                Console.Write(arr[i] + "\t");
            Console.WriteLine();

            for (n = 1; n <= N; n++)
                for (i = 1; i <= N - 2; i++)
                {
                    z = arr[i]; // первый элемент для проверки
                    x = arr[i + 1]; // второй элемент для проверки
                    y = arr[i + 2]; // третий элемент для проверки

                    if (z < x & z < y)    // нахождение минимума среди трех элементов
                        min = z;
                    if (x < z & x < y)
                        min = x;
                    if (y < x & y < z)
                        min = y;


                    for (j = 1; j <= 3; j++) // имитирование сдвига элементов влево
                    {
                        if (min == z) // присваивание минимального значения самому левому индексу
                        {
                            arr[i] = z;
                            arr[i + 1] = x;
                            arr[i + 2] = y;
                            break;
                        }
                        c = z;
                        z = x;
                        x = y;
                        y = c;
                    }
                    for (k = 1; k <= N; k++)
                    {
                        if (arr[k] != k)
                            break;
                        if (k == N)
                            check = true;
                    }
                    if (check)
                        break;
                }

            if (check)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");



        }
    }
}
