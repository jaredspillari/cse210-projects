using System;
using System.Collections.Generic;
using System.Linq;

// Class representing a scripture reference
public class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int VerseEnd { get; }

    // Constructor for single verse
    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = verse;
    }

    // Constructor for verse range
    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (VerseStart == VerseEnd)
            return $"{Book} {Chapter}:{VerseStart}";
        else
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}

// Class representing a word in the scripture
public class ScriptureWord
{
    public string Word { get; private set; }
    public bool IsHidden { get; set; }

    public ScriptureWord(string word)
    {
        Word = word;
        IsHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        if (IsHidden)
            return "______";
        else
            return Word;
    }
}

// Class representing the scripture text
public class Scripture
{
    public ScriptureReference Reference { get; }
    private List<ScriptureWord> Words { get; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    // Method to hide random words
    public void HideRandomWords()
    {
        Random rand = new Random();
        int wordsToHide = Words.Count(word => !word.IsHidden); // Count non-hidden words
        int wordsLeft = wordsToHide;

        while (wordsLeft > 0)
        {
            int index = rand.Next(Words.Count);
            if (!Words[index].IsHidden)
            {
                Words[index].Hide();
                wordsLeft--;
            }
        }
    }

    // Check if all words are hidden
    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public override string ToString()
    {
        return $"{Reference}\n{string.Join(" ", Words)}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Sample usage
        ScriptureReference reference = new ScriptureReference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        // Display initial scripture
        Console.WriteLine(scripture);

        // Loop until all words are hidden
        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("\nPress enter to reveal more words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            // Clear console and hide more words
            Console.Clear();
            scripture.HideRandomWords();
            Console.WriteLine(scripture);
        }

        Console.WriteLine("End of program.");
    }
}
