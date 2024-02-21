using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2._1
{
    class Number
    {
        public long PonigenieSt(int ee, int n, int m) //ee - степень n - модуль m - число
        {
            long c = 1;

            for (int i = 0; i < ee; i++)
            {
                long cm = c * m;

                long cc = cm % n;

                c = cc;

            }
            return c;
        }
    }
}
