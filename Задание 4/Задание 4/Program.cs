using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        static int tens = 1;
        static double f(double n)
        {
            return n * n * n * n + 2 * n * n * n - n - 1;
        }
        static int TurnInt(double a)
        {
            bool ok = false;
            do
            {
                if (a % 1 != 0)
                {
                    a = a * 10;
                    tens = tens * 10;
                }
                else ok = true;
            } while (!ok);
            int result = (int)a;
            return result;
        }
        static void Main(string[] args)
        {
            double start = 0;
            double finish = 1;
            bool ok = false;
            double e = 0;
            do
            {
                try
                {
                    e = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите действительное число");
                }
            } while (!ok);
            e = TurnInt(e);
            start = start * tens;
            finish = finish * tens;
            double middle = 0;
            double result = 1;
            while (middle % e == 0 || middle % e >= 1)
            {
                result = middle / tens;
                middle = (start + finish) / 2;
                if ((f(middle) * f(start) < 0)) finish = middle;
                else start = middle;
            }
            Console.WriteLine(result);
        }
    }
}
