namespace RevenueRecogniction.DomainModel
{
    /// <summary>
    /// Recognizes the whole revenue immediately
    /// </summary>
    class CompleteRecognitionStrategy : RecognitionStrategy
    {
        public override void CalculateRevenueRecognitions(Contract contract)
        {
            contract.AddRevenueRecognition(new RevenueRecognition(contract.Revenue, contract.WhenSigned));
        }
    }
}