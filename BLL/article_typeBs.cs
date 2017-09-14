using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class article_typeBs
    {
        private article_typeDb objDb;

        public article_typeBs()
        {
            objDb = new article_typeDb();
        }

        public IEnumerable<article_type> GetALL()
        {
            return objDb.GetALL();
        }
        public article_type GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(article_type artType)
        {
            objDb.Insert(artType);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(article_type artType)
        {
            objDb.Update(artType);
        }
    }
}