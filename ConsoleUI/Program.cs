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
            UserAddTest();

            CustomerAddTest();

            RentalAddTest();

            CarGetAllTest();

            GetCarsByCarIdTest();

            GetCarsByBrandIdTest();

            GetCarsByColorIdTest();

            GetByDailyPriceTest();

            BrandAddTest();

            ColorAddTest();

            CarAddTest();

            CarUpdateTest();

            BrandUpdateTest();

            ColorUpdateTest();

            CarDeleteTest();

            BrandDeleteTest();

            ColorDeleteTest();

            BrandsGetByBrandIdTest();

            BrandGetAllTest();

            ColorsGetByColorIdTest();

            ColorGetAllTest();

            GetCarDetailsTest();

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 4,
                ColorId = 4,
                ModelYear = "2020",
                Description = "Hybrid",
                DailyPrice = 0 // Sıfır girildiğinde hata mesajı alındı.Test Başarılı!
            });

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand
            {
                BrandId = 5,
                BrandName = "J" //Marka ismi minimum 2 karakter olmalı hata mesajı alındı.Test Başarılı!
            });

            Console.ReadLine();
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 3,
                RentDate = new DateTime(2021, 2, 12),
                ReturnDate = new DateTime(2021, 2, 19)
            });

            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                UserId = 1,
                CompanyName = "Abc Holding"
            });
        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                FirstName = "Cihan",
                LastName = "Koçak",
                Email = "chnkck1@gmail.com",
                Password = "12345"
            });
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Id : " + car.CarId + "\nBrand Name : " + car.BrandName +
                        "\nColor Name : " + car.ColorName + "\nDaily Price : " + car.DailyPrice);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Brand Id : " + brand.BrandId + "\nBrand Name : " + brand.BrandName);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("Color Id : " + color.ColorId + "\nColor Name : " + color.ColorName);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorsGetByColorIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetByColorId(1);

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("Color Id : " + color.ColorId + "\nColor Name : " + color.ColorName);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandsGetByBrandIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetByBrandId(3);

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Brand Id : " + brand.BrandId + "\nBrand Name : " + brand.BrandName);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Delete(new Color
            {
                ColorId = 1006
            });
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand
            {
                BrandId = 1006
            });
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car
            {
                CarId = 1008
            });
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color
            {
                ColorId = 1006,
                ColorName = "Darkblue"
            });
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand
            {
                BrandId = 1006,
                BrandName = "Volkswagen"
            });
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            {
                CarId = 1008,
                BrandId = 1006,
                ColorId = 1006,
                ModelYear = "2014",
                Description = "Diesel",
                DailyPrice = 900
            });
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 1006,
                ColorId = 1006,
                ModelYear = "2015",
                Description = "Gasoline",
                DailyPrice = 1000
            });
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color
            {
                ColorName = "Green"
            });
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand
            {
                BrandName = "Jaquar"
            });
        }

        private static void GetByDailyPriceTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByDailyPrice(300, 400);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Id : " + car.CarId + "\nDaily Price : " + car.DailyPrice);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsByColorId(2);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Color Id : " + car.ColorId);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsByBrandId(1);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Brand Id : " + car.BrandId);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByCarIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsByCarId(3);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Id : " + car.CarId);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Id : " + car.CarId + "\nBrand Id : " + car.BrandId +
                        "\nColor Id : " + car.ColorId + "\nModel : " + car.ModelYear + "\nFuel Type : " + car.Description +
                        "\nDaily Price : " + car.DailyPrice);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
