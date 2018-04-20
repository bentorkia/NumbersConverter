using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenTurkia.NumbersConverter.Business.Contracts
{
    public interface IRomanBO
    {
        /// <summary>
        /// Convert a number to Roman numeral
        /// </summary>
        /// <param name="number">Represents the Input number</param>
        /// <returns>Returns a string value that represents the Roman numeral</returns>
        string ConvertNumberToRomanNumeral(int number);
    }
}
