using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_11
{
    class Program
    {
        static bool CheckMessage(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] != '0' && message[i] != '1')
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string message = ""; // Ввод сообщения последовательности а, состоящей из нулей и единиц
            do
            {
                Console.WriteLine("Введите строку из нулей и единиц");
                message = Console.ReadLine();
            } while (!(CheckMessage(message)));

            char[] sifer = new char[message.Length];//шифр б
            char[] SolvedSifer = new char[message.Length]; //Расшифрованный шифр б
            sifer[0] = message[0];
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] != '0' && message[i] != '1') return;
            }
            for (int i = 1; i < message.Length; i++)
            {
                if (message[i] == message[i - 1]) sifer[i] = '1';
                else sifer[i] = '0';
            }
            Console.WriteLine("Зашифрованное сообщение");
            WriteSifer(sifer);
            SolvedSifer[0] = sifer[0];
            for (int i = 1; i < sifer.Length; i++)
            {
                if (sifer[i] == '0')
                {
                    if (SolvedSifer[i - 1] == '1') SolvedSifer[i] = '0';
                    else SolvedSifer[i] = '1';
                }
                else
                {
                    if (SolvedSifer[i - 1] == '1') SolvedSifer[i] = '1';
                    else SolvedSifer[i] = '0';
                }
            }
            Console.WriteLine("Расшифрованное сообщение");
            WriteSifer(SolvedSifer);
            Console.ReadLine();
        }
        static void WriteSifer(char[] mas)
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine(mas[mas.Length - 1]);
        }
    }
}
