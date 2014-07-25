namespace RevenueRecogniction.DomainModel
{
    public abstract class RecognitionStrategy
    {
        public abstract void CalculateRevenueRecognitions(Contract contract);
    }
}
