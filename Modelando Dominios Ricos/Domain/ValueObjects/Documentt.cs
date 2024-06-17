using Domain.Enums;
using Flunt.Validations;
using Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Documentt : ValueObject
    {
        public Documentt(string number, EDocumentType type)
        {
            Number = number;
            Type = Type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(),"Document.Number","Documento Inválido"));
        }

        public string Number { get; private set; }

        public EDocumentType Type { get; private set; }


        private bool Validate()
        {
            if(Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;

            if(Type == EDocumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}
