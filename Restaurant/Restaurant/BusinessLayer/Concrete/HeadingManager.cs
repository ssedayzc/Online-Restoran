using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Items GetById(int id)
        {
            return _headingDal.Get(x => x.ItemId == id);
        }

        public List<Items> GetList()
        {
            return _headingDal.List();
        }

        public void HeadingAdd(Items heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Items heading)
        {
            heading.HeadingStatus = false;
            
        }

        public List<Items> GetListByCategoryId(int id)
        {
            return _headingDal.List(x => x.CategoryId == id);
        }

        public void HeadingUpdate(Items heading)
        {
            _headingDal.Update(heading);
        }
    }
}
