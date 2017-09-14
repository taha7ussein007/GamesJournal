using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class feedbackDb
    {
       private GamesJournalEntities db;

       public feedbackDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<feedback> GetALL()
       {
           return db.feedback.ToList();
       }
       public feedback GetByID(int Id)
       {
           return db.feedback.Find(Id);
       }
       public void Insert(feedback feedback)
       {
           db.feedback.Add(feedback);
           Save();
       }
       public void Delete(int Id)
       {
           feedback feedback=db.feedback.Find(Id);
           db.feedback.Remove(feedback);
           Save();
       }
       public void Update(feedback feedback)
       {
           db.Entry(feedback).State = EntityState.Modified;
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
