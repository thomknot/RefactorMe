using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Utility
{
    public static class CurrencyExchange
    {
        public static double GetExchangeRate(string currency)
        {
            switch (currency)
            {
                case CurrencyType.UsDollar:
                    return 0.76;
                case CurrencyType.Euro:
                    return 0.67;
                default:
                    return 1; //default is no currency
            }
        }
    }

}
