using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MCDoodle.API
{
    public static class MorseTranslator
    {
        /// <summary>
        /// Will accept a list of English words and return all words consolidated into a large single line. A space is shown as | and  punctuation is shown as ||.
        /// </summary>
        /// <param name="input">The list that will be translated into Morse code. The list itself will not be modified by the function.</param>
        /// <returns>All words translated into Morse in a single string. Spaces and punctuation are marked.</returns>
        public static string TranslateEnglishToMorse(List<string> input)
        {
            for(int i=0; i<input.Count; i++)
            {
                input[i] = input[i].ToLower().Trim();

                // remove all non-alphanumeric characters (except punctuation/morse characters)
                Regex rgx_nonAlphaNumeric = new Regex(@"[^a-z0-9\.\?\!\-\|]");
                input[i] = rgx_nonAlphaNumeric.Replace(input[i], "");

                // replace all duplicate spaces with a single space
                Regex rgx_duplicateSpaces = new Regex(@"[ ]{1,}");
                input[i] = rgx_duplicateSpaces.Replace(input[i]," ");
                
                if(input[i] == "")
                {
                    input.RemoveAt(i);
                    i--;
                }
            }

            string result = string.Empty;
            for(int i=0; i<input.Count; i++)
            {
                string line = input[i];
                ConvertAlphanumericToDotnotation(ref line);
                result += line;
            }

            return result;
        }

        /// <summary>
        /// Will accept a list of Morse words and return all words consolidated into a large single line in English. There are double spaces around punctuation, punctuation is all shown as a period, and there is no capitolization.
        /// </summary>
        /// <param name="input">The list that will be translated into English. The list itself will not be modified by the function.</param>
        /// <returns>All words translated into English in a single string. All punctuation is shown as periods.</returns>
        public static string TranslateMorseToEnglish(List<string> input)
        {
            string result = string.Empty;
            Regex rgx_extraSpace = new Regex(@"(?<=(\w))[\s]");
            for(int i=0; i<input.Count; i++)
            {
                string line = input[i];
                ConvertDotnotationToAlphanumeric(ref line);
                line = rgx_extraSpace.Replace(line, "");
                result += line;
            }

            return result;
        }

        /// <summary>
        /// Will take each character in the input string and replace it with its Morse code equivalent. Spaces will be a pipe character, and punctuation will be a double pipe.
        /// </summary>
        /// <param name="lineInMorse">The string that will be replaced. The string will be overwritten in place with the new characters.</param>
        private static void ConvertAlphanumericToDotnotation(ref string lineInMorse)
        {
            // Replace each letter with its Morse equivalent
            lineInMorse = lineInMorse.Replace(" ","| "    );
            lineInMorse = lineInMorse.Replace("?"," ||"   );
            lineInMorse = lineInMorse.Replace("!"," ||"   );
            lineInMorse = lineInMorse.Replace(".","  ||"  );
            lineInMorse = lineInMorse.Replace("a",".- "   );
            lineInMorse = lineInMorse.Replace("b","-... " );
            lineInMorse = lineInMorse.Replace("c","-.-. " );
            lineInMorse = lineInMorse.Replace("d","-.. "  );
            lineInMorse = lineInMorse.Replace("e",". "    );
            lineInMorse = lineInMorse.Replace("f","..-. " );
            lineInMorse = lineInMorse.Replace("g","--. "  );
            lineInMorse = lineInMorse.Replace("h",".... " );
            lineInMorse = lineInMorse.Replace("i",".. "   );
            lineInMorse = lineInMorse.Replace("j",".--- " );
            lineInMorse = lineInMorse.Replace("k","-.- "  );
            lineInMorse = lineInMorse.Replace("l",".-.. " );
            lineInMorse = lineInMorse.Replace("m","-- "   );
            lineInMorse = lineInMorse.Replace("n","-. "   );
            lineInMorse = lineInMorse.Replace("o","--- "  );
            lineInMorse = lineInMorse.Replace("p",".--. " );
            lineInMorse = lineInMorse.Replace("q","--.- " );
            lineInMorse = lineInMorse.Replace("r",".-. "  );
            lineInMorse = lineInMorse.Replace("s","... "  );
            lineInMorse = lineInMorse.Replace("t","- "    );
            lineInMorse = lineInMorse.Replace("u","..- "  );
            lineInMorse = lineInMorse.Replace("v","...- " );
            lineInMorse = lineInMorse.Replace("w",".-- "  );
            lineInMorse = lineInMorse.Replace("x","-..- " );
            lineInMorse = lineInMorse.Replace("y","-.-- " );
            lineInMorse = lineInMorse.Replace("z","--.. " );
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

        /// <summary>
        /// Will take each character in the input string and replace it with its Morse code equivalent. Spaces will be a pipe character, and punctuation will be a double pipe.
        /// </summary>
        /// <param name="lineInEnglish">The string that will be replaced. The string will be overwritten in place with the new characters.</param>
        private static void ConvertDotnotationToAlphanumeric(ref string lineInEnglish)
        {
            // Replace each letter with its English equivalent NOTE: The largest morse symbols must be at the top of the list or it will not work as expected.
            lineInEnglish = lineInEnglish.Replace("-----","0");
            lineInEnglish = lineInEnglish.Replace(".----","1");
            lineInEnglish = lineInEnglish.Replace("..---","2");
            lineInEnglish = lineInEnglish.Replace("...--","3");
            lineInEnglish = lineInEnglish.Replace("....-","4");
            lineInEnglish = lineInEnglish.Replace(".....","5");
            lineInEnglish = lineInEnglish.Replace("-....","6");
            lineInEnglish = lineInEnglish.Replace("--...","7");
            lineInEnglish = lineInEnglish.Replace("---..","8");
            lineInEnglish = lineInEnglish.Replace("----.","9");
            lineInEnglish = lineInEnglish.Replace("-..." ,"b");
            lineInEnglish = lineInEnglish.Replace("-.-." ,"c");
            lineInEnglish = lineInEnglish.Replace("..-." ,"f");
            lineInEnglish = lineInEnglish.Replace("...." ,"h");
            lineInEnglish = lineInEnglish.Replace(".---" ,"j");
            lineInEnglish = lineInEnglish.Replace(".-.." ,"l");
            lineInEnglish = lineInEnglish.Replace(".--." ,"p");
            lineInEnglish = lineInEnglish.Replace("--.-" ,"q");
            lineInEnglish = lineInEnglish.Replace("...-" ,"v");
            lineInEnglish = lineInEnglish.Replace("-..-" ,"x");
            lineInEnglish = lineInEnglish.Replace("-.--" ,"y");
            lineInEnglish = lineInEnglish.Replace("--.." ,"z");
            lineInEnglish = lineInEnglish.Replace("-.."  ,"d");
            lineInEnglish = lineInEnglish.Replace("--."  ,"g");
            lineInEnglish = lineInEnglish.Replace("-.-"  ,"k");
            lineInEnglish = lineInEnglish.Replace("---"  ,"o");
            lineInEnglish = lineInEnglish.Replace(".-."  ,"r");
            lineInEnglish = lineInEnglish.Replace("..."  ,"s");
            lineInEnglish = lineInEnglish.Replace("..-"  ,"u");
            lineInEnglish = lineInEnglish.Replace(".--"  ,"w");
            lineInEnglish = lineInEnglish.Replace(".-"   ,"a");
            lineInEnglish = lineInEnglish.Replace(".."   ,"i");
            lineInEnglish = lineInEnglish.Replace("--"   ,"m");
            lineInEnglish = lineInEnglish.Replace("-."   ,"n");
            lineInEnglish = lineInEnglish.Replace("."    ,"e");
            lineInEnglish = lineInEnglish.Replace("-"    ,"t");
            lineInEnglish = lineInEnglish.Replace("||"  ,".");
            lineInEnglish = lineInEnglish.Replace("|"    ," ");
        }
    }
}