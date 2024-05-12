using System;
using System.IO;

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
                string question = generator.generateRandomQuestion();
                Console.WriteLine(question);
                Console.WriteLine("Your response:");
                string response = Console.ReadLine();
                SaveResponse(response); // in line 48 can see how it will work      
                break;
            case "2":
                Console.WriteLine("You Chose To Display.");
                DisplayJournal();
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
    static void SaveResponse(string response)
    {
        string filePath = "response.txt";
        try
        {
        using(StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(response);
        }
        //if work will be display Response saved
        Console.WriteLine("Response saved.");
        }
        catch (Exception ex)
        {
            //if don't work will be display Response saved
            Console.WriteLine($"Error saving response: {ex.Message}");
        }
    }
    static void DisplayJournal()
{
    string filePath = "response.txt";
    try
    {
        string[] responses = File.ReadAllLines(filePath);
        Console.WriteLine("Journal Entries:");
        foreach (string response in responses)
        {
            Console.WriteLine(response);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error displaying journal: {ex.Message}");
    }
}


}