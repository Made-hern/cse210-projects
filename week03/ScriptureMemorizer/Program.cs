using System;
// EXCEEDING REQUIREMENTS:
//
// 1. Added support for multiple scriptures and random selection.
// 2. Implemented logic to avoid hiding already hidden words.
// 3. Added verse range support (e.g., Proverbs 3:5-6).
// 4. Clean object-oriented design using encapsulation.
// 5. Dynamic hiding of multiple words per iteration.
// 6. Improved user interaction with clear instructions.
class Program
{
    static void Main(string[] args)
    {
        // EXTRA FEATURE: Multiple scriptures (random selection)
        Random random = new Random();

        Scripture[] scriptures = new Scripture[]
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whoever believes in him should not perish but have everlasting life"
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding in all your ways acknowledge him and he shall direct your paths"
            )
        };

        Scripture scripture = scriptures[random.Next(scriptures.Length)];

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program ending...");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }
}