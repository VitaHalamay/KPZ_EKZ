using KPZ_EKZ.Data.Entities;
using KPZ_EKZ.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Repositories
{
    public abstract class AbstractRepository : IRepository
    {
        protected DataContext Context;
        protected AbstractRepository(DataContext context)
        {
            Context = context;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetCreated(AbstractEntity entity)
        {
            entity.Created = DateTime.UtcNow;
        }
        public void SetUpdated(AbstractEntity entity)
        {
            entity.Updated = DateTime.UtcNow;
        }
    }
}
