using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class userDb
    {
       private GamesJournalEntities db;

       public userDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<user> GetALL()
       {
           return db.user.ToList();
       }
       public user GetByID(int Id)
       {
           return db.user.Find(Id);
       }
       public user GetByLoginKey(string loginKey)
       {
           return db.user.ToList().Where(x => (x.email == loginKey || x.username == loginKey)).FirstOrDefault();
       }
       public void Insert(user user)
       {
           db.user.Add(user);
           Save();
       }
       public void Delete(int Id)
       {
           user user=db.user.Find(Id);
           db.user.Remove(user);
           Save();
       }
       public void Update(user _user)
       {
           db.Entry(_user).State = EntityState.Modified;
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
