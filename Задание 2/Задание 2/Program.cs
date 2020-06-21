using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            //string input = @"c:\temp\INPUT.txt", output = @"c:\temp\OUTPUT.txt";
            string input = @"INPUT.txt", output = @"OUTPUT.txt";
            using (FileStream fs = new FileStream(input, FileMode.OpenOrCreate)) { }
            using (StreamReader reader = new StreamReader(input, Encoding.Default))
            {
                string answer = "";
                while (reader.Peek() > -1)
                {

                    string s1 = reader.ReadLine();
                    string s2 = reader.ReadLine();
                    int n = 0;
                    n = Convert.ToInt32(s1);
                    int[] steps = new int[n];
                    int Counter = 0;
                    string number = "";
                    for (int i = 0; i < s2.Length; i++)
                    {
                        if (s2[i] == ' ')
                        {
                            steps[Counter] = Convert.ToInt32(number);
                            Counter++;
                            number = "";
                        }
                        else if (i + 1 == s2.Length)
                        {
                            number += s2[i];
                            steps[Counter] = Convert.ToInt32(number);
                        }
                        else number += s2[i];
                    }
                    int[] MaxSumFrom = new int[n];
                    int[] Next = new int[n + 1];
                    Next[n - 1] = n - 1;
                    Next[n] = n;
                    MaxSumFrom[n - 1] = steps[n - 1];
                    MaxSumFrom[n - 2] = steps[n - 2] + steps[n - 1];
                    for (int i = n - 3; i >= 0; i--)
                    {
                        if (MaxSumFrom[i + 1] > MaxSumFrom[i + 2])
                        {
                            MaxSumFrom[i] = steps[i] + MaxSumFrom[i + 1];
                            Next[i + 1] = i + 1;
                        }
                        else
                        {
                            MaxSumFrom[i] = steps[i] + MaxSumFrom[i + 2];
                            Next[i + 1] = i + 1;
                            Next[i + 2] = 0;
                            if (i != 0) MaxSumFrom[i - 1] = steps[i - 1] + MaxSumFrom[i + 1];
                            i--;
                        }
                    }

                    answer += MaxSumFrom[0].ToString() + "\n";
                    int ii = 1;
                    while (ii != n)
                    {

                        if (Next[ii] != 0) answer += (Next[ii] + " ");
                        ii++;

                    }
                    answer += n.ToString();

                }
                using (FileStream fs = new FileStream(output, FileMode.OpenOrCreate)) { }
                using (StreamWriter writer = new StreamWriter(output))
                {

                    writer.Write(answer);
                }
            }

        }
    }
}
