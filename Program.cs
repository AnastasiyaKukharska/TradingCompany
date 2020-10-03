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
using System.Security.Cryptography;
using System.Threading;

namespace Kursova
{
    class Program
    {
         static void Main(string[] args)
        {
            Menu();

            Console.ReadLine();
        }

          public static void Menu()
        {
            int id = Login();
            //int id = 1;
            Console.WriteLine("Do you want to:\n 1-See all books \n " +
                "2-See your basket\n" +
                "3-Add a book to the basket\n" +
                "4-Go out\n");
            var x = Console.ReadLine();
            switch (x)
            {
                case "1":
                    //можна побачити посортований за назвою список книг певної категорії,або знайти за назвою певну книгу
                    CategoriesDal dal = new CategoriesDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
                    Console.WriteLine("Please,choose a category");
                    foreach (var categories in dal.GetAllCategories())
                    {
                        Console.WriteLine($"{categories.Category}");
                    }
                    string c = Console.ReadLine();
                    string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
 
                    BooksDal dal3 = new BooksDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
                    foreach (var book in dal3.Sort(c))
                    {
                        Console.WriteLine($"{book.Title}\t{book.Author}\t{book.Price}");
                    }
                    Console.WriteLine("Do you want to find smth?yes/no");
                    string s = Console.ReadLine();
                    if (s == "yes")
                    {
                        Console.WriteLine("Write the title of the book:");
                        string ti = Console.ReadLine();
                        foreach (var book in dal3.Find(ti, c))
                        {
                            Console.WriteLine($"{book.Title}\t{book.Author}\t{book.Price}");
                        }
                    }
      
                    Menu();
                    break;
                case "2":
                    Customer.GetBasket(id);
                    Console.WriteLine("Do you want to buy books from basket?yes/no");
                    string s1 = Console.ReadLine();
                    if (s1 == "yes")
                    {
                        Customer.UpdateStatus(id, 1);
                    }
                    Console.WriteLine("Do you want to order shipping?yes/no");
                    string s2 = Console.ReadLine();
                    if (s2 == "yes")
                    {
                        Customer.UpdateStatus(id, 2);
                    }
                    Menu();
                    break;
                case "3":
                    BasketDal dal2 = new BasketDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
                    Console.WriteLine("Write a name of the wished book");
                    string t = Console.ReadLine();
                    Console.WriteLine("Write necessary amount:");
                    int a = Convert.ToInt32(Console.ReadLine());
                    string connStr2 = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connStr2))
                    using (SqlCommand comm = conn.CreateCommand())
                    {
                        conn.Open();
                        comm.CommandText = $"select * from Books where Title = '{t}'";
                        SqlDataReader reader = comm.ExecuteReader();

                        BooksDTO Book = new BooksDTO();
                        while (reader.Read())
                        {


                            Book.BookID = (int)reader["BookID"];
                            Book.Author = reader["Autor"].ToString();
                            Book.Price = (Decimal)reader["Price"];


                        }
                        conn.Close();
                        BasketDTO m = new BasketDTO
                        {
                            Title = t,
                            UserID = id,
                            BookID = Book.BookID,
                            StatusID = 3,
                            Author = Book.Author,
                            Price = Book.Price,
                            Amount = a,
                            Date = DateTime.Now
                        };

                        m = dal2.CreateBasket(m);
                    }
                    Menu();
                    break;

                case "4":
                    Console.WriteLine("Bye:(");
                    Thread.Sleep(1000);
                    System.Environment.Exit(20);
                    break;
            }

        }
        //здійснює логування у систему під певним користувачем
        public static int Login()
        {
            string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
            Console.WriteLine("Hello, sweety, enter your login, please! ");
            string login = Console.ReadLine();
            Console.WriteLine("Okay, honey, now enter your password");
            string password = Console.ReadLine();
            UserDTO customer = new UserDTO();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();

                comm.CommandText = $"select * from [User] where Login= '{login}'";

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    customer.UserID = Convert.ToInt32(reader["UserID"]);
                    customer.Login = reader["Login"].ToString();
                    customer.Password = (byte[])reader["Password"];
                    if (customer.Login != login || Decryption(customer.Password) != password)
                    {

                        Console.WriteLine("Unfortunutely,kitty, there isn't account with login or password like that. Please, try one more time.");
                        Thread.Sleep(2000);
                        System.Environment.Exit(20);
                    }
                }
                return customer.UserID;

            }
        }
        //розшифровує пароль
            public static string Decryption(byte[] p)
            {
                string decrypted = "";
                for (int i = 0; i < p.Length; i++)
                {
                    decrypted += Convert.ToString(Convert.ToChar(p[i]));
                }
                return decrypted;
            }


        }
    }

