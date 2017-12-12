using System;
using System.IO;
using System.Collections.Generic;

namespace MCDoodle.API
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> userInput = new List<string>();
            using(StreamReader reader = new StreamReader("../MCDoodleData/InputData.txt"))
            {
                while(!reader.EndOfStream)
                {
                    userInput.Add(reader.ReadLine());
                }
            }

            Console.WriteLine($"To convert from English to Morse enter '1', to convert from Morse to English enter '2'");
            string command = Console.ReadLine();
            if(command == "1")
            {
                string inputInMorse = MorseTranslator.TranslateEnglishToMorse(userInput);
                Console.WriteLine(inputInMorse);
            }
            else if(command == "2")
            {
                string inputeInEnglish = MorseTranslator.TranslateMorseToEnglish(userInput);
                Console.WriteLine(inputeInEnglish);
            }
        }
    }
}
