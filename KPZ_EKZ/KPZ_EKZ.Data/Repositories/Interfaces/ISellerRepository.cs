using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Repositories.Interfaces
{
    public interface ISellerRepository : IRepository
    { 
        Task AddOrUpdate(string firstName, string lastName, string emailAddress, string phoneNumber, string accessCode);
    }
}
