using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Explore
{
    public class StringToInteger
    {
        public static int MyAtoi(string str)
        {
            str = str.Trim();
            if (string.IsNullOrWhiteSpace(str)) return 0;

            var result = 0;
            var index = 0;
            var isNegative = false;

            while(index < str.Length && str[index].Equals(' '))
            {
                index++;
            }

            if (str[index] == '-')
                isNegative = true;

            if (isNegative || str[index] == '+')
                index++;

            while (index < str.Length && char.IsDigit(str[index]))
            {
                //this is to get the actual digit of the string based on ASCII characters
                //0 = 48 in ASCII code
                var currentDigit = str[index] - '0';

                if (result > (int.MaxValue / 10) || (result == (int.MaxValue / 10) && currentDigit > 7))
                    return isNegative ? int.MinValue : int.MaxValue;

                //build up the integer based on the decimal base we are in
                result = (result * 10) + currentDigit;

                index++;
            }

            return isNegative ? -result : result;
        }
    }
}
