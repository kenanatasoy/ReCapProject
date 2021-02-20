using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //CarManager carManager = new CarManager(new EfCarDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());

            //GetAllCars(carManager);

            //List<int> ids = new List<int> {3, 4, 6 };
            //var result = carManager.GetCarsByBrandIds(ids).Data;

            //foreach (var cars in result.OrderBy(c=>c.BrandId))
            //{
            //    Console.WriteLine(cars.CarId);
            //} -- multiple selection

            rentalManager.Add(new Rental { CarId = 3, CustomerId = 2, RentDate = new DateTime(2021, 01, 10), ReturnDate = new DateTime(2020, 12, 30) });
            
            foreach (var rentDetail in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rentDetail.CustomerName + " müşterisi " + rentDetail.CarName + " arabası " + rentDetail.RentDate + " tarihinde kiralandı");
            }

            Console.WriteLine();
            
        }




        //private static void GetAllCars(CarManager carManager)
        //{
        //    Console.OutputEncoding = Encoding.Unicode;

        //    foreach (var car in carManager.GetAll().Data)
        //    {

        //        Console.WriteLine("{0}. Araba: {1} Model, Günlük Kira ₺{2}", car.CarId, car.ModelYear, car.DailyPrice);

        //    }
        //}
    }
}
