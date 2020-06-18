using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_8
{
    class Rebro
    {
        public string From;
        public string To;
        public Rebro()
        {
            From = "";
            To = "";
        }
        public Rebro(string from, string to)
        {
            From = from;
            To = to;
        }
        public void Show()
        {
            Console.WriteLine($"{From} - {To}");
        }
    }
}
