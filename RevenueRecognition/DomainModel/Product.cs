namespace RevenueRecogniction.DomainModel
{
    /// <summary>
    /// A product knows what kind of revenue recognition applies to it.
    /// </summary>
    public class Product
    {
        private string _name;
        private RecognitionStrategy _recognitionStrategy;

        public Product(string name, RecognitionStrategy recognitionStrategy)
        {
            _name = name;
            _recognitionStrategy = recognitionStrategy;
        }

        public static Product NewWordProcessor(string name)
        {
            return new Product(name, new CompleteRecognitionStrategy());
        }

        public static Product NewSpreadsheet(string name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(60, 90));
        }

        public static Product NewDatabase(string name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(30, 60));
        }

        public void CalculateRevenueRecognitions(Contract contract)
        {
            _recognitionStrategy.CalculateRevenueRecognitions(contract);
        }
    }
}