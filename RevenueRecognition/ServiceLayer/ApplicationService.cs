using System;
using RevenueRecogniction.BasePatterns;
using RevenueRecogniction.DomainModel;

namespace RevenueRecogniction.ServiceLayer
{
    public class ApplicationService
    {
        protected IEmailGateway GetEmailGateway()
        {
            throw new NotImplementedException();
        }

        protected IIntegrationGateway GetIntegrationGateway()
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmailGateway
    {
        // Gateway pattern
        void SendEmailmessage(string toAddress, string subject, string body);
    }

    public interface IIntegrationGateway
    {
        // Gateway pattern
        void PublishRevenueRecognitionCalculation(Contract contract);
    }

    public class RecognictionService : ApplicationService
    {
        // According to Fowler, use Service Layer in case of "Complex responses in use cases 
        // involving multiple transactional resources".
        //
        // This method is inherently transactional because persistent contract objects are modified
        // via addition of revenue recognitions, messages are enqueued in message-oriented middleware,
        // and e-mail messages are sent. All of these responses must be transacted atomically because
        // we don't want to send e-mail and publish messages to other applications if the contract
        // changes fail to persist.
        //
        // This method is an example of operation script implementation variation of Service Layer:
        // It scripts the application logic of the response required by the application's use cases,
        // but it delegates to domain object classes for domain logic.
        //
        // Side note: separating the application logic of integration and e-mail from the domain logic
        // of revenue recognition calculation facilitates changing the implementation of the Service Layer 
        // to e.g. use a workflow engine.

        public void CalculateRevenueRecognitions(long contractNumber)
        {

            var contract = Contract.ReadForUpdate(contractNumber);
            contract.CalculateRecognitions();

            GetEmailGateway().SendEmailmessage(contract.GetAdministratorEmailAddress(), "RE: Contract #" + contractNumber, contract + " has had revenue recognitions calculated");
            GetIntegrationGateway().PublishRevenueRecognitionCalculation(contract);
        }

        // This method is more an example of domain facade implementation variation
        public Money RecognizedRevenue(long contractNumber, DateTime asOf)
        {
            return Contract.Read(contractNumber).RecognizedRevenue(asOf);
        }
    }
}