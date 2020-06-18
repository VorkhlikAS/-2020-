using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_10
{
    class Program
    {
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
        static List Itteration(int n)
        {
            if (n == 0) return null;
            else
            {
                double val = GetDouble();
                List vectorN = new List(val);
                vectorN.next = Itteration(n - 1);
                return vectorN;
            }
        }
        static void ShowVector(List vector)
        {
            if (vector != null)
            {
                vector.Show();
                ShowVector(vector.next);
            }

        }
        static bool CheckNotNegativeIncrease(List vector)
        {
            if (vector.next != null)
            {
                if (vector.number <= vector.next.number) return CheckNotNegativeIncrease(vector.next);
                else return false;
            }
            else return true;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n");
            bool ok = false;
            int n = 0;
            do
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine()); //Ввод числа n
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка");
                }
            } while (!ok);
            if (n != 0)
            {
                Console.WriteLine("Введите члены последовательности");
                List vector = Itteration(n);
                Console.WriteLine("---");

                if (!CheckNotNegativeIncrease(vector))
                {
                    List temp = new List(vector.number);
                    vector = ShaffleVector(vector.next, temp);
                }

                ShowVector(vector);
                Console.WriteLine("---");

                Console.ReadLine();
            }
        }
        static List ShaffleVector(List vector, List prev)
        {

            if (!(vector == null))
            {
                List temp = new List(vector.number);
                temp.next = prev;
                return ShaffleVector(vector.next, temp);
            }
            else return prev;
        }
    }
}
