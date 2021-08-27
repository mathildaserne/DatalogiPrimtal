using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uppgift1Primtal
{
    class Prime
    {
        List<int> primenumbers = new List<int>();
        public void Start()
        {
            Console.WriteLine("\t*************************************");
            Console.WriteLine("\t*                                   *");
            Console.WriteLine("\t*         start/s else exit/e?        *");
            Console.WriteLine("\t*                                   *");
            Console.WriteLine("\t*************************************\n");
            string input = Console.ReadLine().ToLower();
                if (input == "start" || input == "s")
                {
                    CheckPrime();
                }
                else if (input == "exit" || input == "e")
                {
                    Console.WriteLine("\nbye\n");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nwrong type of input................\n");
                    Start();
                }
        }
        public void CheckPrime()
        {
            while (true)
            {
                try
                {
                    int num;
                    int count = 0;
                    Console.Write("\nEnter a number to check if number is prime or not : ");
                    num = Convert.ToInt32(Console.ReadLine());
                    if (num <= 1) // Input värde för lågt
                    {
                        Console.WriteLine($"\nwrong type of input, requires a number, please try again");
                        CheckPrime();
                    }
                    for (int i = 2; i < num / 2; i++)
                    {
                        if (num % i == 0)
                        {
                            count = 1;
                            break;
                        }
                    }
                    if (count == 1)
                    {
                        Console.WriteLine($"\nEntered Number {num} is Not Prime");
                        CheckPrime();
                    }
                    else
                    {
                        Console.WriteLine($"\nEntered Number {num} is Prime");
                        if (!primenumbers.Contains(num))// Om primtal inte redan finns i datastruktur adderas det in i listan(inga dubbletter)
                        {
                            primenumbers.Add(num);
                            primenumbers.Sort();// Sorterar datastruktur efter varje input
                        }
                        foreach (var number in primenumbers)
                            Console.WriteLine($"\n{number}");
                        SortPrimeListHigToLow();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nwrong type of input, requires a number, please try again");
                }
            }
        }

        private void SortPrimeListHigToLow()
        {
            Console.WriteLine("\nTo sort prime list by high to low please enter: sort/s else: continue/c");
            Console.WriteLine("\nTo exit please enter: exit/e\n");
            var input = Console.ReadLine().ToLower();
            if (input == "sort" || input == "s")
            {
                Console.WriteLine("\nSort.............");
                CheckPrime();
            }
            else if (input == "continue" || input == "c")
            {
                CheckPrime();
            }
            else if (input == "exit" || input == "e")
            {
                Console.WriteLine("\nbye\n");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
                Console.WriteLine($"\nwrong type of input, please try again");
            SortPrimeListHigToLow();
        }
    }
}
