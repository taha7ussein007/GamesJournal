using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class feedbackBs
    {
        private feedbackDb objDb;

        public feedbackBs()
        {
            objDb = new feedbackDb();
        }

        public IEnumerable<feedback> GetALL()
        {
            return objDb.GetALL();
        }

        public feedback GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(feedback _feedback)
        {
            objDb.Insert(_feedback);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(feedback _feedback)
        {
            objDb.Update(_feedback);
        }
    }
}