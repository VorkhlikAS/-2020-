using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_10
{
    class List
    {
        public double number;
        public List next;

        public List(double val)
        {
            number = val;
        }
        public void Show()
        {
            Console.WriteLine(number);
        }
    }
}
