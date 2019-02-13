using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simult1
{
    class Program
    {

        //private static string GetVar(int x)
        //{
        //    if (x == 1)
        //    {
        //        return "x";
        //    }
        //    if (x == -1)
        //    {
        //        return "-x";
        //    }
        //    return $"{x}x";
        //}

        private static void PrintEqn(int a, int b, int c, int d, int m, int n, double x, double y)
        {
            Console.WriteLine($"{a} {b} {c} {d} {m} {n}  - {x} {y}");
        }

        private static void Main(string[] args)
        {
            try
            {
                var generator = new EquationsGenerator();
                foreach (var (a, b, c, d, m, n, x, y) in generator.Generator().Take(100))
                {
                    PrintEqn(a, b, c, d, m, n, x, y);
                }
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
