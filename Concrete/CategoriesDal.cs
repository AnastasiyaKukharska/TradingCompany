using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Interfaces;
using System.Data.SqlClient;
namespace DAL.Concrete
{
    public class CategoriesDal : ICategoriesDal
    {
        private string connectionString;

        public CategoriesDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
        public List<CategoriesDTO> GetAllCategories()
        {
            using (SqlConnection conn = new SqlConnection(this.connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Categories";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<CategoriesDTO> categories = new List<CategoriesDTO>();
                while (reader.Read())
                {

                    categories.Add(new CategoriesDTO
                    {
                        CategoryID = (int)reader["CategoryID"],
                        Category = reader["Category"].ToString(),
                        Type = reader["Type"].ToString(),

                    });
                    
                }
                return categories;
            }
        }
    }

}

