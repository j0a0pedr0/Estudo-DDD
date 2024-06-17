using Flunt.Validations;
using Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName,3,"Name.FirstName","Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40,"Name.FirstName","Nome deve ter no maximo 40 caracteres")
                .HasMaxLen(LastName, 40, "Name.LastName","Sobrenome deve ter mo maximo 40 caracteres"));


        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
