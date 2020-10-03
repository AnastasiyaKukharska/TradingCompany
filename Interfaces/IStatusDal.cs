using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    interface IStatusDal
    {
        StatusDTO GetStatusById(int id);
        StatusDTO UpdateStatus(StatusDTO book);
        StatusDTO CreateStatus(StatusDTO book);
        void DeleteStatus(int id);
    }
}
