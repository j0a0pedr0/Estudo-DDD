using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode, 
            string boletoNumber, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            string payer, 
            Documentt document, 
            Address address, 
            Email email) : base(
                paidDate, 
                expireDate, 
                total, 
                totalPaid, 
                payer, 
                document, 
                address, 
                email)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; set; }

        public string BoletoNumber { get; set; }
    }

}
