    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Задание_8
    {
        class RebroArray
        {
            public Rebro[] mas;
            public int size;
            public RebroArray() { }
            public RebroArray(int n)
            {
                size = n;
            }
            public void CreateArray()
            {
                bool ok = false;
                do
                {
                    try
                    {
                        mas = new Rebro[size];
                        bool probel = false;
                        for (int i = 0; i < size; i++)
                        {
                            string vector = Console.ReadLine();
                            string from = "";
                            string to = "";
                            for (int j = 0; j < vector.Length; j++)
                            {
                                if (vector[j] == ' ') probel = true;
                                if (!probel)
                                {
                                    from += vector[j];
                                }
                                else if (vector[j] != ' ') to += vector[j];
                            }
                            mas[i] = new Rebro(from, to);
                            probel = false;
                            ok = true;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка ввода, введите все заново");
                    }
                } while (!ok);
            }
            public Rebro this[int a]
            {
                get { return mas[a]; }
            }
        }
    }


