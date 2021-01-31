using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Id : " + car.CarId + "\nBrand Name : " + car.BrandName + "\nBrand Id : " + car.BrandId + 
                    "\nColor : " + car.ColorId + "\nModel : " + car.ModelYear + "\nFuel Type : " + car.Description + 
                    "\nDaily Price : " + car.DailyPrice);

                Console.WriteLine("********************************");
            }

            Console.ReadLine();
        }
    }
}
