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

            Console.OutputEncoding = Encoding.Unicode;

            foreach (var car in carManager.GetAll())
            {

                Console.WriteLine("{0}. Araba: {1} Model, Günlük Kira ₺{2}", car.Id, car.ModelYear, car.DailyPrice);
                
            }

            Console.WriteLine();

            foreach (var car in carManager.GetCarsByBrandId(6))
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.DailyPrice);
            }

            Console.WriteLine();

            //carManager.Add(new Car { BrandId = 4, ColorId = 3, DailyPrice = 0, ModelYear = 2020, Description = "" });
            //brandManager.Add(new Brand { Name = "GM" });


            Console.WriteLine(carManager.GetByCarId(6).Id + " id numarasına sahip araba");            


        }
    }
}
