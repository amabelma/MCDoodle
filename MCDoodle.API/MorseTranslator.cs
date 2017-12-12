using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MCDoodle.API
{
    public static class MorseTranslator
    {
        public static string TranslateEnglishToMorse(List<string> input)
        {
            // remove blank rows
            for(int i=0; i<input.Count; i++)
            {
                if(input[i] == "")
                {
                    input.RemoveAt(i);
                    i--;
                }
            }

            string result = string.Empty;
            // A good tool to test intended output is https://morsecode.scphillips.com/translator.html.
            // The result will be one large sentence, with additional space to designate that there is a paragraph.
            for(int i=0; i<input.Count; i++)
            {
                string line = input[i];
                TranslateEnglishLettersToMorse(ref line);
                result += line;
            }

            return result;
        }

        private static void TranslateEnglishLettersToMorse(ref string lineInMorse)
        {
            lineInMorse = lineInMorse.ToLower().Trim();

            // remove all non-alphanumeric characters (except periods)
            Regex rgx_nonAlphaNumeric = new Regex(@"[^a-z0-9\.\?\! -]");

            // replace all duplicate spaces with a single space
            lineInMorse = rgx_nonAlphaNumeric.Replace(lineInMorse, "");
            Regex rgx_duplicateSpaces = new Regex(@"[ ]{1,}");

            lineInMorse = rgx_duplicateSpaces.Replace(lineInMorse," ");
            // Replace each letter with its Morse equivalent
            lineInMorse = lineInMorse.Replace(" ","| ");
            lineInMorse = lineInMorse.Replace("?"," ||");
            lineInMorse = lineInMorse.Replace("!"," ||");
            lineInMorse = lineInMorse.Replace(".","  ||");
            lineInMorse = lineInMorse.Replace("a",".- ");
            lineInMorse = lineInMorse.Replace("b","-... ");
            lineInMorse = lineInMorse.Replace("c","-.-. ");
            lineInMorse = lineInMorse.Replace("d","-.. ");
            lineInMorse = lineInMorse.Replace("e",". ");
            lineInMorse = lineInMorse.Replace("f","..-. ");
            lineInMorse = lineInMorse.Replace("g","--. ");
            lineInMorse = lineInMorse.Replace("h",".... ");
            lineInMorse = lineInMorse.Replace("i",".. ");
            lineInMorse = lineInMorse.Replace("j",".--- ");
            lineInMorse = lineInMorse.Replace("k","-.- ");
            lineInMorse = lineInMorse.Replace("l",".-.. ");
            lineInMorse = lineInMorse.Replace("m","-- ");
            lineInMorse = lineInMorse.Replace("n","-. ");
            lineInMorse = lineInMorse.Replace("o","--- ");
            lineInMorse = lineInMorse.Replace("p",".--. ");
            lineInMorse = lineInMorse.Replace("q","--.- ");
            lineInMorse = lineInMorse.Replace("r",".-. ");
            lineInMorse = lineInMorse.Replace("s","... ");
            lineInMorse = lineInMorse.Replace("t","- ");
            lineInMorse = lineInMorse.Replace("u","..- ");
            lineInMorse = lineInMorse.Replace("v","...- ");
            lineInMorse = lineInMorse.Replace("w",".-- ");
            lineInMorse = lineInMorse.Replace("x","-..- ");
            lineInMorse = lineInMorse.Replace("y","-.-- ");
            lineInMorse = lineInMorse.Replace("z","--.. ");
            lineInMorse = lineInMorse.Replace("0","----- ");
            lineInMorse = lineInMorse.Replace("1",".---- ");
            lineInMorse = lineInMorse.Replace("2","..--- ");
            lineInMorse = lineInMorse.Replace("3","...-- ");
            lineInMorse = lineInMorse.Replace("4","....- ");
            lineInMorse = lineInMorse.Replace("5","..... ");
            lineInMorse = lineInMorse.Replace("6","-.... ");
            lineInMorse = lineInMorse.Replace("7","--... ");
            lineInMorse = lineInMorse.Replace("8","---.. ");
            lineInMorse = lineInMorse.Replace("9","----. ");
        }
    }
}