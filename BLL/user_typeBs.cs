using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class user_typeBs
    {
        private user_typeDb objDb;

        public user_typeBs()
        {
            objDb = new user_typeDb();
        }

        public IEnumerable<user_type> GetALL()
        {
            return objDb.GetALL();
        }

        public user_type GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(user_type usrType)
        {
            objDb.Insert(usrType);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(user_type usrType)
        {
            objDb.Update(usrType);
        }
    }
}