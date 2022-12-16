using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Repositories.Interfaces
{
    public interface ICarRepository : IRepository
    {
        Task AddOrUpdate(short year, string make, string model);
    }
}
