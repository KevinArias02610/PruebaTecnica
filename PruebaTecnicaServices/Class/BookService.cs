using PruebaTecnicaDataAccess.ContextDB;
using PruebaTecnicaDataAccess.ModelsDB;
using PruebaTecnicaDTOs.BooksDTO;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaServices.Class
{
    public class BookService : IBookService
    {
        ModelContext contextdb = new ModelContext();
        public void CreateBook(SaveBookDTO name)
        {
            Book book = new()
            {
                AuthorId = name.AuthorId,
                NumberOfPages = name.NumberOfPages,
                Genre = name.Genre,
                Title = name.Title,
                Year = name.Year
            };
            contextdb.Books.Add(book);
            contextdb.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return contextdb.Books.ToList();
            }
            catch
            {
                return new List<Book>();
            }
        }
    }
}
