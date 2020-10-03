using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BasketDTO
    {
        public int BasketID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public int BookID { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int StatusID { get; set; }
        public DateTime Date { get; set; }
    }
}
