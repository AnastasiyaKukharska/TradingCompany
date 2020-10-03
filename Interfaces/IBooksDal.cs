using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface IBooksDal
    {
        List<BooksDTO> Sort(string column,string category);
        List<BooksDTO> Find(string text,string category);
    }
}
