using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_8
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine(@"Сначала вводится кол-во вершин, потом вводятся названия вершин, 
далее вводится кол-во ребер и после вводятся ребра состоящие из строки с двумя вершинами.
Если в графе присутствуют одинаковые ребра, то они будут считаться как одно.");

            int AmountOfPoints = Convert.ToInt32(Console.ReadLine());
            string[] Points = new string[AmountOfPoints];
            for (int i = 0; i < AmountOfPoints; i++)
            {
                Points[i] = Console.ReadLine();
            }
            RebroArray rebra = new RebroArray(Convert.ToInt32(Console.ReadLine()));
            rebra.CreateArray();
            Console.WriteLine("Среди ребер, являются мостами:");
            for (int i = 0; i < rebra.size; i++)
            {
                if (CheckRebro(rebra[i], rebra)) rebra[i].Show();
            }
            Console.ReadKey();
        }
        static bool CheckRebro(Rebro current, RebroArray mas)
        {
            Rebro[] passed = new Rebro[mas.size];
            for (int i = 0; i < mas.size; i++)
            {
                passed[i] = new Rebro();
            }

            int passedCounter = 1;

            passed[0] = current;
            bool ok = true;

            while (ok)
            {

                for (int i = 0; i < mas.size; i++)
                {
                    if ((current.To == mas[i].To && CheckPassed(passed, mas[i])) || (current.To == mas[i].From && CheckPassed(passed, mas[i])))
                    {
                        if (mas[i].From == passed[0].From || mas[i].To == passed[0].From) return false;
                        else ok = false;

                        string a, b;
                        if (mas[i].From == current.To)
                        {
                            a = mas[i].From;
                            b = mas[i].To;
                        }
                        else
                        {
                            a = mas[i].To;
                            b = mas[i].From;
                        }
                        current = new Rebro(a, b);
                        passed[passedCounter] = current;
                        passedCounter++;
                        i = -1;
                    }
                    else ok = false;
                }
                if (!ok)
                {
                    for (int i = passedCounter - 1; i >= 0; i--)
                    {
                        if (i == 0)
                        {
                            ok = false;
                            break;
                        }

                        Rebro chosen = new Rebro();
                        for (int j = 0; j < mas.size; j++)
                        {
                            if ((mas[j].To == passed[i].To && CheckPassed(passed, mas[j])) || mas[j].From == passed[i].From && CheckPassed(passed, mas[j]) ||
                                (mas[j].From == passed[i].To && CheckPassed(passed, mas[j])) || mas[j].To == passed[i].From && CheckPassed(passed, mas[j]))
                            {
                                current = passed[i - 1];
                                ok = true;
                                break;
                            }
                        }
                        if (ok)
                        {
                            break;
                        }

                    }
                }
            }
            return true;
        }
        static bool CheckPassed(Rebro[] a, Rebro b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if ((b.From == a[i].From && b.To == a[i].To) || (b.To == a[i].From && b.From == a[i].To)) return false;
            }
            return true;
        }

    }
}
