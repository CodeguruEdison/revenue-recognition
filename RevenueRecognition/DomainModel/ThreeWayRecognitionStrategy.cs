namespace RevenueRecogniction.DomainModel
{
    /// <summary>
    /// Splits the revenue into three equal parts, and recognizes the parts
    /// relative to two offsets (in days after when signed). The first part is
    /// recognized immediately.
    /// </summary>
    class ThreeWayRecognitionStrategy : RecognitionStrategy
    {
        private readonly int _firstRecognitionOffset;
        private readonly int _secondRecognitionOffset;

        public ThreeWayRecognitionStrategy(int firstRecognitionOffset, int secondRecognitionOffset)
        {
            _firstRecognitionOffset = firstRecognitionOffset;
            _secondRecognitionOffset = secondRecognitionOffset;
        }

        public override void CalculateRevenueRecognitions(Contract contract)
        {
            var allocation = contract.Revenue.Allocate(3);
            contract.AddRevenueRecognition(new RevenueRecognition(allocation[0], contract.WhenSigned));
            contract.AddRevenueRecognition(new RevenueRecognition(allocation[1], contract.WhenSigned.AddDays(_firstRecognitionOffset)));
            contract.AddRevenueRecognition(new RevenueRecognition(allocation[2], contract.WhenSigned.AddDays(_secondRecognitionOffset)));
        }
    }
}