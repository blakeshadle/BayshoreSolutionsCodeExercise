using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayshoreSolutions.Framework
{
    public class NumberConverter
    {
        private decimal number;

        public NumberConverter(decimal _number)
        {
            number = _number;
        }

        public string Convert()
        {
            int numbers = (int)number;
            decimal decimals = number - numbers;
            string sDecimals = decimals.ToString();
            string finalDecimal = "00";
            if (decimals > 0) {
                if (sDecimals.Substring(sDecimals.IndexOf('.') + 1).Length == 1) {
                    finalDecimal = sDecimals.Substring(sDecimals.IndexOf('.') + 1) + "0";
                }
                else {
                    finalDecimal = sDecimals.Substring(sDecimals.IndexOf('.') + 1, 2);
                }
            }

            StringBuilder dollars = new StringBuilder();

            string money = ConvertNumberToText(numbers);
            string cents = $"and {finalDecimal}/100";
            dollars.Append(UpperCaseFirstLetter(money.ToLower()));
            dollars.Append(cents);

            return dollars.ToString();
        }

        private string ConvertNumberToText(int number)
        {
            string output = string.Empty;
            string[] digits1 = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
                 "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                 "Seventeen", "Eighteen", "Nineteen" };
            string[] digits2 = new string[] {
                "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy","Eighty", "Ninety"
            };

            if (number <= 19) {
                output = digits1[number - 1] + " ";
            }
            else if (number <= 99) {
                output = digits2[number / 10 - 2] + "-" + ConvertNumberToText(number % 10);
            }
            else if (number <= 199) {
                output = "One Hundred " + ConvertNumberToText(number % 100);
            }
            else if (number <= 999) {
                output = ConvertNumberToText(number / 100) + "Hundred " + ConvertNumberToText(number % 100);
            }
            else if (number <= 1999) {
                output = "One Thousand " + ConvertNumberToText(number % 1000);
            }
            else if (number <= 999999) {
                output = ConvertNumberToText(number / 1000) + "Thousand " + ConvertNumberToText(number % 1000);
            }
            else if (number <= 1999999) {
                output = "One Million " + ConvertNumberToText(number % 1000000);
            }
            else if (number <= 999999999) {
                output = ConvertNumberToText(number / 1000000) + "Million " + ConvertNumberToText(number % 1000000);
            }
            else if (number <= 1999999999) {
                output = "One Billion " + ConvertNumberToText(number % 1000000000);
            }

            return output;
        }

        private string UpperCaseFirstLetter(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
