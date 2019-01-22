using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._13
{
    class Program
    {
        static void Main()
        {
            int N, i, j, k, x, min, n, max, mini, maxi, p;
            k = 1;
            j = 0;
            n = 0;
            x = 0;
            maxi = 0;
            mini = 0;
            min = 32000;
            max = -1;
            bool check;
            check = false;
            int[] qs = new int[3];
            N = Convert.ToInt32(Console.ReadLine()); //считываем размер массива
            int[] arr = new int[N + 1];

            for (i = 1; i <= N; i++)
                arr[i] = Convert.ToInt32(Console.ReadLine()); //считываем сам массив


            Console.WriteLine("Начальный массив:"); // выводим начальный массив
            for (i = 1; i <= N; i++)
                Console.Write(arr[i] + "\t");

            Console.WriteLine();

            for (i = 1; i <= N; i++)
            {
                if (arr[i] < min) // поиск минимума 
                {
                    min = arr[i];
                    mini = i;
                }

                if (k <= N - 1) //подсчет длины убывания последовательности
                    if (arr[k] > arr[k + 1])
                    {
                        j++;
                        if (j <= 2) // нахождение индексов элементов массива, которые не удовлетворяют монотонности
                        {
                            if (j == 2)
                                qs[j] = i + 1;
                            else
                                qs[j] = i;
                        }
                    }

                if (arr[i] > max) // поиск максимума
                {
                    max = arr[i];
                    maxi = i;
                }
                k++;
            }

            if (j == 2) //проверка на 2 элемента, не подходящих по возрастанию
            {
                p = 0;
                arr[qs[2]] = qs[2]; //смена местами двух элементов массива
                arr[qs[1]] = qs[1];
                for (i = 1; i <= N - 1; i++)
                    if (arr[i + 1] > arr[i])
                        p++;
                if (p + 1 == N)
                {
                    Console.WriteLine("Меняем местами " + qs[1] + " и " + qs[2] + " элементы:");
                    for (i = 1; i <= N; i++)
                        Console.Write(arr[i] + "\t");
                    check = true;
                }
            }


            if (j + 1 == N)
            {
                Console.WriteLine("Меняем порядок с первого элемента по последний: ");
                for (i = N; i >= 1; i--)
                    Console.Write(arr[i] + "\t");
                check = true;
            }

            if (mini == 1 & maxi != N)
            {
                for (i = maxi; i <= N - 1; i++)
                    if (arr[i + 1] < arr[i])
                        n++;
                if (n == N - maxi)
                {
                    Console.WriteLine("Меняем порядок с " + maxi + " элемента по последний");
                    for (i = 1; i <= maxi - 1; i++)
                        Console.Write(arr[i] + "\t");
                    for (i = N; i >= maxi; i--)
                        Console.Write(arr[i] + "\t");
                    check = true;
                }
            }

            if (maxi == N & mini != 1)
            {
                for (i = 1; i <= mini - 1; i++)
                    if (arr[i + 1] < arr[i])
                        x++;
                if (x == mini - 1)
                {
                    Console.WriteLine("Меняем порядок с первого элемента по " + mini + " :");
                    for (i = mini; i >= 1; i--)
                        Console.Write(arr[i] + "\t");
                    for (i = mini + 1; i <= N; i++)
                        Console.Write(arr[i] + "\t");
                    check = true;
                }
            }
            x = 0;
            n = N;
            k = 0;
            if (mini == 1 & maxi == N & check == false)
            {
                if (x < N)
                    while (arr[x + 1] > arr[x])
                    {
                        qs[1] = x;
                        x++;
                    }
                if (n > 1)
                    while (arr[n] > arr[n - 1])
                    {
                        qs[2] = n;
                        n--;
                    }
                qs[1]++;
                qs[2]--;
                for (i = qs[1]; i <= qs[2] - (qs[2] - qs[1]) / 2 - 1; i++) // переворачиваем строку от qs[1] до qs[2]
                {
                    p = arr[i];
                    arr[i] = arr[qs[2] - k];
                    arr[qs[2] - k] = p;
                    k++;
                }
                k = 0;
                for (i = 1; i <= N - 1; i++)
                    if (arr[i + 1] > arr[i])
                        k++;
                if (k == N - 1)
                {
                    Console.WriteLine("Меняем порядок с " + qs[1] + " до " + qs[2] + " элементы:");
                    for (i = 1; i <= N; i++)
                        Console.Write(arr[i] + "\t");
                    check = true;
                }
            }

            if (!check)
                Console.WriteLine("Нельзя упорядочить");

            Console.WriteLine();
            Console.ReadLine();



        }
    }
}
