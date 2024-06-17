using Domain.ValueObjects;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : Entity
    {
        private IList<string> Notifications;

        private IList<Subscription> _subscriptions;

        public Student(Name name, Documentt document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
                
        }

        public Name Name { get; set; }
        public Documentt Document { get; private set; }
        public Email Email { get; private set; }
        public string Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription) 
        {
            //Se já tiver uma ssinatura ativa , cancela

            //Cancela todas as outras assinaturas, e coloca esta como principal
            foreach (var sub in Subscriptions)
                sub.Inactivate();

            _subscriptions.Add(subscription);
        }

    }
}
