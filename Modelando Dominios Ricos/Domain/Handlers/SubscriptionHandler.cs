using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Flunt.Notifications;
using Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {

        private readonly IStudentRepository _repository;


        public SubscriptionHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar o seu cadastro");
            }

            // Verificar se o documento já está cadastrado
            if(_repository.DocumentExists(command.Document))
            {
                AddNotification("Document","Este CPF já está em uso");
            }

            // Verificar se E-mail já está cadastrado
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Document", "Este E-mail já está em uso");
            }

            // Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Documentt(command.Document, Enums.EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar as Entidades
            var student = new Student(name,document,email);

            var subscription = new Subscription(null);

            var payment = new BoletoPayment(
                command.BarCode, 
                command.BoletoNumber, 
                command.PaidDate, 
                command.ExpireDate, 
                command.Total, 
                command.TotalPaid,
                command.Payer, 
                new Documentt(command.PayerDocument, command.PayerDocumentType),
                address, 
                email
            );


            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            // Aplicar as Validações

            // Salvar as Informações

            // Enviar E-mail de boas vindas

            // Retornar informações


            return new CommandResult(true, "");
        }
    }
}
