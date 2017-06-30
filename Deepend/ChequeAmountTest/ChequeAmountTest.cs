using System;
using DeependCheque.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequeAmountTest
{
    [TestClass]
    public class ChequeAmountTest
    {
        [TestMethod]
        public void CheckOneDollar()
        {
            var converter = new AmountToWords();
            string result = converter.ChangeAmountToWords(1);
            Assert.AreEqual("ONE DOLLAR", result);
        }


        [TestMethod]
        public void CheckOneDollarOneCent()
        {
            var converter = new AmountToWords();
            string result = converter.ChangeAmountToWords(1.01);
            Assert.AreEqual("ONE DOLLAR AND ONE CENT", result);
        }


        [TestMethod]
        public void Check_1217Dollars_5Cents()
        {
            var converter = new AmountToWords();
            string result = converter.ChangeAmountToWords(1217.05);
            string expected = "ONE THOUSAND TWO HUNDRED SEVENTEEN DOLLARS AND FIVE CENTS";

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Check_12345678Dollars_99Cents()
        {
            var converter = new AmountToWords();
            string result = converter.ChangeAmountToWords(12345678.99);
            string expected = "TWELVE MILLION THREE HUNDRED FOURTY FIVE THOUSAND SIX HUNDRED SEVENTY EIGHT DOLLARS AND NINETY NINE CENTS";

            Assert.AreEqual(expected, result);
        }
    }
}
