using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static List<string> generateParenthesis(int n)
    {
        List<string> result = new List<string>();
        //StringBuilder s = new StringBuilder();
        generate(n, 0, 0, "", result);
        return result;
    }
    public static void generate(int n, int left, int right, string s, List<string> result)
    {
        //left is num of '(' and right is num of ')'
        if (left < right)
        {
            return;
        }
        if (left == n && right == n)
        {
            result.Add(s);
            return;
        }
        if (left == n)
        {
            //add ')' only.
            generate(n, left, right + 1, s + ")", result);
            return;
        }
        generate(n, left + 1, right, s + "(", result);
        generate(n, left, right + 1, s + ")", result);
    }


    public static void Main(string[] args)
    {
        // TODO Auto-generated method stub
        Console.WriteLine("Введите начальное кол-во скобок");
        int x = Convert.ToInt32(Console.ReadLine());
        foreach (string i in generateParenthesis(x))
            Console.WriteLine(i + "\t");
        Console.ReadLine();

    }
}

