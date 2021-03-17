using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<DtoCustomerDetail> GetCustomersDetail()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from us in context.Users
                             join cus in context.Customers
                             on us.Id equals cus.UserId
                             select new DtoCustomerDetail
                             {
                                 UserId = us.Id,
                                 UserName = us.FirstName + " " + us.LastName,
                                 Email = us.Email,
                                 CompanyName = cus.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}