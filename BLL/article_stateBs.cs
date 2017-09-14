using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class article_stateBs
    {
        private article_stateDb objDb;

        public article_stateBs()
        {
            objDb = new article_stateDb();
        }

        public IEnumerable<article_state> GetALL()
        {
            return objDb.GetALL();
        }

        public article_state GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(article_state artState)
        {
            objDb.Insert(artState);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(article_state artState)
        {
            objDb.Update(artState);
        }
    }
}