using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DALef.Concrete
{
    public class BookDalEf : IBooksDal
    {
        private readonly IMapper _mapper;

        public BookDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }


        public List<BooksDTO> Find(string text, string category)
        {
           using (var entities = new IMDBEntities())
            {
                var bookInDB = entities.Books.SingleOrDefault(b => b.Title == text && b.Category==category);
                if (bookInDB == null)
                {
                    entities.Books.Add(bookInDB);
                }
                else
                { 
                    _mapper.Map( bookInDB);
                }
                entities.SaveChanges();
                return _mapper.Map<BooksDTO>(bookInDB);
            }
        }
        public List<BooksDTO> Sort(string category, string column)
        {
            using (var entities = new IMDBEntities())
            {
                var books = entities.Books.ToList(b => b.Category == category);
                return _mapper.Map<List<BooksDTO>>(books);
            }
        }
    }
}
