using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class CreditPayment : Payment
    {
        public CreditPayment(
            string cardHolderName, 
            string cardNumber, 
            string lastTransactionNumber, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            string payer, 
            Documentt document, 
            Address address, 
            Email email) : base (
                paidDate, 
                expireDate, 
                total, 
                totalPaid, 
                payer, 
                document, 
                address, 
                email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }

        public string LastTransactionNumber { get; set; }

    }

}
