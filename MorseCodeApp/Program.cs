using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeApp
{
    class Program
    {

        //program should read file
        //bring in file
        //parse and save into variable
        //build dictionary
        //prompt user to enter phrase, view dictionary, quit?
        //function to convert phrase
        //display converted text


        //static void PrintMorse(Dictionary<char, string> morseList)
        //{

        //    foreach (var letter in morseList)
        //    {
        //        Console.WriteLine($"name: {letter.Key} number : {letter.Value}");
        //    }
        //}


        static void getResults(string command)
        {

            Console.WriteLine("Your phrase in Morse is:" + command);
        }


        static string ConvertToMorse(string command, Dictionary<char, string> morseDictionary)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char character in command)
            {
                if (morseDictionary.ContainsKey(character))
                {
                    sb.Append(morseDictionary[character] + " ");
                }
                else if (character == ' ')
                {
                    sb.Append("/ ");
                }
                else
                {
                    sb.Append(character + " ");
                }
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            //reads contents of morse code file
            var morseDictionary = new Dictionary<char, string>();
            const string FILE_PATH = "../../morse.csv";
            using (var reader = new StreamReader(FILE_PATH))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine().Split(',');
                    morseDictionary.Add(Convert.ToChar(line[0]), (line[1]));
                }
            }


            Console.WriteLine("Enter phrase to begin phrase conversion");
            var command = Console.ReadLine();
  
               command =  command.ToUpper();
                string result = ConvertToMorse(command, morseDictionary);
                getResults(result);

                Console.ReadLine();

            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Want to do it again? yes or no");
                var reply = Console.ReadLine();
                if (reply == "yes")
                {
                    Console.WriteLine("Enter phrase to begin phrase conversion");
                    command = Console.ReadLine();
                    command = command.ToUpper();
                    result = ConvertToMorse(command, morseDictionary);
                    getResults(result);
                    Console.ReadLine();
                }
                else isRunning = false;
            }
        }
    }
}
