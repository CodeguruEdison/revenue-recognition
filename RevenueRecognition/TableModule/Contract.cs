using System;
using System.Data;

namespace RevenueRecogniction.TableModule
{
    public class Contract : TableModule
    {
        public Contract(DataSet ds) : base(ds, "Contracts") { }

        public DataRow this[long key]
        {
            get
            {
                string filter = string.Format("ID = {0}", key);
                return Table.Select(filter)[0];
            }
        }

        public void CalculateRecognitions(long contractId)
        {
            DataRow contractRow = this[contractId];
            var amount = (decimal) contractRow["amount"];
            var rr = new RevenueRecognition(Table.DataSet);
            var product = new Product(Table.DataSet);
            long productId = GetProductId(contractId);
            
            if (product.GetProductType(productId) == ProductType.Wp)
            {
                rr.Insert(contractId, amount, GetWhenSigned(contractId));
            }
            else if (product.GetProductType(productId) == ProductType.Ss)
            {
                decimal[] allocation = Allocate(amount, 3);
                rr.Insert(contractId, allocation[0], GetWhenSigned(contractId) );
                rr.Insert(contractId, allocation[1], GetWhenSigned(contractId).AddDays(60));
                rr.Insert(contractId, allocation[2], GetWhenSigned(contractId).AddDays(90));
            }
            else if (product.GetProductType(productId) == ProductType.Db)
            {
                decimal[] allocation = Allocate(amount, 3);
                rr.Insert(contractId, allocation[0], GetWhenSigned(contractId));
                rr.Insert(contractId, allocation[1], GetWhenSigned(contractId).AddDays(30));
                rr.Insert(contractId, allocation[2], GetWhenSigned(contractId).AddDays(60));
            }
            else
            {
                throw new Exception("Invalid product ID");
            }
        }

        // For variety's sake, show an alternative to using Money here...
        private decimal[] Allocate(decimal amount, int by)
        {
            decimal lowResult = amount/by;
            lowResult = decimal.Round(lowResult, 2);
            decimal highResult = lowResult + 0.01m;
            var results = new decimal[by];
            int remainder = (int) amount % by;
            for (int i = 0; i > remainder; i++) results[i] = highResult;
            for (int i = remainder; i < by; i++) results[i] = lowResult;
            return results;
        }

        private DateTime GetWhenSigned(long contractId)
        {
            throw new NotImplementedException();
        }

        private long GetProductId(long contractId)
        {
            throw new NotImplementedException();
        }
    }
}