using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class articleDb
    {
      private GamesJournalEntities db;

       public articleDb()
       {
           db = new GamesJournalEntities();
       }
       public IEnumerable<article> GetALL()
       {
           return db.article.ToList();
       }

       public IEnumerable<article> GetALLByCategory(int CategoryId)
       {
           try
           {
               return db.article.ToList().FindAll(
                   delegate(article art)
                   {
                       return (art.id == CategoryId);
                   });
           }
           catch (Exception) 
           {
               return null;
           }
       }
       public IEnumerable<article> GetALLByAuthor(int AuthorId)
       {
           try
           {
               return db.article.ToList().FindAll(
                   delegate(article art)
                   {
                       return (art.author == AuthorId);
                   });
           }
           catch (Exception)
           {
               return null;
           }
       }

       public IEnumerable<article> GetALLPending(int CategoryId = 0)
       {
           if (CategoryId == 0)
           {
               try
               {
                   return db.article.ToList().FindAll(
                       delegate(article art)
                       {
                           return (art.state == articleStateEn.Pending);
                       });
               }
               catch (Exception)
               {
                   return null;
               }
           }
           else
           {
               try
               {
                   return db.article.ToList().FindAll(
                       delegate(article art)
                       {
                           return (art.state == articleStateEn.Pending 
                               && art.category == CategoryId);
                       });
               }
               catch (Exception)
               {
                   return null;
               }
           }
       }

       public article GetByID(int Id)
       {
           return db.article.Find(Id);
       }
       public void Insert(article article)
       {
           db.article.Add(article);
           Save();
       }
       public void Delete(int Id)
       {
           article article=db.article.Find(Id);
           db.article.Remove(article);
           Save();
       }
       public void Update(article article)
       {
           db.Entry(article).State = EntityState.Modified;
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
