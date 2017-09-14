using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class faqBs
    {
        private faqDb objDb;

        public faqBs()
        {
            objDb = new faqDb();
        }

        public IEnumerable<faq> GetALL()
        {
            return objDb.GetALL();
        }

        public faq GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(faq faQ)
        {
            objDb.Insert(faQ);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(faq faQ)
        {
            objDb.Update(faQ);
        }
    }
}