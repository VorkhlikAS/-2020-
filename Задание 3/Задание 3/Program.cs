using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Х");
            bool ok = false;
            double x = 0, y = 0;
            do
            {
                try
                {
                    x = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите действительное число");
                }
            } while (!ok);
            Console.WriteLine("Введите У");
            do
            {
                try
                {
                    y = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите действительное число");
                }
            } while (!ok);


            double f1 = (x * x) + (y * y);
            if ((f1 <= 1) && (f1 >= 0.5))
            {
                Console.WriteLine("YES");
            }
            else Console.WriteLine("NO");
        }
    }
}
