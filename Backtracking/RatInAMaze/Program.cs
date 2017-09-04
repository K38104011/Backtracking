using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatInAMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            var rm = new RatMaze(new [,]
            {
                {1, 0, 0, 0},
                {1, 1, 1, 1},
                {0, 1, 0, 0},
                {1, 1, 1, 1}
            });
            rm.PrintResult();
            Console.ReadKey();
        }
    }
}
