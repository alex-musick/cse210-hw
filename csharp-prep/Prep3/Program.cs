using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string playAgainAnswer;
        do
        {
            int magicNumber = randomGenerator.Next(1, 100);

            int guess;
            int numberGuesses = 0;
            do
            {
                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

                numberGuesses++;
            } while (guess != magicNumber);

            Console.WriteLine($"You won in {numberGuesses} guesses!");
            Console.Write("Would you like to play again? (yes or no) ");
            playAgainAnswer = Console.ReadLine();
        } while (playAgainAnswer == "yes");
    }
}