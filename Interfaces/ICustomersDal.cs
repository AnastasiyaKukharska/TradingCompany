using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICustomerDal
    {
        CustomerDTO GetCustomerById(int id);
        List<CustomerDTO> GetAllCustomer();
        CustomerDTO UpdateCustomer(CustomerDTO customer);
        CustomerDTO CreateCustomer(CustomerDTO customer);
        void DeleteCustomer(int id);
    }
}
