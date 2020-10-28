using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALef.Mapper
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BooksDTO>().ReverseMap();
        }
    }
}
