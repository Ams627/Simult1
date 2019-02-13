using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simult1
{
    class Program
    {

        private static char GetSign(int x)
        {
            return x < 0 ? '-' : '+';
        }

        private static string GetVar(int x)
        {
            if (x == 1 || x == -1)
            {
                return "";
            }
            return $"{x}";
        }

        private static void PrintEqn(int a, int b, int c, int d, int m, int n, double x, double y)
        {
            Console.WriteLine($"| {GetVar(a)}x {GetSign(b)} {GetVar(Math.Abs(b))}y = {m} | {GetVar(c)}x {GetSign(d)} {GetVar(Math.Abs(d))}y = {n}  | {x} {y}");
        }

        private static void Main(string[] args)
        {
            try
            {
                var generator = new EquationsGenerator();
                Console.WriteLine("|===");

                foreach (var (a, b, c, d, m, n, x, y) in generator.Generator().Take(100))
                {
                    PrintEqn(a, b, c, d, m, n, x, y);
                }
                Console.WriteLine("|===");
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
