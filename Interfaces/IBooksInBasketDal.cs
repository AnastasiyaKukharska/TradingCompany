using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    interface IBooksInBasketDal
    {
        BooksInBasketDTO CreateCustomer(BooksInBasketDTO bookInBasket);
    }
}
