using System;
using System.Globalization;

namespace DeependCheque.Models
{
    public class AmountToWords
    {
        /// <summary>
        /// Change the given amount in number to words
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>Amount in words</returns>
        public string ChangeAmountToWords(double number)
        {
            return this.ChangeAmountToWords(Convert.ToString(number, CultureInfo.InvariantCulture));
        }


        /// <summary>
        /// Change the given amount in number to words
        /// </summary>
        /// <param name="number">number in string format</param>
        /// <returns>Amount in words</returns>
        private string ChangeAmountToWords(string number)
        {
            string words = "";
            int decimalPlace = number.IndexOf(".", StringComparison.Ordinal);
            if (decimalPlace > 0)
            {
                string wholeNo = number.Substring(0, decimalPlace);
                string points = number.Substring(decimalPlace + 1);
                string dollarStr = Convert.ToInt32(wholeNo) > 1 ? " Dollars" : " Dollar";

                if (Convert.ToInt32(points) > 0)
                {
                    words = string.Format("{0}{1}{2}{3}", this.TranslateWholeNumber(wholeNo),
                                                                dollarStr, " and ", this.TranslateToCents(Convert.ToInt32(points)));
                }
            }
            else
            {
                string dollarStr = Convert.ToInt32(number) > 1 ? " Dollars" : " Dollar";
                words = string.Format("{0}{1}", this.TranslateWholeNumber(number), dollarStr);
            }

            return words.ToUpper();
        }



        /// <summary>
        /// Translate whole number into words
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>Whole number in words</returns>
        private string TranslateWholeNumber(string number)
        {
            string word = "";

            try
            {
                bool isDone = false;
                double amount = Convert.ToDouble(number);

                if (amount > 0)
                {
                    int numDigits = number.Length;
                    int position = 0;
                    string place = ""; // ? For grouping name like Hundreds, Thousands, Million etc

                    switch (numDigits)
                    {
                        case 1: // ? Ones' range
                            word = this.Ones(number);
                            isDone = true;
                            break;
                        case 2: // ? Tens' range
                            word = this.Tens(number);
                            isDone = true;
                            break;
                        case 3:// ? Hundreds' range
                            position = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4: // ? Thousands' range
                        case 5:
                        case 6:
                            position = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7:// ? Millions' range
                        case 8:
                        case 9:
                            position = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10: // ? Billions's range
                            position = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        // PS: Add more cases if we need for trillion or above it
                        default:
                            isDone = true;
                            break;
                    }

                    if (!isDone) // ? Is translation done
                    {
                        word = this.TranslateWholeNumber(number.Substring(0, position)) + place +
                               this.TranslateWholeNumber(number.Substring(position));
                    }
                }
            }
            catch
            {
                // Ignore
            }

            return word.ToUpper().Trim();
        }


        /// <summary>
        /// Translate two digits numbers (after decimal points) to Cents
        /// </summary>
        /// <param name="number">Two digits number after decimal points</param>
        /// <returns></returns>
        private string TranslateToCents(int number)
        {
            string word = number > 9 ? this.Tens(number.ToString()) : this.Ones(number.ToString());
            string centStr = Convert.ToInt32(number) > 1 ? " Cents" : " Cent";

            return string.Format("{0}{1}", word, centStr);
        }


        /// <summary>
        /// Gets tens' digit in word
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private string Tens(string digit)
        {
            int digt = Convert.ToInt32(digit);
            string name = null;

            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = this.Tens(digit.Substring(0, 1) + "0") + " " + this.Ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }


        /// <summary>
        /// Gets ones' digit in word
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private string Ones(string digit)
        {
            return this.Ones(Convert.ToInt32(digit));
        }


        /// <summary>
        /// Gets ones' digit in word
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private string Ones(int digit)
        {
            string name = "";
            switch (digit)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
    }
}
