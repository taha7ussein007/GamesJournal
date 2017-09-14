using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class user_favBs
    {
        private user_favDb objDb;

        public user_favBs()
        {
            objDb = new user_favDb();
        }

        public IEnumerable<user_fav> GetALL()
        {
            return objDb.GetALL();
        }

        public user_fav GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(user_fav usrFav)
        {
            objDb.Insert(usrFav);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(user_fav usrFav)
        {
            objDb.Update(usrFav);
        }
    }
}