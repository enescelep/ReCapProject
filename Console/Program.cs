using Business.Concrete;
using Data_Access.Concrete.EntityFramework;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            bool cikis = true;

            while (cikis)
            {
                Console.WriteLine(
                    "Rent A Car \n---------------------------------------------------------------" +
                    "\n\n1.Araba Ekleme\n" +
                    "2.Araba Silme\n" +
                    "3.Araba Güncelleme\n" +
                    "4.Arabaların Listelenmesi\n" +
                    "5.Arabaların detaylı bir şekilde Listelenmesi\n" +
                    "6.Arabaların Marka Id'sine göre Listelenmesi\n" +
                    "7.Kullanıcı ekleme\n" +
                    "8.Bütün müşterilerin listelenmesi\n" +
                    "9.Kullanıcı ekleme\n" +
                    "10.Kullanıcıların listelenmesi\n" +
                    "11.Araba kiralama\n" +
                    "12.Kiralanan arabayı teslim etme\n" +
                    "13.Kiralanan araçların detaylı listelenmesi\n" +
                    "14.Çıkış\n" +
                    "Yukarıdakilerden hangi işlemi gerçekleştirmek istiyorsunuz ?"
                    );

                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n---------------------------------------------------------------\n");
                switch (number)
                {
                    case 1:
                        CarAddition(carManager, brandManager, colorManager);
                        break;
                    case 2:
                        GetAllCarDetails(carManager);
                        CarDeletion(carManager);
                        break;
                    case 3:
                        GetAllCarDetails(carManager);
                        CarUpdate(carManager);
                        break;
                    case 4:
                        GetAllCar(carManager);
                        break;
                    case 5:
                        GetAllCarDetails(carManager);
                        break;
                    case 6:
                        GetAllCarDetails(carManager);
                        CarById(carManager, brandManager, colorManager);
                        break;
                    case 7:
                        GetAllUserList(userManager);
                        CustomerAddition(customerManager);
                        break;
                    case 8:
                        GetAllCustomerList(customerManager);
                        break;
                    case 9:
                        UserAddition(userManager);
                        break;
                    case 10:
                        GetAllUserList(userManager);
                        break;
                    case 11:
                        GetAllCarDetails(carManager);
                        GetAllCustomerList(customerManager);
                        RentalAddition(rentalManager);
                        break;
                    case 12:
                        ReturnRental(rentalManager);
                        break;
                    case 13:
                        GetAllRentalDetailList(rentalManager);
                        break;
                    case 14:
                        cikis = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;
                }
            }
        }

        private static void GetAllRentalDetailList(RentalManager rentalManager)
        {
            Console.WriteLine("Kiralanan Arabalar Listesi: \nId\tCar Name\nRental Id\tRent Date\tReturn Date");
            foreach (var rental in rentalManager.GetRentalDetail().Data)
            {
                Console.WriteLine($"{rental.RentalId}\t{rental.CarName}\t{rental.RentalId}\t{rental.RentDate}\t{rental.ReturnDate}");
            }
        }

        private static void ReturnRental(RentalManager rentalManager)
        {
            Console.WriteLine("Kiraladığınız araba hangi Car Id'ye sahip?");
            int CarID = Convert.ToInt32(Console.ReadLine());
            var returnedRental = rentalManager.GetRentalDetail(I => I.CarID == CarID);
            foreach (var rental in returnedRental.Data)
            {
                rental.ReturnDate = DateTime.Now;
                Console.WriteLine(returnedRental.Message);
            }
        }

        private static void RentalAddition(RentalManager rentalManager)
        {
            Console.WriteLine("Car Id: ");
            int CarIDForAdd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Id: ");
            int UserIdForAdd = Convert.ToInt32(Console.ReadLine());

            Rental rentalForAdd = new Rental
            {
                CarID = CarIDForAdd,
                RentalId = UserIdForAdd,
                RentDate = DateTime.Now,
                ReturnDate = null,
            };
            Console.WriteLine(rentalManager.Add(rentalForAdd).Message);

        }

        private static void UserAddition(UserManager userManager)
        {
            Console.WriteLine("First Name: ");
            string userNameForAdd = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string userSurnameForAdd = Console.ReadLine();
            Console.WriteLine("Email Name: ");
            string userEmailForAdd = Console.ReadLine();
            Console.WriteLine("Password Name: ");
            string userPasswordForAdd = Console.ReadLine();


            User userForAdd = new User
            {
                FirstName = userNameForAdd,
                LastName = userSurnameForAdd,
                Email = userEmailForAdd,
                Password = userPasswordForAdd

            };
            userManager.Add(userForAdd);
        }

        private static void GetAllCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("Müşterilerin Listesi: \nId\tKullanıcı Id\tCompany Name");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.UserId}\t{customer.CompanyName}");
            }
        }

        private static void CustomerAddition(CustomerManager customerManager)
        {
            Console.WriteLine("User Id: ");
            int userIdForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Company Name: ");
            string CompanyNameForAdd = Console.ReadLine();

            Customer customerForAdd = new Customer
            {
                UserId = userIdForAdd,
                CompanyName = CompanyNameForAdd
            };
            customerManager.Add(customerForAdd);
        }

        private static void GetAllUserList(UserManager userManager)
        {
            Console.WriteLine("Kullanıcı Listesi: \nId\tFirst Name\tLast Name\tEmail\tPassword");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.UserId}\t{user.FirstName}\t{user.LastName}\t{user.Password}");
            }
        }

        private static void CarById(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Hangi arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
            int CarID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nId'si {CarID} olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            Car carById = carManager.GetByID(CarID).Data;
            Console.WriteLine($"{carById.CarID}\t{colorManager.GetCarsByColorId(carById.ColorID).Data}\t\t{brandManager.GetByBrandId(carById.BrandID).Data.BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");
        }

        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("Car Id: ");
            int CarIDForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Brand Id: ");
            int BrandIDForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int ColorIDForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price: ");
            decimal dailyPriceForUpdate = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Description : ");
            string descriptionForUpdate = Console.ReadLine();

            Console.WriteLine("Model Year: ");
            int modelYearForUpdate = Convert.ToInt32(Console.ReadLine());

            Car carForUpdate = new Car { CarID = CarIDForUpdate, BrandID = BrandIDForUpdate, ColorID = ColorIDForUpdate, DailyPrice = dailyPriceForUpdate, Description = descriptionForUpdate, ModelYear = modelYearForUpdate };
            carManager.Update(carForUpdate);
        }

        private static void CarDeletion(CarManager carManager)
        {
            Console.WriteLine("Hangi Id'ye sahip arabayı silmek istiyorsunuz? ");
            int CarIDForDelete = Convert.ToInt32(Console.ReadLine());
            carManager.Delete(carManager.GetByID(CarIDForDelete).Data);
        }

        private static void CarAddition(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Color Listesi");
            GetAllColor(colorManager);

            Console.WriteLine("Brand Listesi");
            GetAllBrand(brandManager);

            Console.WriteLine("\nBrand Id: ");
            int BrandIDForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int ColorIDForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price: ");
            decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Description : ");
            string descriptionForAdd = Console.ReadLine();

            Console.WriteLine("Model Year: ");
            int modelYearForAdd = Convert.ToInt32(Console.ReadLine());

            Car carForAdd = new Car { BrandID = BrandIDForAdd, ColorID = ColorIDForAdd, DailyPrice = dailyPriceForAdd, Description = descriptionForAdd, ModelYear = modelYearForAdd };
            carManager.Add(carForAdd);
        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            Console.WriteLine("Arabaların detaylı listesi:  \nId\tCar Name\tBrand ID\tModel Year\tDaily Price\tDescription");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.CarID}\t{car.CarName}\t\t{car.BrandID}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void GetAllCar(CarManager carManager)
        {
            Console.WriteLine("Arabaların Listesi:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.CarID}\t{car.ColorID}\t\t{car.BrandID}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandID}\t{brand.BrandName}");
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorID}\t{color.ColorName}");
            }
        }
    }
}