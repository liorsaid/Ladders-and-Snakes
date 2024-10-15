using HomeAssignment_LiorSaid;

public class ConsoleUI
{
    public void PreGame()
    {
        Console.WriteLine(@"
Hey! Welcome to the ladders and snakes game!");
        string firstPlayerName = getValidPlayerName("Type the first player name:");
        Player firstPlayer = new Player(firstPlayerName);
        string secondPlayerName = getValidPlayerName("Type the second player name:");
        Player secondPlayer = new Player(secondPlayerName);
        int numberOfSnakes = getValidatedNumberInput("How many snakes do you want to be? Enter a number between 0-10");
        int numberOfLadders = getValidatedNumberInput("How many ladders do you want to be? Enter a number between 0-10");

        Console.WriteLine("Let's roll a dice to decide which one of you will begin the game.");
        Dice dice = new Dice();
        int diceRoll = dice.Roll(2);
        int playerTurn;

        Console.WriteLine(diceRoll);
        if (diceRoll == 1)
        {
            Console.WriteLine("{0} begins!", firstPlayer.PlayerName);
            playerTurn = 1;
        }
        else
        {
            Console.WriteLine("{0} begins!", secondPlayer.PlayerName);
            playerTurn = 2;
        }

        Console.WriteLine();
        GameLogic gameLogic = new GameLogic();

        gameLogic.StartGame(numberOfSnakes, numberOfLadders, firstPlayer, secondPlayer, playerTurn);
    }

    private string getValidPlayerName(string message)
    {
        Console.WriteLine(message);
        string? input = Console.ReadLine();

        while (UIValidation.CheckEmptyString(input))
        {
            Console.WriteLine("Name cannot be empty! Please enter a valid name:");
            input = Console.ReadLine();
        }
        
        return input!;
    }

    private int getValidatedNumberInput(string message)
    {
        Console.WriteLine(message);
        string? input = Console.ReadLine();
        int number;

        while (!UIValidation.IsValidNumber(input, out number) || number >= 10)
        {
            Console.WriteLine("Please enter a valid number between 0 to 10");
            input = Console.ReadLine();
        }

        return number;
    }
}
