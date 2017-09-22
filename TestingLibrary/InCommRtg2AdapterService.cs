
using System.Globalization;
//using Giftango.GiftCardProcessing.Common;
using InComm.Web.AdapterService;
//using InComm.Web.AdapterService.Common;

namespace TestingLibrary
{
    class InCommRtg2AdapterService
    {
        /*
        
        private void UpdateAmountWithCurrentBalanceIfRequired(IRequest request)
        {
            if (!IsCurrentBalanceRequired(request)) return;
            request.Amount = GetBalance(request, request.TransferSourceCardNumber, null).ToString(CultureInfo.InvariantCulture);
        }

        private bool IsCurrentBalanceRequired(IRequest request)
        {
            return (request != null) &&
                   (request.TransactionType == GieTransactionType(TransactionType.BalanceTransfer)) &&
                   (request.Amount.IsDecimalValueZero());
            // TODO: AND it's Sheetz!
        }
    
        */

        /*
        private decimal GetBalance(IRequest mainRequest)
        {
            if (mainRequest == null)
                return 0M;
            return GetBalance(mainRequest, mainRequest.GiftCardNumber);
        }
        private decimal GetBalance(IRequest mainRequest, string cardNumber)
        {
            if (mainRequest == null)
                return 0M;
            return GetBalance(mainRequest, cardNumber, mainRequest.GiftCardCID);
        }
        private decimal GetBalance(IRequest mainRequest, string cardNumber, string pin)
        {
            if (mainRequest == null)
                return 0M;

            IResponse response = new AdapterServiceResponse();
            IRequest balanceRequest = new AdapterServiceRequest();
            //balanceRequest.Load(mainRequest);
            balanceRequest.TransactionType = GieTransactionType(TransactionType.BalanceInquiry);
            balanceRequest.GiftCardNumber = cardNumber;
            balanceRequest.GiftCardCID = pin;

            // TODO: Add back when code restored:
            //if (!BalanceInquiry(balanceRequest, response))
            //    throw new BalanceInquiryException(string.Format("Error retrieving balance.  Response: {0}", response.TransactionStatusDesc));

            decimal balance;
            if (string.IsNullOrWhiteSpace(response.Balance))
                return 0M;
            if (!decimal.TryParse(response.Balance, out balance))
                throw new BalanceInquiryException(string.Format("Invalid balance amount returned: {0}", response.Balance));
            return balance;
        }

        private string GieTransactionType(Giftango.GiftCardProcessing.Common.TransactionType gieTransactionType)
        {
            return ((int)gieTransactionType).ToString(CultureInfo.InvariantCulture);
        }
        */
    }
}
