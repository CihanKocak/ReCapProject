﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByCarId(int carId);
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetByDailyPrice(decimal min, decimal max);

        List<CarDetailDto> GetCarDetails();

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
