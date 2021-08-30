using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Uppgift1Primtal
{
    class Prime
    {
        List<int> primenumbers = new List<int>(); // Datastruktur för att spara de prim nummer användare angett
        public void Start() // Alternativ start och exit
        {
            Console.WriteLine("\t*************************************");
            Console.WriteLine("\t*                                   *");
            Console.WriteLine("\t*  Start? To exit enter exit (s/e)  *");
            Console.WriteLine("\t*                                   *");
            Console.WriteLine("\t*************************************\n");
            string input = Console.ReadLine().ToLower();
                if (input == "start" || input == "s")
                {
                    CheckPrime();
                }
                else if (input == "exit" || input == "e")
                {
                    Console.WriteLine("\nPress any key to exit\n");
                    Console.ReadKey();
                    Environment.Exit(0); // Exit konsoll av användares val
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
                    if (num <= 1 || num == 4) // Inget prim nummer
                    {
                        Console.WriteLine($"\nEntered Number {num} is Not Prime");
                        CheckPrime();
                    }
                    for (int i = 2; i < num / 2; i++)
                    {
                        if (num % i == 0)
                        {
                            count = 1;
                            break; // Avslutar loop
                        }
                    }
                    if (count == 1) 
                    {
                        Console.WriteLine($"\nEntered Number {num} is Not Prime");
                        CheckPrime();
                    }
                    else // Prim nummer
                    {
                        Console.WriteLine($"\nEntered Number {num} is Prime");
                        AddPrimeNumberToList(num); // Tillkallar metod för alternativ 
                    }
                }
                catch (Exception) // Fel input
                {
                    Console.WriteLine("\nwrong type of input, requires a number, please try again");
                }
            }
        }

        private void AddPrimeNumberToList(int num)
        {
            if (!primenumbers.Contains(num))// Om primtal inte redan finns i datastruktur adderas det in i listan(inga dubbletter)
            {
                primenumbers.Add(num);
                primenumbers.Sort();// Sorterar datastrukturen efter varje primtal
            }
            foreach (var number in primenumbers)
                Console.WriteLine($"\n{number}"); // Skriver ut datastrukturen
            SortPrimeListHigToLow();
        }

        private void SortPrimeListHigToLow() 
        {
            Console.WriteLine("\nTo sort entered primes high to low, please enter: sort or: continue (s/c)");
            Console.WriteLine("\nTo exit please enter: exit/e\n");
            var input = Console.ReadLine().ToLower();
            if (input == "sort" || input == "s")
            {
                primenumbers.Reverse();
                foreach (var number in primenumbers)
                    Console.WriteLine($"\n{number}");
                CheckPrime();
            }
            else if (input == "continue" || input == "c")
            {
                CheckPrime(); // Startar om metod för CheckPrime
            }
            else if (input == "exit" || input == "e")
            {
                Console.WriteLine("\nPress any key to exit\n");
                Console.ReadKey();
                Environment.Exit(0); // Exit konsoll av användares val
            }
            else // Fel typ av input, tillkallar metoden igen
                Console.WriteLine($"\nwrong type of input, please try again");
            SortPrimeListHigToLow();
        }
    }
}
