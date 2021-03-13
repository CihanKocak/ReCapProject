using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors 
                             on c.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 UserId = cu.UserId,
                                 CarId = c.CarId,
                                 CompanyName = cu.CompanyName,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
