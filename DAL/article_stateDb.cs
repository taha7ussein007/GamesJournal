using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class article_stateDb
    {
      private GamesJournalEntities db;

       public article_stateDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<article_state> GetALL()
       {
           return db.article_state.ToList();
       }
       public article_state GetByID(int Id)
       {
           return db.article_state.Find(Id);
       }
       public void Insert(article_state article_state)
       {
           db.article_state.Add(article_state);
           Save();
       }
       public void Delete(int Id)
       {
           article_state article_state=db.article_state.Find(Id);
           db.article_state.Remove(article_state);
           Save();
       }
       public void Update(article_state article_state)
       {
           db.Entry(article_state).State = EntityState.Modified;
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
