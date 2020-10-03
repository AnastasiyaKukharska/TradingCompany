using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface IBasketDal
    {
        void GetBasketById(int id);
        List<BasketDTO> GetAllBaskets();
        void  UpdateBasket(int id,int Sid);
       BasketDTO CreateBasket (BasketDTO basket);
        void DeleteBasket(int id);
    }
}
