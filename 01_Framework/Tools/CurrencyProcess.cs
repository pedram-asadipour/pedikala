using System;
using System.ComponentModel.DataAnnotations;

namespace _01_Framework.Tools
{
    public class CurrencyProcess
    {
        public static double GetDiscountPrice(int discountRate, double unitPrice)
        {
            var divided = unitPrice * discountRate;
            var discount = divided / 100;
            var discountPrice = discount - unitPrice;
            return Math.Round(discountPrice);
        }
    }
}
