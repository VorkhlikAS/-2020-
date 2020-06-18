using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_6
{
    class Program
    {
        static double a1, a2, a3;
        static double Number(int n)
        {
            if (n == 1) return a1;
            else if (n == 2) return a2;
            else if (n == 3) return a3;
            else
            {
                double an = (0.7 * Number(n - 1)) - (0.2 * Number(n - 2)) + (n * Number(n - 3));
                return an;
            }



        }
        static void Main(string[] args)
        {
            int N = 0;
            bool MonotoneUP = true;
            bool MonotoneDown = true;
            a1 = GetDouble();
            a2 = GetDouble();
            a3 = GetDouble();
            while (N <= 0)
            {
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число больше 1");
                    N = 0;
                }
            }

            double last = a1;
            for (int i = 1; i <= 2 * N; i++)
            {
                double num = Number(i);
                Console.WriteLine($"{i}.{num}");

                if ((i % 2 != 0 && last > num && MonotoneUP)) MonotoneUP = false;
                if ((i % 2 != 0 && last < num && MonotoneDown)) MonotoneDown = false;

                if (i % 2 != 0) last = num;
            }
            if (MonotoneUP && a1 != a2 && a2 != a3) Console.WriteLine("Неубывающая");
            else if (MonotoneDown && a1 != a2 && a2 != a3) Console.WriteLine("Убывающая");
            else Console.WriteLine("Никакая");
            Console.ReadKey();
        }
        static double GetDouble()
        {
            bool ok = false;
            double temp = 0;
            do
            {
                try
                {
                    temp = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите действительное число");
                }
            } while (!ok);
            return temp;
        }
    }
}
