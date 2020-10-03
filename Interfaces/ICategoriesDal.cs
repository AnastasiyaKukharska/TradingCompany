using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public interface ICategoriesDal
    {
        List<CategoriesDTO> GetAllCategories();
        //CategoriesDTO UpdateCategory(CategoriesDTO category);
        //CategoriesDTO CreateCategory(CategoriesDTO category);
        //void DeleteCategories(int id);

    }
}
