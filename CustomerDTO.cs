using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        public int UserID { get; set; }
        public string FirstAndLastName { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAdress { get; set; }
        public byte Gender { get; set; }
    }
}
