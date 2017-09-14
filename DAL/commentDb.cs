using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class commentDb
    {
       private GamesJournalEntities db;

       public commentDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<comment> GetALL()
       {
           return db.comment.ToList();
       }
       public comment GetByID(int Id)
       {
           return db.comment.Find(Id);
       }
       public void Insert(comment _comment)
       {
           db.comment.Add(_comment);
           Save();
       }
       public void Delete(int Id)
       {
           comment _comment = db.comment.Find(Id);
           db.comment.Remove(_comment);
           Save();
       }
       public void Update(comment _comment)
       {
           db.Entry(_comment).State = EntityState.Modified;
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
