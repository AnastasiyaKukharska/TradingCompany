using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DALef.Concrete
{
    public class BasketDalEf : IBasketDal
    {
        private readonly IMapper _mapper;

        public BasketDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public BasketDTO CreateBasket(BasketDTO basket)
        {
            using (var entities = new IMDBEntities())
            {
                Basket b = _mapper.Map<Basket>(basket);
                entities.Basket.Add(b);
                entities.SaveChanges();

                return _mapper.Map<BasketDTO>(b);
            }
        }

        public void DeleteBasket(int id)
        {
            using (var entities = new IMDBEntities())
            {
                var b = entities.Baskets.SingleOrDefault(bb => bb.BasketID == id);

                if (b == null)
                {
                    return;
                }

                entities.Baskets.Remove(b);
                entities.SaveChanges();
            }
        }

    
        public List<BasketDTO> GetAllBaskets()
        {
            using (var entities = new IMDBEntities())
            {
                var baskets = entities.Basket.ToList();
                return _mapper.Map<List<BasketDTO>>(baskets);
            }
        }
        public void GetBasketById(int id)
        {
            using (var entities = new IMDBEntities())
            {
                var basket = entities.Baskets.SingleOrDefault(b => b.BasketID == id);
               // return _mapper.Map<BasketDTO>(basket);
            }
        }

        public void UpdateBasket(int id,int Sid)
        {
            using (var entities = new IMDBEntities())
            {
                var basketInDB = entities.Baskets.SingleOrDefault(b => b.ID == id);
                if (basketInDB == null)
                {        
                    entities.Baskets.Add(basketInDB);
                }
                else
                {
                    _mapper.Map(basketInDB);
                }
                entities.SaveChanges();
                //return _mapper.Map<BasketDTO>(basketInDB);
            }
        }
    }
}