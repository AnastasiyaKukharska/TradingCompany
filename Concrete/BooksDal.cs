using DAL.Concrete;
using DTO;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Data.SqlClient;

namespace DAL.Concrete
{
    public class BooksDal : IBooksDal
    {
        private string connectionString;

        public BooksDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
       string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
        //Сортує книги за назвою в межах певної категорії
        public List<BooksDTO> Sort(string category,string column = "Title" )
        {
            using (SqlConnection conn = new SqlConnection(this.connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = $"select * from Books where Category='{category}' order by " + column;
                SqlDataReader reader = comm.ExecuteReader();

                List<BooksDTO> Books = new List<BooksDTO>();
                while (reader.Read())
                {
                    BooksDTO books = new BooksDTO();

                    books.BookID = (int)reader["BookID"];
                    books.Title = reader["Title"].ToString();
                    books.Author = reader["Author"].ToString();
                    books.Price = (Decimal)reader["Price"];
                    Books.Add(books);
                }
                conn.Close();
                return Books;
            }
        }
        //шукає книги за назвою в межах певної категорії
        public List<BooksDTO> Find(string text,string category)
        {
            using (SqlConnection conn = new SqlConnection(this.connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "select * from Books where Title Like '%" + text + $"%' and Category='{category}'";
                SqlDataReader reader = comm.ExecuteReader();

                List<BooksDTO> Books = new List<BooksDTO>();
                while (reader.Read())
                {
                    BooksDTO books = new BooksDTO();

                    books.BookID = (int)reader["BookID"];
                    books.Title = reader["Title"].ToString();
                    books.Author = reader["Author"].ToString();
                    books.Price = (Decimal)reader["Price"];
                    Books.Add(books);

                }
                conn.Close();
                return Books;
            }
        }
    }
}
