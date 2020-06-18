using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    class Program
    {
        static double[,] mas = new double[10, 10];
        static double GreatestNumber(int a)
        {
            double result = mas[a, 1];
            for (int i = 1; i < 10; i++)
            {
                if (result < mas[a, i]) result = mas[a, i];
            }
            return result;
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
        static void Main(string[] args)
        {
            string vector = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mas[i, j] = GetDouble();

                    if (i == j && mas[i, j] < 0) vector += i.ToString();
                }
            }
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(GreatestNumber(Convert.ToInt32(vector[i]) - 48));
            }
        }
    }
}
