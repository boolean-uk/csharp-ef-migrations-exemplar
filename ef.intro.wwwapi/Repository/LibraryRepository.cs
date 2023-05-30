using ef.intro.wwwapi.Context;
using ef.intro.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ef.intro.wwwapi.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        public LibraryRepository() 
        { 
        
        }  
        public bool AddAuthor(Author author)
        {
            using(var db = new LibraryContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<Author> GetAllAuthors()
        {            
            using (var db = new LibraryContext())
            {
                return db.Authors.Include(a => a.Books).ToList();
            }
            return null;
        }

        public bool AddBook(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
                db.SaveChanges();                
                return true;
            };
            return false;
        }

        public bool DeleteAuthor(int id)
        {
            using (var db = new LibraryContext())
            {
                var item = db.Authors.Find(id);               
                db.Authors.Remove(item);
                db.SaveChanges();
                return true;
            };
            return false;
        }

        public bool DeleteBook(int id)
        {
            using (var db = new LibraryContext())
            {
                var item = db.Books.Find(id);
                db.Books.Remove(item);
                db.SaveChanges();
                return true;
            };
            return false;
        }

       

        public IEnumerable<Book> GetAllBooks()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Include(a => a.Publisher).ToList();
            }
            return null;
        }

        public Author GetAuthor(int id)
        {
            Author result;
            using (var db = new LibraryContext())
            {
                result =  db.Authors.Include(a => a.Books).FirstOrDefault(x => x.Id == id);       
            };
            return result;
        }

        public Book GetBook(int id)
        {
            Book result;
            using (var db = new LibraryContext())
            {
                result = db.Books.Where(x => x.Id == id).FirstOrDefault();     
            };
            return result;
        }

        public bool UpdateAuthor(Author author)
        {
            using (var db = new LibraryContext())
            {
                if (!db.Authors.Any(x => x.Id == author.Id)) return false;

                var item = db.Authors.FirstOrDefault(x => x.Id == author.Id);
                item.FirstName= author.FirstName;
                item.LastName = author.LastName;
                item.Email = author.Email;
                db.SaveChanges();
                return true;
            };
            return false;
        }

        public bool UpdateBook(Book book)
        {
            using (var db = new LibraryContext())
            {
                var item = db.Books.FirstOrDefault(x => x.Id == book.Id);
                item.Title = book.Title;
                item.AuthorId = book.AuthorId;
                db.SaveChanges();
                return true;
            };
            return false;
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            using (var db = new LibraryContext())
            {
                return db.Publishers.ToList();
            };

        }

        public Book GetPublisher(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddPublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public bool DeletePublisher(int id)
        {
            throw new NotImplementedException();
        }
    }
}
