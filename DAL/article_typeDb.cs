using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class article_typeDb
    {
       private GamesJournalEntities db;

       public article_typeDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<article_type> GetALL()
       {
           return db.article_type.ToList();
       }
       public article_type GetByID(int Id)
       {
           return db.article_type.Find(Id);
       }
       public void Insert(article_type article_type)
       {
           db.article_type.Add(article_type);
           Save();
       }
       public void Delete(int Id)
       {
           article_type article_type=db.article_type.Find(Id);
           db.article_type.Remove(article_type);
           Save();
       }
       public void Update(article_type article_type)
       {
           db.Entry(article_type).State = EntityState.Modified;
           db.Configuration.ValidateOnSaveEnabled = false;
           Save();
           db.Configuration.ValidateOnSaveEnabled = true;
       }
       public void Save()
       {
           db.SaveChanges();
       }
    }
}
