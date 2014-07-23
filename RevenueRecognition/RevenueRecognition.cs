using System;

namespace RevenueRecogniction
{
    class RevenueRecognition
    {
        private DateTime _date;
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
