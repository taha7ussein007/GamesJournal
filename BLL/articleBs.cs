using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class articleBs
    {
        private articleDb objDb;

        public articleBs()
        {
            objDb = new articleDb();
        }

        public IEnumerable<article> GetALL()
        {
            return objDb.GetALL();
        }

        public IEnumerable<article> GetALLByCategory(int CategoryId)
        {
            return objDb.GetALLByCategory(CategoryId);
        }
        public IEnumerable<article> GetALLByAuthor(int AuthorId)
        {
            return objDb.GetALLByAuthor(AuthorId);
        }

        public IEnumerable<article> GetALLPending(int CategoryId = 0)
        {
            return objDb.GetALLPending(CategoryId);
        }
        
        public article GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(article art)
        {
            objDb.Insert(art);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(article art)
        {
            objDb.Update(art);
        }
        public bool Rate(article art, int rate)
        {
            if(rate >= 1 && rate <= 5)
            {
                art.rate_count++;
                art.rating = Convert.ToInt32(Math.Round(
                    (Convert.ToDouble(art.rating) + (double)rate) / (double)art.rate_count));
                objDb.Update(art);
                return true;
            }
            return false;
        }
        public bool IsRateValid(int userID)
        {
            if (article.ratedByLst.IndexOf(userID) == -1)
                return true;
            else
                return false;
        }
    }
}