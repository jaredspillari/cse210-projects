using System;

class Program
{
    static void Main(string[] args)
    {
        randomPrompt generator = new randomPrompt();
        Console.WriteLine("Please select one of the following choice:");

        while (true)
        {
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\n6. Edit\n");
            string input = Console.ReadLine();

            if(input.ToLower() == "Exit")
                break;
            
            string option = generator.generateRandomQuestion();
            Console.WriteLine(option);
        }
        Console.WriteLine("Thanks for write today");
    }
}