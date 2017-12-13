using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MCDoodle.API
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;
            using(StreamReader reader = new StreamReader("../MCDoodleData/InputData.txt"))
            {
                while(!reader.EndOfStream)
                {
                    userInput += (reader.ReadLine() + " ");
                }
            }

            string output = string.Empty;
            // will detect the input language and perform the appropriate translation
            Regex rgx_containsAlphanumeric = new Regex("[A-Za-z0-9]");
            if(rgx_containsAlphanumeric.IsMatch(userInput))
            {
                output = MorseTranslator.TranslateEnglishToMorse(userInput);
            }
            else
            {
                output = MorseTranslator.TranslateMorseToEnglish(userInput);
            }

            // write output to file (overwriting anything already there)
            using(StreamWriter writer = new StreamWriter("../MCDoodleData/OutputData.txt",false))
            {
                writer.Write(output);
            }
        }
    }
}
