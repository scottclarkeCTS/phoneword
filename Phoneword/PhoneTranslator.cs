//This is the part that translates the number
using System.Text;

namespace Core
{
    //This declares the class called 'PhonewordTranslator'
    public static class PhonewordTranslator
    {
        //This line gets the raw string
        public static string ToNumber(string raw)
        {
            //If there is nothing, then it will return nothing
            if (string.IsNullOrWhiteSpace(raw))
                return null;
            //This capitalises each word
            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in raw)
            {
                if (" -0123456789".Contains(c))
                    newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                    // Bad character?
                    else
                        return null;
                }
            }
            //This prints the new, translated number
            return newNumber.ToString();
        }
        //This is a boolean that decides whether it contains keString or not
        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }
        //Thi shows what letters are translated into their particular numbers
        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                //This adds two, so if it is a 'B', then it will add 2 as B is actually on the number 3.
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}