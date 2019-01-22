using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._14
{

    class Program
    {
        class Methods
        {
            int i;
            string stroka, ln;
            string[] pres = new string[1000];
            int k = 0;
            int[] find = new int[1000];

            public void Add(string s)
            {
                pres[k] = stroka;
                find[k] = 0;
                stroka = stroka + s;
                Console.WriteLine(stroka);
                k++;
            }

            public void Del(int pos)
            {
                pres[k] = stroka;
                find[k] = 0;
                ln = "";
                char[] c = new char[stroka.Length];
                for (i = 0; i < stroka.Length - pos; i++)
                {
                    c[i] = stroka[i];
                }
                for (i = 0; i < stroka.Length - pos; i++)
                    ln = ln + c[i];
                stroka = ln;
                Console.WriteLine(stroka);
                k++;
            }


            public void Print(int k)
            {
                Console.WriteLine(stroka[k]);
            }

            public void Undo()
            {
                Console.WriteLine(pres[k - 1]);
                stroka = pres[k - 1];
                if (find[k] != 1)
                    k--;
                find[k] = 1;
            }
        }
        static void Main()
        {
            Methods link = new Methods();
            string a, line;
            int j, n, check, m;
            a = "";
            char[] str = new char[1000];
            for (int i = 0; i <= 10000; i++)
            {
                m = 1;
                check = 0;
                line = Console.ReadLine();

                for (j = 0; j < line.Length; j++)
                {
                    check = check + Convert.ToInt32(line[j] - '0') * m;
                    m += 10;
                    if (j == line.Length - 1)
                        break;
                    if (line[j + 1] == ' ')
                        break;
                }

                for (j = 2; j < line.Length; j++)
                    a = a + line[j];

                if (check == 1)
                    link.Add(a);

                if (check == 2)
                {
                    n = Convert.ToInt32(a);
                    link.Del(n);
                }

                if (check == 3)
                {
                    n = Convert.ToInt32(a);
                    link.Print(n);
                }

                if (check == 4)
                    link.Undo();

                if (check < 1 || check > 4)
                {
                    Console.WriteLine("Ошибка. Команды под номером " + check + " не существует");
                    break;
                }

                a = "";



            }
        }

    }
}
