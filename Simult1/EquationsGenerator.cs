using System;
using System.Collections.Generic;

namespace Simult1
{
    //   | a  b |      | x |     | m |
    //   |      |   *  |   |  =  |   |
    //   | c  d |      | y |     | n |
    //
    //   determinant = ad - bc.
    //
    //   inverse =    1    | d  -b |
    //               ---   |       |
    //                d    | -c  a |
    //

    class EquationsGenerator
    {
        private readonly Random rnd = new Random();

        private int NonZeroRandom()
        {
            var sign = (rnd.Next(0, 2) * 2) - 1;
            return rnd.Next(1, 20) * sign;
        }

        public IEnumerable<(int a, int b, int c, int d, int m, int n, double x, double y)> Generator()
        {
            while (true)
            {
                var a = NonZeroRandom();
                var b = NonZeroRandom();
                var c = NonZeroRandom();
                var d = NonZeroRandom();
                var e = NonZeroRandom();
                var m = rnd.Next(-20, 20);
                var n = rnd.Next(-20, 20);

                var det = a * d - b * c;
                if (det == 0)
                {
                    continue;
                }

                var mulx = d * m - b * n;
                var muly = -c * m + a * n;

                if (det == 2 || (mulx % det == 0 && mulx % det == 0))
                {
                    yield return (a, b, c, d, m, n, mulx / det, muly / det);
                }
            }
        }

    }
}
