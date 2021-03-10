using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LexemeCounter
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Enter a path to a text file:");
            bool fileFound = false;
            List<string> lines = new List<string>();
            while (!fileFound)
            {
            	string inputPath = Console.ReadLine();
	            try
	            {
	            	lines.AddRange(File.ReadAllLines(inputPath));
	            	fileFound = true;    	
	            }
	            catch (FileNotFoundException)
	            {
	            	Console.WriteLine("Such file does not exist. Try again!");
	            }
	            catch (ArgumentException)
	            {
	            	Console.WriteLine("Empty paths are not allowed to be used. Try again!");
	            }
            }
            List<string> words = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
            	var analyzed_line = lines[i].Trim().Split(' ');
            	for (int j = 0; j < analyzed_line.Length; j++)
            	{
            		string current_line = analyzed_line[j].Replace("-", "").Replace(".", "").Replace(",", "").Replace(":", "").Replace(";", "").Replace("?", "").Replace("!", "").Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace("\"", "").Replace("—", "").ToLower();
            		if (current_line != "")
            		{
            			words.Add(current_line);
            		}            		
            	}
            }
            Dictionary<string, int> words_with_frequencies_list = new Dictionary<string, int>();
            bool validFileNameProvided = false;
            Console.WriteLine("Insert file, where you want to save the frequencies to:");            
            while(!validFileNameProvided)
            {
            	try
            	{
	            	string fileName = Console.ReadLine();
	            	if (fileName == "")
	            	{            		
	            		throw new ArgumentException();
	            	}
	            	if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName + ".txt")))
	            	{
	            		throw new IOException();
	            	}
	            	using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), fileName + ".txt"), FileMode.CreateNew))
		            {
		            	using (var writer = new StreamWriter(stream))
		            	{
				           	foreach (var kv in words_with_frequencies_list)
					        {
					          	writer.WriteLine(kv.Key + "\t" + kv.Value.ToString());
					        }
					    }
					}
		            Console.WriteLine("Success! Resulting file path is {0}.txt", Path.Combine(Directory.GetCurrentDirectory(), fileName));
		            validFileNameProvided = true;
            	}
            	catch (ArgumentException)
            	{
            		Console.WriteLine("Empty paths are not allowed to be used. Try again!");
            	}
            	catch (IOException)
            	{
            		Console.WriteLine("Such file already exists, try again!");
            	}
            	catch (Exception)
            	{
            		Console.WriteLine("Something went terribly wrong, try again!");
            	}
            }
            Console.WriteLine("Waiting for exit...");
            Console.ReadKey();
        }
    }
}
