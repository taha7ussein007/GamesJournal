using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class faqDb
    {
       private GamesJournalEntities db;

       public faqDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<faq> GetALL()
       {
           return db.faq.ToList();
       }
       public faq GetByID(int Id)
       {
           return db.faq.Find(Id);
       }
       public void Insert(faq faq)
       {
           db.faq.Add(faq);
           Save();
       }
       public void Delete(int Id)
       {
           faq faq=db.faq.Find(Id);
           db.faq.Remove(faq);
           Save();
       }
       public void Update(faq faq)
       {
           db.Entry(faq).State = EntityState.Modified;
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
