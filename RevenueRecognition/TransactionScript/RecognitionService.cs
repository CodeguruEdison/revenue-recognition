using System;
using System.Data.SqlClient;
using RevenueRecogniction.BasePatterns;

namespace RevenueRecogniction.TransactionScript
{
    public class RecognitionService
    {
        private readonly Gateway _gateway;

        public RecognitionService(Gateway gateway)
        {
            _gateway = gateway;
        }

        // A transaction script
        public Money RecognizedRevenue(long contractNumber, DateTime asOf)
        {
            // This logic is certainly simple enough for a transaction script.
            // A Domain Model would certainly be an overkill.
            var result = Money.Dollars(0);
            try
            {
                var dr = _gateway.FindRecognitionsFor(contractNumber, asOf);
                while (dr.Read())
                    result = result.Add(Money.Dollars(dr.GetDouble(0)));
                return result;
            }
            catch (SqlException e)
            {
                throw new ApplicationException(e.Message, e);
            }
        }

        // A transaction script
        public void CalculateRevenueRecognitions(long contractNumber)
        {
            var contracts = _gateway.FindContract(contractNumber);
            contracts.Read();
            var totalRevenue = Money.Dollars(contracts.GetDouble(0));
            var recognitionDate = contracts.GetDateTime(1);
            
            // Here comes the real domain logic in this example.
            // These rules may be simple enough for a transaction script,
            // but if the rules become much more complicate, consider using a Domain Model
            string type = contracts.GetString(2);
            if (type == "S")
            {
                var allocation = totalRevenue.Allocate(3);
                _gateway.InsertRecognition(contractNumber, allocation[0], recognitionDate);
                _gateway.InsertRecognition(contractNumber, allocation[1], recognitionDate.AddDays(60));
                _gateway.InsertRecognition(contractNumber, allocation[2], recognitionDate.AddDays(90));
            }
            else if (type == "W")
            {
                _gateway.InsertRecognition(contractNumber, totalRevenue, recognitionDate);
            }
            else if (type == "D")
            {
                var allocation = totalRevenue.Allocate(3);
                _gateway.InsertRecognition(contractNumber, allocation[0], recognitionDate);
                _gateway.InsertRecognition(contractNumber, allocation[1], recognitionDate.AddDays(30));
                _gateway.InsertRecognition(contractNumber, allocation[2], recognitionDate.AddDays(60));
            }
        }
    }
}