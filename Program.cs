using System;
using System.Collections.Generic;
using System.Linq;

namespace HotterOrColder
{
    class Program
    {
        private const int MAX_VAL = 100;
        private static readonly Random _random = new Random();

        static int nextGuess  = 0;
        static int firstGuess = 0;
        static readonly List<int> previousGuess = new List<int>();
        static readonly int numberGuess = _random.Next(0, MAX_VAL);

        static void Main(string[] args)
        {
            Console.WriteLine("I have chosen a number between 1 and 100, please guess it!");
            //Console.WriteLine(numberGuess);
            while (nextGuess < 1)
            {
                firstGuess += 1;
                Console.WriteLine("Please guess a number and press [Enter]");
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                if (inputNumber < 1 || inputNumber > 100)
                {
                    Console.WriteLine("Invalid number! Please try again:");
                    continue;
                }
                
                if (inputNumber == numberGuess)
                {
                    Console.WriteLine("You Got It!!!!");
                    nextGuess = 1;
                }
                else
                {
                    previousGuess.Add(inputNumber);
                    var result = "";
                    if (firstGuess == 1)
                    {
                        int maxNumber = numberGuess + 11 > 100 ? 100 : numberGuess;
                        result = (Enumerable.Range(numberGuess - 10, maxNumber).Contains(inputNumber))
                            ? "Hot"
                            : "Cold";
                    }
                    else if (firstGuess != 1)
                    {
                        var count = previousGuess.Count - 2;
                        result = Math.Abs(inputNumber - numberGuess) < Math.Abs(inputNumber - previousGuess[count])
                            ? "Hotter!!!"
                            : "Colder :-(";
                    }
                    Console.WriteLine(result);
                }
            }
            Console.WriteLine("Press to exit");
        }
    }
}
