using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class commentBs
    {
        private commentDb objDb;
        public commentBs()
        {
            objDb = new commentDb();
        }
        public IEnumerable<comment> GetALL()
        {
            return objDb.GetALL();
        }
        public comment GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(comment _comment)
        {
            objDb.Insert(_comment);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(comment _comment)
        {
            objDb.Update(_comment);
        }
    }
}
