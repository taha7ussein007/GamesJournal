using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class user_typeDb
    {
       private GamesJournalEntities db;

       public user_typeDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<user_type> GetALL()
       {
           return db.user_type.ToList();
       }
       public user_type GetByID(int Id)
       {
           return db.user_type.Find(Id);
       }
       public void Insert(user_type user_type)
       {
           db.user_type.Add(user_type);
           Save();
       }
       public void Delete(int Id)
       {
           user_type user_type=db.user_type.Find(Id);
           db.user_type.Remove(user_type);
           Save();
       }
       public void Update(user_type user_type)
       {
           db.Entry(user_type).State = EntityState.Modified;
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
