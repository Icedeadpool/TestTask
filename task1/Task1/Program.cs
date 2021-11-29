using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j = 0, k = 0;
            int p = 1;
            Console.Write("Введите n: ");
            string str = Console.ReadLine();
            int n = Convert.ToInt32(str);
            int[] a = new int[100];
            for (i = 0; i < a.Length; i++)
            {
                a[i] = p;
                p++;
                if (p > n)
                    p = 1;
            }
            i = 0;
            Console.Write("Введите m: ");
            string str1 = Console.ReadLine();
            int m = Convert.ToInt32(str1);
            int[][] path = new int[10][];
            for (j = 0; j < 10; j++)
            {
                path[j] = new int[m];
                for (k = 0; k < path[j].Length; k++)
                {
                    path[j][k] = a[i - j];
                    i++;
                }
            }
            /*for (i = 0; i < 20; i++)
                Console.Write("{0} ", a[i]);
            Console.WriteLine();
            Console.ReadKey();*/
            for (j = 0; j < 10; j++)
            {
                Console.Write("{0}", path[j][0]);
                if (path[j + 1][0] == path[0][0] & j != 0)
                    break;
            }
            Console.WriteLine();
            Console.ReadKey();
            /*for (j = 0; j < 10; j++)
            {
                for (k = 0; k < path[j].Length; k++)
                {
                    Console.Write("{0} ", path[j][k]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();*/
        }
    }
}
