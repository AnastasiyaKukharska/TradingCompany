using DAL.Concrete;
using BusinessLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
    class ConsoleTest
    {
        //static void Main(string[] args)
        //{
        //    NewBL();
        //    NewOne();
        //    Console.ReadLine();
        //}

        private static void NewBL()
        {
            string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
            BasketDal dal = new BasketDal(connStr);


            Customer customer = new Customer(dal);
            BasketDTO m = new BasketDTO
            {
                BasketID = 3,
                Title = "TestBL",
                UserID = 1,
                BookID = 1,
                StatusID = 2,
                Author = "TestBL",
                Price = 100,
                Amount = 2,
                Date = DateTime.Now
            };
            m = customer.AddBasket(m);
        }

        private static void NewOne()
        {
            BasketDal dal = new BasketDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);

            BasketDTO m = new BasketDTO
            {
               // BasketID = 2,
                Title = "Mizery",
                UserID = 1,
                BookID = 1,
                StatusID = 2,
                Author = "King",
                Price = 150,
                Amount = 1,
                Date = DateTime.Now
            };
            m = dal.CreateBasket(m);
            Console.WriteLine($"New basket ID: {m.Title}");

            foreach (var basket in dal.GetAllBaskets())
            {
                Console.WriteLine($"{basket.BasketID}\t{basket.Title}\t{basket.Price}");
            }

            Console.WriteLine($"Deleting basket ID: {m.BasketID}");
            dal.DeleteBasket(m.BasketID);
            foreach (var basket in dal.GetAllBaskets())
            {
                Console.WriteLine($"{basket.BasketID}\t{basket.Title}\t{basket.Price}");
            }
        }

    }
}

