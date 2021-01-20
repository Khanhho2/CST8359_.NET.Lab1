using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        //Variables
        static string userChoice;
        static IList<string> words = new List<string>();
        static IList<string> wordsClone = new List<string>();
        static int numberOfWords = 0;

        //Functions
        private static void ImportWords(IList<string> words)
        {
            try
            {
                using (StreamReader sr = new StreamReader("Words.txt"))
                {
                    string line;
                    Console.WriteLine("Reading Words");
                    while ((line = sr.ReadLine()) != null)
                    {
                        words.Add(line);
                        numberOfWords++;
                    }
                    Console.WriteLine("Reading Words Completed");
                    Console.WriteLine("Numbers of words found: " + numberOfWords + "\n\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read " + e);
            }
        }

        private static IList<string> BubbleSort(IList<string> words)
        {
            string temp;
            int length = words.Count;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }
            return words;
        }

        static void Main(string[] args)
        {
            //Run the program
            do
            {
                 
                var watch = new Stopwatch();
                Console.WriteLine("Hello World!!! My First C# App\nOptions\n--------\n1 - Import Words from File\n2 - Bubble Sort words\n3 - LINQ/Lambda sort words\n4 - Count the Distinct Words\n5 - Take the first 10 words\n6 - Get the number of words that start with \'j\' and display the count\n7 - Get and display of words that end with \'d\' and display the count\n8 - Get and display of words that are greater than 4 characters long, and display the count\n9 - Get and display of words that are less than 3 characters long and start with the letter \'a\', and display the count\nx - Exit\n\nMake a selection: ");
                userChoice = Console.ReadLine();
                Console.Clear();
                switch (userChoice)
                {
                    case "1":
                        ImportWords(words);
                        foreach (var item in words) {
                            wordsClone.Add(item); 
                        }
                        break;
                    case "2":
                        watch.Start();
                        BubbleSort(wordsClone);
                        watch.Stop();
                        Console.WriteLine($"Time elapsed: {watch.ElapsedMilliseconds}ms\n");
                        break;
                    case "3":
                        watch.Start();
                        var abc = (from word in words
                                   orderby word ascending
                                   select word).ToArray();
                        watch.Stop();
                        Console.WriteLine($"Time elapsed: {watch.ElapsedMilliseconds}ms\n");
                        break;
                    case "4":
                        int count = (from w in words
                                     select w).Distinct().Count();
                        Console.WriteLine($"The number of distinct words is: {count}\n");
                        break;
                    case "5":
                        var ele11 = words.ElementAt(10);
                        int counter = 0;
                        var word10 = from string word12 in words
                                     where word12 != ele11
                                     select word12;

                        foreach (string word12 in word10) {
                            if (counter < 10)
                            {
                                Console.WriteLine(word12);
                                counter++;
                            }
                            else {
                                Console.WriteLine("\n");
                                break;
                            }
                        }

                        break;
                    case "6":
                        int numberOfJ = 0;
                        var query = from string wordJ in words
                                    where wordJ.StartsWith('j')
                                    select wordJ;

                        foreach (string wordJ in query) {
                            Console.WriteLine(wordJ);
                            numberOfJ++;
                        }

                        Console.WriteLine("Number of words that start with \'j\': " + numberOfJ + "\n");

                        break;
                    case "7":
                        int numberOfD = 0;
                        var query1 = from string wordD in words
                                    where wordD.EndsWith('d')
                                    select wordD;

                        foreach (string wordD in query1)
                        {
                            Console.WriteLine(wordD);
                            numberOfD++;
                        }

                        Console.WriteLine($"Number of words that end with \'d\': {numberOfD}\n");

                        break;
                    case "8":
                        int greaterThan4 = 0;
                        var query2 = from string wordD in words
                                     where wordD.Length > 4
                                     select wordD;

                        foreach (string wordD in query2)
                        {
                            Console.WriteLine(wordD);
                            greaterThan4++;
                        }

                        Console.WriteLine($"Number of words longer than 4 characters long: {greaterThan4}\n");

                        break;
                    case "9":
                        int number9 = 0;
                        var query3 = from string wordD in words
                                     where wordD.Length < 3 && wordD.StartsWith('a')
                                     select wordD;

                        foreach (string wordD in query3)
                        {
                            Console.WriteLine(wordD);
                            number9++;
                        }

                        Console.WriteLine($"Number of words longer less than 3 characters and start with \'a\':{number9}\n");
                        break;
                    case "x":
                        break;
                    default:
                        Console.WriteLine("Please choose an option from the menu or press x to exit\n");
                        break;
                }
            } while (userChoice != "x");
            Environment.Exit(0);
        }
    }
}
