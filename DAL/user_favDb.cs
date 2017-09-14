using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class user_favDb
    {
       private GamesJournalEntities db;

       public user_favDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<user_fav> GetALL()
       {
           return db.user_fav.ToList();
       }
       public user_fav GetByID(int Id)
       {
           return db.user_fav.Find(Id);
       }
       public void Insert(user_fav user_fav)
       {
           db.user_fav.Add(user_fav);
           Save();
       }
       public void Delete(int Id)
       {
           user_fav user_fav=db.user_fav.Find(Id);
           db.user_fav.Remove(user_fav);
           Save();
       }
       public void Update(user_fav user_fav)
       {
           db.Entry(user_fav).State = EntityState.Modified;
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
