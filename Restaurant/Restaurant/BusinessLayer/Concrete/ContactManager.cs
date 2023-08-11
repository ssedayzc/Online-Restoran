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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this._contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            try
            {
                contact.UserName = "admin";
                _contactDal.Insert(contact);
            }
            catch (Exception ex)
            {
                // Hatanın detayını görmek için hatayı konsola yazdırabiliriz.
                Console.WriteLine(ex.Message);
                // Ayrıca hatayı tekrar fırlatmak veya loglamak için gerekli işlemleri yapabilirsiniz.
                // throw;
            }
        }


        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactId==id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public List<Contact> GetListInbox()
        {
            return _contactDal.List(x => x.UserMail != "admin@gmail.com");
        }

        public List<Contact> GetListSendbox()
        {
            return _contactDal.List(x => x.UserMail == "admin@gmail.com");
        }
    }
}
