using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._12
{
    class Program
    {
        static void Main()
        {

            void check(string a)
            {
                int i, y, x, c, max, min;
                y = 0;
                max = -1;
                min = 9999;
                c = 0;
                x = 1;
                int[] k = new int[a.Length];
                for (i = 0; i < k.Length; i++)
                    k[i] = 0;

                k[0] = 1;
                for (i = 1; i < a.Length; i++) // подсчет кол-ва разных букв и подсчет кол-ва одинаковых букв в массив k[]
                {
                    if (a[i] == a[i - 1])
                        k[c]++;
                    else
                    {
                        c++;
                        k[c]++;
                    }
                }
                c++;

                for (i = 0; i <= c - 1; i++) // поиск минимального и максимального кол-ва одинаковых букв
                {
                    if (k[i] <= min)
                        min = k[i];
                    if (k[i] >= max)
                        max = k[i];
                }
                x = 0;
                if ((max - min >= 2) & min != 1)
                    Console.WriteLine("Строка невалидна");
                else
                {
                    for (i = 0; i <= c - 1; i++) //подсчет кол-ва совпадающих количеств различных букв ЖD(максимумы)
                        if (max == k[i])
                            x++;
                    for (i = 0; i <= c - 1; i++) //подсчет кол-ва совпадающих количеств различных букв ЖD(минимумы)
                        if (min == k[i])
                            y++;
                }

                if (x >= y) //определяем приоритет проверки строки на валидность
                {
                    if (c - x >= 2)
                        Console.WriteLine("Строка невалидна");

                    if (x == c)
                        Console.WriteLine("Строка валидна");

                    if ((x == c - 1) & min == 1)
                        Console.WriteLine("Строка валидна");

                    if (c == 2 & max - min == 1)
                        Console.WriteLine("Строка валидна");
                }
                else
                {
                    if (c - y >= 2)
                        Console.WriteLine("Строка невалидна");

                    if (y == c)
                        Console.WriteLine("Строка валидна");

                    if ((y == c - 1) & min == 1)
                        Console.WriteLine("Строка валидна");

                    if (c == 2 & max - min == 1)
                        Console.WriteLine("Строка валидна");
                }
            }

            string stroka;
            stroka = Console.ReadLine();
            check(stroka);

        }
    }
}
