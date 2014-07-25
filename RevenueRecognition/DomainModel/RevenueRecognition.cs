using System;
using RevenueRecogniction.BasePatterns;

namespace RevenueRecogniction.DomainModel
{
    public class RevenueRecognition
    {
        private readonly DateTime _date;
        public Money Amount { get; private set; }

        public RevenueRecognition(Money amount, DateTime date)
        {
            Amount = amount;
            _date = date;
        }

        public bool IsRecognizedBy(DateTime asOf)
        {
            return asOf >= _date;
        }
    }
}
