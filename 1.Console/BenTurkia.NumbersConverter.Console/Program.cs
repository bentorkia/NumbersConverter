using BenTurkia.NumbersConverter.Business;
using BenTurkia.NumbersConverter.Business.Contracts;
using BenTurkia.NumbersConverter.Utilities.SpecialKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenTurkia.NumbersConverter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(" Please write your Number: ");
            var input = System.Console.ReadLine();

            while (input.All(char.IsNumber) && !string.IsNullOrEmpty(input))
            {
                var number = int.Parse(input);

                if (number < SpecialRomanKeys.MinRomanValue || number > SpecialRomanKeys.MaxRomanValue)
                {
                    System.Console.WriteLine($" -> Error: The number should be between {SpecialRomanKeys.MinRomanValue} and {SpecialRomanKeys.MaxRomanValue}. Please Try again..");
                }
                else
                {
                    try
                    {
                        System.Console.WriteLine($" Result: {BusinessFactory.Service<IRomanBO>().ConvertNumberToRomanNumeral(number)}");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine( $" -> Error: {ex.Message}");
                    }
                }

                System.Console.WriteLine("---------------------------");
                System.Console.WriteLine(" Please write your Number: ");
                input = System.Console.ReadLine();
            }
        }
    }
}
