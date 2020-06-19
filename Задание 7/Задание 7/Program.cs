using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;

namespace Задание_7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok;
            int[] mas = new int[8];
            int x = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write("f(" + Convert.ToString(x, 2).PadLeft(3, '0') + ") = ");
                int s;
                do
                {
                    bool ok1 = false;
                    string buf = Console.ReadLine();
                    ok = int.TryParse(buf, out s);
                    if (buf == "*")
                    {
                        ok1 = true;
                        mas[i] = 2;
                        x++;
                        ok = true;
                        continue;
                    }

                    if (!ok)
                    {
                        Console.WriteLine("Введите целое число от 0 до 1");
                        Console.Write("f(" + Convert.ToString(x, 2).PadLeft(3, '0') + ") = ");
                    }

                    if (s < 0 || s > 1 || buf.Length > 1)
                    {
                        Console.WriteLine("Введите целое число от 0 до 1");
                        ok = false;
                        Console.Write("f(" + Convert.ToString(x, 2).PadLeft(3, '0') + ") = ");
                    }
                    if (ok || ok1)
                    {
                        mas[i] = Convert.ToInt32(s);
                        x++;
                    }
                } while (!ok);
            }

            Console.WriteLine();
            Console.Write("f(xyz) = ");

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 2) Console.Write("* ");
                else Console.Write(mas[i] + " ");
            }
            Console.WriteLine();

            int StarCount = 0;
            for (int i = 0 ; i < 8; i++)
            {
                if (mas[i] == 2)
                {
                    StarCount++;
                }
            }
            if (StarCount==0)
            {
                Console.WriteLine("Функция определена");
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                if (mas[i] != mas[mas.Length - 1 - i])
                {
                    Console.WriteLine("Невозможно переопределить в самодвойственную");
                    return;
                }
            }
            List<string> Vectors = new List<string>();
            Vectors.Add("");
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 2) Vectors[0] += '*';
                else Vectors[0] += mas[i].ToString();
            }
            for (int i = 0; i < 8; i++)
            {
                if (Vectors[0][i]=='*')
                {
                    if (Vectors[0][8-1-i] == '*')
                    {
                        int Count = Vectors.Count;
                        for (int j = 0; j < Count; j++)
                        {
                            Vectors.Add(Vectors[j]);
                            string temp = "";
                            bool okko = true;
                            for (int p = 0; p < Vectors[0].Length; p++)
                            {
                                if (okko && Vectors[j][p] == '*')
                                {
                                    okko = false;
                                    temp += '1';
                                }
                                else temp += Vectors[j][p];
                            }
                            string temp2=Vectors[j];
                            Vectors[j] = temp;
                            temp = "";
                            okko = true;
                            for (int p = 0; p < Vectors[0].Length; p++)
                            {
                                if (okko && temp2[p] == '*')
                                {
                                    okko = false;
                                    temp += '0';
                                }
                                else temp += temp2[p];
                            }
                            Vectors[Vectors.Count - 1]=temp;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Vectors.Count;j++)
                        {
                            string temp = "";
                            bool okko = true;
                                for (int p = 0; p < Vectors[0].Length; p++)
                                {
                                    if (okko && Vectors[j][p] == '*')
                                    {
                                        okko = false;
                                        temp += Vectors[j][8-1-p];
                                    }
                                    else temp += Vectors[j][p];
                                }
                            Vectors[j] = temp;
                        }
                    }
                }
            }

            string[] SortedVectors = new string[Vectors.Count];
            for (int i = 0; i < Vectors.Count; i++)
            {
                SortedVectors[i] = Vectors[i];
            }
            for (int i = 0; i < Vectors.Count; i++)
            {
                for (int j = i+1; j < Vectors.Count; j++)
                {
                    if (CheckVectors(SortedVectors[i],SortedVectors[j])==-1)
                    {
                        string temp = SortedVectors[i];
                        SortedVectors[i] = SortedVectors[j];
                        SortedVectors[j] = temp;
                        i = 0;
                        break;
                    }
                }
            }
            // вывод векторов
            for (int i = SortedVectors.Length-1; i >=0; i--)
            {
                Console.Write("F(xyz)=");
                Console.WriteLine(SortedVectors[i]);
            }


        }
        static int CheckVectors(string a, string b)
        {
            double a1=1, b1=1;
            for (int i = 0; i < 8; i++)
            {
                if (a[i] == '1') a1 = a1 + 1* Math.Pow(10, 8 - i);
                if (b[i] == '1') b1 = b1 + 1* Math.Pow(10, 8 - i);
            }
            if (a1 == b1) return 0;
            else if (a1 < b1) return -1;
            else return 1;
        }
    }
}