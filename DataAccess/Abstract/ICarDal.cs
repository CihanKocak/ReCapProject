using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetail(int carId);
    }
}