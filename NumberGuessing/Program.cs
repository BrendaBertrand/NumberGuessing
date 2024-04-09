namespace NumberGuessing;

class Program
{
    const int MIN_VALUE = 0;
    const int MAX_VALUE = 100;
    const int MAX_ATTEMPTS = 5;

    static void Main(string[] args)
    {
        Random rng = new Random();
        int magicNumber = rng.Next(MIN_VALUE, MAX_VALUE);

        Console.WriteLine("Hello, Welcome to our Number Guessing Game!");
        // The magicNumber should be removed from this message in a real game 
        Console.WriteLine(
            $"The computer choose an integer number between {MIN_VALUE} and {MAX_VALUE} and it's {magicNumber}");
        Console.WriteLine($"Will you find it in {MAX_ATTEMPTS} attempts maximum ?");
        int userGuess = -1;
        int attempt = 0;

        do
        {
            bool isParseSuccessful = false;
            Console.Write($"\nWhat's your guess ? \nAttempt n°{attempt + 1} : ");
            isParseSuccessful = Int32.TryParse(Console.ReadLine(), out userGuess);

            if (isParseSuccessful && userGuess >= MIN_VALUE && userGuess <= MAX_VALUE)
            {
                attempt++;
                if (userGuess == magicNumber)
                {
                    Console.Write(
                        $"Congratulations ! You found the Magic Number {magicNumber} in {attempt} attempt");
                    if (attempt > 1)
                    {
                        Console.Write("s");
                    }

                    break;
                }
                if (Math.Abs(userGuess - magicNumber) <= 5)
                {
                    Console.WriteLine("You're close!");
                }
                else
                {
                    if (userGuess > magicNumber)
                    {
                        Console.WriteLine("Your number is too high! ");
                    }

                    if (userGuess < magicNumber)
                    {
                        Console.WriteLine("Your number is too low! ");
                    }
                   
                }
            }

            if (!isParseSuccessful || userGuess < MIN_VALUE || userGuess > MAX_VALUE)
            {
                Console.WriteLine($"Please enter an integer between {MIN_VALUE} and {MAX_VALUE}.");
            }

            if (attempt >= MAX_ATTEMPTS)
            {
                Console.WriteLine("No more attempts available -> You Lose ");
                break;
            }
        } while (userGuess != magicNumber);
    }
}