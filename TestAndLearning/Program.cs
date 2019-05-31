using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAndLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 30; i++)
            {
                for (int j = 1; j < 30; j++)
                {
                    if(i == j) continue;

                    double firstParam = (double)i / 10;
                    double secondParam = (double)j / 10;

                    var output = FindBetterParameter.CompareParameters(100, firstParam, secondParam);
                    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "results.txt"), output);
                }
            }

        }


    }
}
