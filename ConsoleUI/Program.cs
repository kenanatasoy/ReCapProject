using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            GetAllCars(carManager);

            Console.WriteLine();

            foreach (var car in carManager.GetCarsByBrandId(6))
            {
                Console.WriteLine(car.CarId + " id numarasına sahip araba: " + car.ModelYear + " Model ve günlük fiyatı da ₺" + car.DailyPrice);
            }

            Console.WriteLine();

            //carManager.Add(new Car { BrandId = 4, ColorId = 3, DailyPrice = 0, ModelYear = 2020, Description = "" });
            //brandManager.Add(new Brand { Name = "GM" });

            //colorManager.Add(new Color {Name="Turuncu"});

            //Console.WriteLine();

            Console.WriteLine(carManager.GetByCarId(6).CarId + " id numarasına sahip araba: " + carManager.GetByCarId(6).ModelYear + " Model " + brandManager.GetByBrandId(4).Name);

            Console.WriteLine();

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetail.CarId + ". Araba: " + carDetail.CarColorName + " bir " + carDetail.CarBrandName + " ve günlük kirası: ₺" + carDetail.DailyPrice);
            }

        }




        private static void GetAllCars(CarManager carManager)
        {
            Console.OutputEncoding = Encoding.Unicode;

            foreach (var car in carManager.GetAll())
            {

                Console.WriteLine("{0}. Araba: {1} Model, Günlük Kira ₺{2}", car.CarId, car.ModelYear, car.DailyPrice);

            }
        }
    }
}
