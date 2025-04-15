using System;
using System.Collections.Generic;
class Program
{
	static void Main()
	{
		Random random = new Random();
		List<int> records = new List<int>();
		while (true)
		{
			int secretNumber = 0;
			int guess = 0;
			int attempts = 0;
			Console.WriteLine("Welcome to the game ‘Guess the number'!");
			Console.WriteLine("Select difficulty level:");
			Console.WriteLine("1 - Easy (1-50)");
			Console.WriteLine("2 - Medium (1-100)");
			Console.WriteLine("3 - Difficult (1-500)");
			Console.WriteLine("Your choice: ");
			string input = Console.ReadLine();
			if (int.TryParse(input, out int userChoice))
			{
				if (userChoice == 1) secretNumber = random.Next(1, 51);
				else if (userChoice == 2) secretNumber = random.Next(1, 101);
				else if (userChoice == 3) secretNumber = random.Next(1, 501);
				else secretNumber = random.Next(1, 101);
			}
			else secretNumber = random.Next(1, 101);
			while (guess != secretNumber && attempts < 10)
			{
				Console.WriteLine("Enter your guess: ");
				input = Console.ReadLine();
				if (int.TryParse(input, out guess))
				{
					attempts++;
					if (guess < secretNumber) Console.WriteLine("Too low!");
					else if (guess > secretNumber) Console.WriteLine("Too
				   high!");
				    else
					{
						Console.WriteLine($"Congratulations! You guessed the
					   number in { attempts}
						attempts!");
 if (records.Count < 3 || attempts < records[^1])
						{
							records.Add(attempts);
							records.Sort();
							if (records.Count > 3) records.RemoveAt(3);
						}
						Console.WriteLine($"Top records: {string.Join(", ",
					   records)}");
						break;
					}
				}
				else Console.WriteLine("Please enter an integer");
			}
			if (guess != secretNumber)
				Console.WriteLine($"You lost! The secret number was
	   { secretNumber}.");
	    Console.WriteLine("Do you want to play again? (yes/no): ");
			string again = Console.ReadLine().ToLower();
			if (again != "yes")
			{
				Console.WriteLine("Thanks for playing!");
				break;
			}
		}
	}
}
