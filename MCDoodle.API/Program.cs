using System;
using System.IO;
using System.Collections.Generic;

namespace MCDoodle.API
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> morseInput = new List<string>();
            using(StreamReader reader = new StreamReader("../MCDoodleData/InputData.txt"))
            {
                while(!reader.EndOfStream)
                {
                    morseInput.Add(reader.ReadLine());
                }
            }

            string inputInMorse = MorseTranslator.TranslateEnglishToMorse(morseInput);
            Console.WriteLine(inputInMorse);
        }
    }
}
