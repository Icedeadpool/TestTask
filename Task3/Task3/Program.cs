using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public class Value3
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Value { get; set; }
        }

        public class Value2
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Value { get; set; }
            public List<Value3> Values { get; set; }
        }

        public class Value1
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Value { get; set; }
            public List<Value2> Values { get; set; }
        }

        public class Test
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Value { get; set; }
            public List<Value1> Values { get; set; }
        }

        public class Root1
        {
            public List<Test> Tests { get; set; }
        }

        public class Values
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        public class Root2
        {
            public List<Values> Values { get; set; }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Tests file name: ");
            string fileName1 = Console.ReadLine();
            var data1 = File.ReadAllText(fileName1);
            var test = JsonConvert.DeserializeObject<Root1>(data1);

            Console.Write("Enter Values file name: ");
            string fileName2 = Console.ReadLine();
            var data2 = File.ReadAllText(fileName2);
            var vals = JsonConvert.DeserializeObject<Root2>(data2);

            int i, j, k, p, c;
            for (i = 0; i < test.Tests.Count; i++)
            {
                for (j = 0; j < vals.Values.Count;)
                {
                    if (test.Tests[i].Id == vals.Values[j].Id)
                    {
                        test.Tests[i].Value = vals.Values[i].Value;
                        j++;
                    }
                    else j++;
                }
                if (test.Tests[i].Values != null)
                for (k = 0; k < test.Tests[i].Values.Count; k++)
                {
                    for (j = 0; j < vals.Values.Count;)
                    {
                        if (test.Tests[i].Values[k].Id == vals.Values[j].Id)
                        {
                            test.Tests[i].Values[k].Value = vals.Values[i].Value;
                            j++;
                        }
                        else j++;
                    }
                        if (test.Tests[i].Values[k].Values != null)
                            for (p = 0; p < test.Tests[i].Values[k].Values.Count; p++)
                        {
                                for (j = 0; j < vals.Values.Count;)
                                {
                                    if (test.Tests[i].Values[k].Values[p].Id == vals.Values[j].Id)
                                    {
                                        test.Tests[i].Values[k].Values[p].Value = vals.Values[i].Value;
                                        j++;
                                    }
                                    else j++;
                                }
                                if (test.Tests[i].Values[k].Values[p].Values != null)
                                    for (c = 0; c < test.Tests[i].Values[k].Values[p].Values.Count; c++)
                                    {
                                        for (j = 0; j < vals.Values.Count;)
                                        {
                                            if (test.Tests[i].Values[k].Values[p].Values[c].Id == vals.Values[j].Id)
                                            {
                                                test.Tests[i].Values[k].Values[p].Values[c].Value = vals.Values[i].Value;
                                                j++;
                                            }
                                            else j++;
                                        }
                                    }
                        }
                }
            }
            var report = JsonConvert.SerializeObject(test);
            report = report.Replace(",\"Values\":null", null).Replace(",\"Value\":null", null);
            report = report.Replace(",\"", ", \"").Replace("\":", "\": ").Replace("},{", "},\r\n{");
            report = report.Replace(": [", ": \r\n[");
            //Console.WriteLine(report);
            //Console.ReadKey();
            Console.Write("Enter new file path and name: ");
            string NewFile = Console.ReadLine();
            File.WriteAllText(@NewFile, report);
            Console.Write("File created. Press any key to exit the program.");
            Console.ReadKey();
        }
    }
}
