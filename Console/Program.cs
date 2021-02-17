using Business.Abstract;
using Business.Concrete;
using Data_Access.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarDetails();
            // ColorDetails();
            // BrandDetails();
            //CustomerDetails();
            RentalDetails();

        }

        private static void RentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("Araba ID\t|\tMüşteri ID\t|\tKiralanma ID\t|\tKiralanma Tarihi\t|\tGeri Getirme Tarihi");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("{0}\t|\t{1}\t|\t{2}\t|\t{3}\t|\t{4}", rental.CarID, rental.CustomerId, rental.RentalId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void CustomerDetails()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("Müşteri ID | Kurum Adı");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0} \t|\t {1}", customer.UserId, customer.CompanyName);
            }
        }

        private static void BrandDetails()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Marka adı | Marka ID");
            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} | {1}", brands.BrandID, brands.BrandName);
            }
        }

        private static void ColorDetails()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Renk adı | Renk ID");
            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} | {1}", colors.ColorName, colors.ColorID);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("ID | Renk ID | Marka ID | Araba Adı | Günlük Fiyatı | Açıklaması");
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} \t| {1} \t| {2} \t| {3} \t| {4} \t| {5}", cars.CarID
                    , cars.ColorID, cars.BrandID, cars.CarName,
                    cars.DailyPrice, cars.Description);
            }
        }
    }
}
