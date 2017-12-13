using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MCDoodle.API
{
    public static class MorseTranslator
    {
        /// <summary>
        /// Will accept a string in English and return a string of the Morse translation. A space is shown as | and  punctuation is shown as ||.
        /// </summary>
        /// <param name="input">The string that will be translated into Morse code. The string itself will not be modified by the function.</param>
        /// <returns>A string of the input translated into Morse. Spaces and punctuation are marked.</returns>
        public static string TranslateEnglishToMorse(string input)
        {
            string result = input;

            result = result.ToLower().Trim();

            // remove all non-alphanumeric characters (except punctuation/morse characters)
            Regex rgx_nonAlphaNumeric = new Regex(@"[^a-z0-9\.\?\!\s]");
            result = rgx_nonAlphaNumeric.Replace(result, "");

            // replace all duplicate spaces with a single space
            Regex rgx_duplicateSpaces = new Regex(@"[ ]{1,}");
            result = rgx_duplicateSpaces.Replace(result," ");

            ConvertAlphanumericToDotnotation(ref result);

            return result;
        }

        /// <summary>
        /// Will accept a string in Morse (with proper formatting!) and return a string of the English translation. There will be no capitalization and all punctuation will be shown as a period.
        /// </summary>
        /// <param name="input">The string that will be translated into English. The string itself will not be modified by the function.</param>
        /// <returns>A string of the input translated into English.</returns>
        public static string TranslateMorseToEnglish(string input)
        {
            string result = input;
            Regex rgx_extraSpace = new Regex(@"(?<=(\w))[\s]");
            ConvertDotnotationToAlphanumeric(ref result);
            result = rgx_extraSpace.Replace(result, "");

            return result;
        }

        /// <summary>
        /// Will take each character in the input string and replace it with its Morse code equivalent. Spaces will be a pipe character, and punctuation will be a double pipe.
        /// </summary>
        /// <param name="stringToConvert">The string that will be replaced. The string will be overwritten in place with the new characters.</param>
        private static void ConvertAlphanumericToDotnotation(ref string stringToConvert)
        {
            // Replace each letter with its Morse equivalent
            stringToConvert = stringToConvert.Replace(" ",     "| ");
            stringToConvert = stringToConvert.Replace("?",    " ||");
            stringToConvert = stringToConvert.Replace("!",    " ||");
            stringToConvert = stringToConvert.Replace(".",    " ||");
            stringToConvert = stringToConvert.Replace("a",    ".- ");
            stringToConvert = stringToConvert.Replace("b",  "-... ");
            stringToConvert = stringToConvert.Replace("c",  "-.-. ");
            stringToConvert = stringToConvert.Replace("d",   "-.. ");
            stringToConvert = stringToConvert.Replace("e",     ". ");
            stringToConvert = stringToConvert.Replace("f",  "..-. ");
            stringToConvert = stringToConvert.Replace("g",   "--. ");
            stringToConvert = stringToConvert.Replace("h",  ".... ");
            stringToConvert = stringToConvert.Replace("i",    ".. ");
            stringToConvert = stringToConvert.Replace("j",  ".--- ");
            stringToConvert = stringToConvert.Replace("k",   "-.- ");
            stringToConvert = stringToConvert.Replace("l",  ".-.. ");
            stringToConvert = stringToConvert.Replace("m",    "-- ");
            stringToConvert = stringToConvert.Replace("n",    "-. ");
            stringToConvert = stringToConvert.Replace("o",   "--- ");
            stringToConvert = stringToConvert.Replace("p",  ".--. ");
            stringToConvert = stringToConvert.Replace("q",  "--.- ");
            stringToConvert = stringToConvert.Replace("r",   ".-. ");
            stringToConvert = stringToConvert.Replace("s",   "... ");
            stringToConvert = stringToConvert.Replace("t",     "- ");
            stringToConvert = stringToConvert.Replace("u",   "..- ");
            stringToConvert = stringToConvert.Replace("v",  "...- ");
            stringToConvert = stringToConvert.Replace("w",   ".-- ");
            stringToConvert = stringToConvert.Replace("x",  "-..- ");
            stringToConvert = stringToConvert.Replace("y",  "-.-- ");
            stringToConvert = stringToConvert.Replace("z",  "--.. ");
            stringToConvert = stringToConvert.Replace("0", "----- ");
            stringToConvert = stringToConvert.Replace("1", ".---- ");
            stringToConvert = stringToConvert.Replace("2", "..--- ");
            stringToConvert = stringToConvert.Replace("3", "...-- ");
            stringToConvert = stringToConvert.Replace("4", "....- ");
            stringToConvert = stringToConvert.Replace("5", "..... ");
            stringToConvert = stringToConvert.Replace("6", "-.... ");
            stringToConvert = stringToConvert.Replace("7", "--... ");
            stringToConvert = stringToConvert.Replace("8", "---.. ");
            stringToConvert = stringToConvert.Replace("9", "----. ");
        }

        /// <summary>
        /// Will take each character in the input string and replace it with its Alphanumeric equivalent. A pipe will be a space, and a double pipe will be a period.
        /// </summary>
        /// <param name="stringToConvert">The string that will be replaced. The string will be overwritten in place with the new characters.</param>
        private static void ConvertDotnotationToAlphanumeric(ref string stringToConvert)
        {
            // Replace each letter with its English equivalent NOTE: The largest morse symbols must be at the top of the list or it will not work as expected.
            stringToConvert = stringToConvert.Replace("-----" ,"0");
            stringToConvert = stringToConvert.Replace(".----" ,"1");
            stringToConvert = stringToConvert.Replace("..---" ,"2");
            stringToConvert = stringToConvert.Replace("...--" ,"3");
            stringToConvert = stringToConvert.Replace("....-" ,"4");
            stringToConvert = stringToConvert.Replace("....." ,"5");
            stringToConvert = stringToConvert.Replace("-...." ,"6");
            stringToConvert = stringToConvert.Replace("--..." ,"7");
            stringToConvert = stringToConvert.Replace("---.." ,"8");
            stringToConvert = stringToConvert.Replace("----." ,"9");
            stringToConvert = stringToConvert.Replace("-..."  ,"b");
            stringToConvert = stringToConvert.Replace("-.-."  ,"c");
            stringToConvert = stringToConvert.Replace("..-."  ,"f");
            stringToConvert = stringToConvert.Replace("...."  ,"h");
            stringToConvert = stringToConvert.Replace(".---"  ,"j");
            stringToConvert = stringToConvert.Replace(".-.."  ,"l");
            stringToConvert = stringToConvert.Replace(".--."  ,"p");
            stringToConvert = stringToConvert.Replace("--.-"  ,"q");
            stringToConvert = stringToConvert.Replace("...-"  ,"v");
            stringToConvert = stringToConvert.Replace("-..-"  ,"x");
            stringToConvert = stringToConvert.Replace("-.--"  ,"y");
            stringToConvert = stringToConvert.Replace("--.."  ,"z");
            stringToConvert = stringToConvert.Replace("-.."   ,"d");
            stringToConvert = stringToConvert.Replace("--."   ,"g");
            stringToConvert = stringToConvert.Replace("-.-"   ,"k");
            stringToConvert = stringToConvert.Replace("---"   ,"o");
            stringToConvert = stringToConvert.Replace(".-."   ,"r");
            stringToConvert = stringToConvert.Replace("..."   ,"s");
            stringToConvert = stringToConvert.Replace("..-"   ,"u");
            stringToConvert = stringToConvert.Replace(".--"   ,"w");
            stringToConvert = stringToConvert.Replace(".-"    ,"a");
            stringToConvert = stringToConvert.Replace(".."    ,"i");
            stringToConvert = stringToConvert.Replace("--"    ,"m");
            stringToConvert = stringToConvert.Replace("-."    ,"n");
            stringToConvert = stringToConvert.Replace("."     ,"e");
            stringToConvert = stringToConvert.Replace("-"     ,"t");
            stringToConvert = stringToConvert.Replace("||"    ,".");
            stringToConvert = stringToConvert.Replace("|"     ," ");
        }
    }
}