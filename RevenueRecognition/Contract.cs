using System;
using System.Collections.Generic;

namespace RevenueRecogniction
{
    /// <summary>
    /// A contract has a certain revenue, and pertains to a certain product.
    /// Depending on the product, a number of revenue recognitions exist.
    /// How the revenue is split across the revenue recognitions depends on the product.
    /// </summary>
    class Contract
    {
        private long _id;
        private readonly Product _product;
        
        private readonly IList<RevenueRecognition> _revenueRecognitions = new List<RevenueRecognition>();
           
        public Money Revenue { get; private set;}
        public DateTime WhenSigned { get; private set; }

        public Contract(Product product, Money revenue, DateTime whenSigned, long id)
        {
            _product = product;
            Revenue = revenue;
            WhenSigned = whenSigned;
            _id = id;
        }

        /// <summary>
        /// How much of the contract's revenue is recognized by a certain date?
        /// </summary>
        /// <param name="asOf"></param>
        /// <returns></returns>
        public Money RecognizedRevenue(DateTime asOf)
        {
            var result = Money.Dollars(0);
            foreach (var recognition in _revenueRecognitions)
            {
                if (recognition.IsRecognizedBy(asOf))
                    result = result.Add(recognition.Amount);
            }
            return result;
        }

        public void AddRevenueRecognition(RevenueRecognition revenueRecognition)
        {
            _revenueRecognitions.Add(revenueRecognition);
        }

        public void CalculateRecognitions()
        {
            _product.CalculateRevenueRecognitions(this);
        }
    }
}