using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Id : " + car.CarId + "\nBrand Id : " + car.BrandId +
                    "\nColor Id : " + car.ColorId + "\nModel : " + car.ModelYear + "\nFuel Type : " + car.Description + 
                    "\nDaily Price : " + car.DailyPrice);

                Console.WriteLine("********************************");
            }

            foreach (var car in carManager.GetCarsByCarId(5))
            {
                Console.WriteLine("Car Id : " + car.CarId);

                Console.WriteLine("********************************");
            }

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Brand Id : " + car.BrandId);

                Console.WriteLine("********************************");
            }

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("Color Id : " + car.ColorId);

                Console.WriteLine("********************************");
            }

            foreach (var car in carManager.GetByDailyPrice(300,400))
            {
                Console.WriteLine("Car Id : " + car.CarId + "\nDaily Price : " + car.DailyPrice);

                Console.WriteLine("********************************");
            }
            foreach (var brand in brandManager.GetByBrandId(3))
            {
                Console.WriteLine("Brand Id : " + brand.BrandId + "\nBrand Name : " + brand.BrandName);

                Console.WriteLine("********************************");
            }

            foreach (var color in colorManager.GetByColorId(1))
            {
                Console.WriteLine("Color Id : " + color.ColorId + "\nColor Name : " + color.ColorName);

                Console.WriteLine("********************************");
            }

            carManager.Add(new Car
            {
                BrandId = 4,
                ColorId = 4,
                ModelYear = "2020",
                Description = "Hybrid",
                DailyPrice = 0 // Sıfır girildiğinde hata mesajı alındı.Test Başarılı!
            });

            brandManager.Add(new Brand
            {
                BrandId = 5,
                BrandName = "J" //Marka ismi minimum 2 karakter olmalı hata mesajı alındı.Test Başarılı!
            });

            brandManager.Add(new Brand
            {
                BrandName = "Tesla" // Marka Başarılı bir şekilde eklendi!
            });

            colorManager.Add(new Color
            {
                ColorName = "Yellow" // Renk Başarılı bir şekilde eklendi!
            });

            carManager.Add(new Car
            {
                BrandId = 4,
                ColorId = 4,
                ModelYear = "2016",
                Description = "Hybrid",
                DailyPrice = 750 // Araba Başarılı bir şekilde eklendi!
            });
            Console.ReadLine();
        }
    }
}
