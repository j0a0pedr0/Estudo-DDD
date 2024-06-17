using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string ducument);

        bool EmailExists(string email);

        void CreatedSubscription(Student student);
    }
}
