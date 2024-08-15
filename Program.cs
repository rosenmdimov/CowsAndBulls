namespace CowsAndBulls
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int secretNumber = GenerateRandomNumber(random);

            Console.WriteLine("Welcome to Cows and Bulls!");

            while (true)
            {
                Console.Write("Enter your guess (4-digit number): ");
                string guess = Console.ReadLine();

                if (!IsValidGuess(guess))
                {
                    Console.WriteLine("Invalid guess. Please enter a 4-digit number with unique digits.");
                    continue;
                }

                int bulls = CountBulls(guess, secretNumber);
                int cows = CountCows(guess, secretNumber);

                if (bulls == 4)
                {
                    Console.WriteLine("Congratulations! You guessed the number!");
                    break;
                }

                Console.WriteLine($"{bulls} bulls and {cows} cows.");
            }
        }

        static int GenerateRandomNumber(Random random)
        {
            int number;
            do
            {
                number = random.Next(1000, 10000);
            } while (!HasUniqueDigits(number));
            return number;
        }

        static bool HasUniqueDigits(int number)
        {
            string numberString = number.ToString();
            return numberString.Distinct().Count() == 4;
        }

        static bool IsValidGuess(string guess)
        {
            return guess.Length == 4 && guess.All(char.IsDigit) && HasUniqueDigits(int.Parse(guess));
        }

        static int CountBulls(string guess, int secretNumber)
        {
            int bulls = 0;
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secretNumber.ToString()[i])
                {
                    bulls++;
                }
            }
            return bulls;
        }

        static int CountCows(string guess, int secretNumber)
        {
            int cows = 0;
            for (int i = 0; i < 4; i++)
            {
                if (secretNumber.ToString().Contains(guess[i]) && guess[i] != secretNumber.ToString()[i])
                {
                    cows++;
                }
            }
            return cows;
        }
    }
}