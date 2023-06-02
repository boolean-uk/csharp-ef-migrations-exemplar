using ef.intro.wwwapi.Context;
using ef.intro.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace ef.intro.wwwapi.Repository
{
    public class LibraryRepository : ILibraryRepository
    {       
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
                return db.Authors.Include(a => a.Books).ThenInclude(b => b.Publisher).ToList();
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
        }

       

        public IEnumerable<Book> GetAllBooks()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Include(a => a.Publisher).ToList();
            }
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
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            using (var db = new LibraryContext())
            {
                return db.Publishers.ToList();
            };

        }

        public Publisher GetPublisher(int id)
        {
            Publisher result;
            using (var db = new LibraryContext())
            {
                result = db.Publishers.Where(x => x.Id == id).FirstOrDefault();
            };
            return result;
        }

        public bool AddPublisher(Publisher publisher)
        {
            using (var db = new LibraryContext())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return true;
            };
        }

        public bool UpdatePublisher(Publisher publisher)
        {
            using (var db = new LibraryContext())
            {
                if (!db.Publishers.Any(x => x.Id == publisher.Id)) return false;

                var item = db.Publishers.FirstOrDefault(x => x.Id == publisher.Id);
                item.Name = publisher.Name;                
                db.SaveChanges();
                return true;
            };
        }

        public bool DeletePublisher(int id)
        {
            using (var db = new LibraryContext())
            {
                var item = db.Publishers.Find(id);
                db.Publishers.Remove(item);
                db.SaveChanges();
                return true;
            };
        }
    }
}
