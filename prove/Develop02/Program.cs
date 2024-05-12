using System;

class Program
{
    static void Main(string[] args)
    {
        randomPrompt generator = new randomPrompt();
        Console.WriteLine("Please select one of the following choice:");

        while (true)
        {
            Console.WriteLine
            ("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nPlease select one of the following choices:");
            string input = Console.ReadLine();

            if(input.ToLower() == "quit")
                break;
            
        switch (input)
        {
            case "1":
                Console.WriteLine(generator.generateRandomQuestion());
                //I need to add code to write 
                break;
            case "2":
                Console.WriteLine("You Chose To Display.");
                // add code to display
                break;
            case "3":
                Console.WriteLine("You Chose To Load.");
                // add code to Load
                break;
            case "4":
                Console.WriteLine("You Chose To Save.");
                // add code to display
                break;
            default:
                Console.WriteLine("invalit Choise. Please try again");
                break;
        }
        }
        Console.WriteLine("Thanks for writing  today");
    }
}