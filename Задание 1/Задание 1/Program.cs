using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            string input = @"c:\temp\INPUT.txt", output = @"c:\temp\OUTPUT.txt";
            //string input = @"INPUT.txt", output = @"OUTPUT.txt";
            using (FileStream fs = new FileStream(input, FileMode.OpenOrCreate)) { }
            using (StreamReader reader = new StreamReader(input, Encoding.Default))
            {
                while (reader.Peek() > -1)
                {
                    string s1 = reader.ReadLine();
                    string vector = "abcdefgh";
                    int xferz = 0, yferz = 0;
                    int xWKing = 0, yWKing = 0;
                    int xBKing = 0, yBKing = 0;

                    string message = s1;
                    for (int i = 0; i < vector.Length; i++)
                    {
                        if (message[0] == vector[i]) xWKing = 1 + i;
                        if (message[3] == vector[i]) xferz = 1 + i;
                        if (message[6] == vector[i]) xBKing = 1 + i;
                    }
                    yWKing = Convert.ToInt32(message[1]) - 48;
                    yferz = Convert.ToInt32(message[4]) - 48;
                    yBKing = Convert.ToInt32(message[7]) - 48;
                    if (((xferz == xBKing) && (xferz == xWKing) && (!((yWKing > yferz) && (yWKing < yBKing)) || !((yWKing < yferz) && (yWKing > yBKing)))) ||
                        ((yferz == yBKing) && (yferz == yWKing) && (!((xWKing > xferz) && (xWKing < xBKing)) || !((xWKing < xferz) && (xWKing > xBKing)))) ||
                        ((yferz == yBKing) && (yferz != yWKing)) ||
                        ((xferz == xBKing) && (xferz != xWKing)) ||
                        ((xferz - yferz == xBKing - yBKing) && (xWKing - yWKing == xBKing - yBKing) && !(((xWKing > xBKing) && (xWKing < xferz)) || ((xWKing < xBKing) && (xWKing > xferz))))
                        || ((xferz - yferz == xBKing - yBKing) && (xWKing - yWKing != xBKing - yBKing))
                        || ((xferz + yferz == xBKing + yBKing) && (xWKing + yWKing == xBKing + yBKing) && !(((xWKing > xBKing) && (xWKing < xferz)) || ((xWKing < xBKing) && (xWKing > xferz))))
                        || ((xferz + yferz == xBKing + yBKing) && (xWKing + yWKing != xBKing + yBKing)) ||
                        (xferz == xBKing) && (xferz != xWKing) || (yferz == yBKing) && (yferz != yWKing)
                        ) answer = "YES";
                    else answer = "NO";
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