using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class userBs
    {
        private userDb objDb;

        public userBs()
        {
            objDb = new userDb();
        }
        public IEnumerable<user> GetALL()
        {
            return objDb.GetALL();
        }
        public user GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public user GetByLoginKey(string loginKey)
        {
            return objDb.GetByLoginKey(loginKey);
        }
        public void Insert(user usr)
        {
            objDb.Insert(usr);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(user usr)
        {
            objDb.Update(usr);
        }
    }
}