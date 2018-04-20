using BenTurkia.NumbersConverter.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenTurkia.NumbersConverter.Business.Implementations
{
    public class RomanBO : IRomanBO
    {
        /// <summary>
        /// Convert a number to Roman numeral
        /// </summary>
        /// <param name="number">Represents the Input number</param>
        /// <returns>Returns a string value that represents the Roman numeral</returns>
        public string ConvertNumberToRomanNumeral(int number)
        {
            var numerations = new[] { 1, 10, 100, 1000 };
            var romanNumeralLetters = new[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            var numberLength = GetNumberLength(number);

            var romanNumber = string.Empty;

            var builder = new StringBuilder();
            builder.Append(romanNumber);

            for (int i = numberLength-1; i >= 0; i--)
            {
                if (number >= numerations[i])
                {
                    // Pick up the first digit of the number to process it
                    var firstDigit = number / numerations[i];

                    // Append the right Roman characters according to the first digit
                    switch (firstDigit)
                    {
                        case 1:
                        case 2:
                        case 3:
                            {
                                // handles the formats: (1000 -> M, MM, MM); (100 -> C, CC, CCC); (10 -> X, XX, XXX); (1 -> I, II, III)
                                for (int j = 0; j < firstDigit; j++)
                                {
                                    builder.Append(romanNumeralLetters[2 * i]);
                                }
                                romanNumber = builder.ToString();
                            }
                            break;
                        case 4:
                            {
                                // handles the formats: (100 -> CD); (10 -> XL); (1 -> IV)
                                builder.Append(romanNumeralLetters[2 * i]);
                                builder.Append(romanNumeralLetters[(2 * i) + 1]);
                            }
                            break;
                        case 5:
                            // handles the  formats: (100 -> D); (10 -> L); (1 -> V)
                            builder.Append(romanNumeralLetters[(2 * i) + 1]);
                            break;
                        case 6:
                        case 7:
                        case 8:
                            // handles the formats: (100 -> DC, DCC, DCCC); (10 -> LX, LXX, LXX); (1 -> VI, VII, VIII)
                            builder.Append(romanNumeralLetters[(2 * i) + 1]);
                            for (int j = 0; j < firstDigit - 5; j++)
                            {
                                builder.Append(romanNumeralLetters[(2 * i)]);
                            }
                            break;
                        case 9:
                            // handles the formats: (100 -> CM); (10 -> XC); (1 -> IX);
                            builder.Append(romanNumeralLetters[(2 * i)]);
                            builder.Append(romanNumeralLetters[(2 * i) + 2]);
                            break;
                    }
                }

                // Reduce the number to the lower numeration
                number %= numerations[i];
            }

            return builder.ToString();
        }

        /// <summary>
        /// Get the length of a number
        /// </summary>
        /// <param name="number">Represents the Input number</param>
        /// <returns>Returns an integer that represents the number's length</returns>
        private static int GetNumberLength(int number)
        {
            int length;
            var temp = 1;
            for (length = 0; number >= temp; length++)
            {
                temp *= 10;
            }
            return length;
        }
    }
}
