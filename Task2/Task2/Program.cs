using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter circle file name: ");
            string fileName = Console.ReadLine();
            string str = File.ReadAllText(fileName).Trim();
            string[] spli = str.Replace("\r\n", ";").Split(' ', ';');
            float x0 = float.Parse(spli[0]), y0 = float.Parse(spli[1]), r = float.Parse(spli[2]);
            int answer;


            //string str = System.IO.File.OpenText(@"...\\...\\data.txt").ReadToEnd().Trim();
            Console.Write("Enter dots file name: ");
            fileName = Console.ReadLine();
            str = File.ReadAllText(fileName).Trim();
            spli = str.Replace("\r\n", ";").Replace(".",",").Split(' ', ';');
            float[,] dots = new float[spli.Length/2, 2];
            int a = 0, b = 0;
            for (int i = 0; i < spli.Length; ++i)
            {
                if (i % 2 == 0)
                {
                    //Console.Write(spli[i] + " ");

                    dots[a, 0] = float.Parse(spli[i]);
                    ++a;

                }
                else
                {
                    dots[b, 1] = float.Parse(spli[i]);
                    //Console.WriteLine(spli[i]);
                    ++b;

                }

            }
            //Console.ReadKey();


            for (int j = 0; j < spli.Length/2; j++)
            {
                int k = 0;
                float x1 = dots[j, k], y1 = dots[j, k + 1];
                double R = Math.Sqrt(Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2));
                if (R == r)
                {
                    answer = 0;
                }
                else if (R < r)
                {
                    answer = 1;
                }
                else
                {
                    answer = 2;
                }
                Console.Write("{0}\t", answer);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
