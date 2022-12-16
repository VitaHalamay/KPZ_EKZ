using KPZ_EKZ.Data.Entities;
using KPZ_EKZ.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Repositories
{
    public class SellerRepository : AbstractRepository, ISellerRepository
    {
        public SellerRepository(DataContext context) : base(context)
        {
        }
        public async Task AddOrUpdate(string firstName, string lastName, string emailAddress, string phoneNumber, string accessCode)
        {
            var sellerEntity = await Context.Sellers
                .FirstOrDefaultAsync(s => s.FirstName == firstName && s.LastName == lastName
                && s.EmailAddress == emailAddress && s.PhoneNumber == phoneNumber && s.AccessCode == accessCode);

            if (sellerEntity == null)
            {
                sellerEntity = new SellerEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    PhoneNumber = phoneNumber,
                    AccessCode = accessCode
                };
                SetCreated(sellerEntity);
                await Context.Sellers.AddAsync(sellerEntity);
            }
            else
            {
                SetUpdated(sellerEntity);
                Context.Sellers.Update(sellerEntity);
            }
        }
    }
}
