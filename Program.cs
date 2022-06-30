Main();

void Main()
{
    List<string> difficultyLevel = new List<string>
    {
        "low",
        "medium",
        "high"
    };

    Console.WriteLine("Welcome!");
    int guessCount = findGuessCount(difficultyLevel);
    int secretNumber = findSecretNumber();

    if(guessCount > 0)
    {
        gamePlay(guessCount, secretNumber);
    }
    else
    {
        Console.WriteLine("Oops! Looks like you selected a skill level that is not available. Please try again.");
    }
}

// User picks a skill level that will determine the number of guesses to be passed in to gamePlay
static int findGuessCount(List<string> levels)
{

    Console.WriteLine("Please select a difficulty level to get started:");

    foreach(string level in levels)
    {
        Console.WriteLine(level);
    }

    string userLevel = Console.ReadLine().ToLower();

    switch (userLevel)
    {
        case "low":
            return 8;
        case "medium":
            return 6;
        case "high":
            return 4;
        case "cheater":
            return 100;
        default:
            return -1;
    }
}

// A randomly generated number for user to guess
static int findSecretNumber()
{
    
    Random randomNumber = new Random();
    int foundNumber = randomNumber.Next(1, 100);
    
    return foundNumber;
}

// User will input <userGuess> then have <numberOfGuesses> to guess the <secretNumber>
void gamePlay(int numberOfGuesses, int secretNumber)
{
    Console.WriteLine("Please guess a number 1-100:");
    Console.WriteLine(secretNumber);
    
    for (int i = 0; i < numberOfGuesses; i++)
    {
        string userGuess = Console.ReadLine();
        int.TryParse(userGuess, out int userNumber);

       if(userNumber == secretNumber)
        {
            Console.WriteLine($"Hooray, you guessed it! The answer was {secretNumber}.");
            break;
        }
        else if(i < (numberOfGuesses - 1))
        {
            if(userNumber > secretNumber)
            {
                Console.WriteLine($"Oh no! Your guess ({userNumber}) is too high. Try Again.");
            }
            else
            {
                Console.WriteLine($"Oh no! Your guess ({userNumber}) is too low. Try Again.");
            }

            Console.WriteLine($"Guesses Remaining: {(numberOfGuesses - i) - 1}");
        } 
        else
        {
            Console.WriteLine($"Sorry, you lose :( The answer was {secretNumber}.");
        }
    }
}
