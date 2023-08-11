using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Items> GetList();
        void HeadingAdd(Items heading);
        void HeadingDelete(Items heading);
        void HeadingUpdate(Items heading);
        Items GetById(int id);
    }
}
