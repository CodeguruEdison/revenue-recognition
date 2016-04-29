using System;

namespace RevenueRecogniction.BasePatterns
{
    // Note:
    // As I started implementing Fowler's Java-based Money class, I realized there are quite a few adaptions
    // that need to be done for C#, especially because .NET has no Currency class as Java does.
    // Therefore need to do more research on how to best implement Money in .NET.
    // See e.g. http://www.codeproject.com/Articles/28244/A-Money-type-for-the-CLR for a thourough
    // discussion of the matter, including source code. - jonsb

    public class Currency
    {
        public int GetDefaultFractionDigits()
        {
            return 2; // Means fraction has two digits; works for e.g. dollars, euro and kroner
        }
    }

    public class Money
    {
        private long _amount;
        private readonly Currency _currency;
        
        public Money(long amount, Currency currency)
        {
            _currency = currency;
            _amount = amount * CentFactor();
        }

        public Money(double amount, Currency currency)
        {
            _currency = currency;
            _amount = (long) Math.Round(amount * CentFactor()); // need to check up if this is correct
        }

        public Currency Currency
        {
            get { return _currency; }
        }
   
        private static readonly int[] Cents = { 1, 10, 100, 1000 }; // the number of base units in the currency, e.g. 100 cents in one dollar
        
        private int CentFactor()
        {
            return Cents[_currency.GetDefaultFractionDigits()];
        }

        public static Money Dollars(double amount)
        {
            return new Money(amount, new Currency());
        }

        public Money Add(Money money)
        {
            throw new NotImplementedException();
        }

        public Money[] Allocate(int p)
        {
            throw new NotImplementedException();
        }
    }
}
