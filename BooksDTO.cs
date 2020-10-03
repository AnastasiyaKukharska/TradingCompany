using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BooksDTO
    {
        public string Title { get; set; }
        public int BookID { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int CategoryID { get; set; }
        public string Edition { get; set; }
        public DateTime Year { get; set; }
    }
}
