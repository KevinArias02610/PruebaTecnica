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
        public bool CreateBook(SaveBookDTO name)
        {
            try
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
                return true;
            }
            catch
            {
                return false; // Error al actualizar
            }
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

        public List<BooksAuthorDTO> GetBooksAuthors()
        {
            var query = from libro in contextdb.Books
                        join autor in contextdb.Authors on libro.AuthorId equals autor.Id
                        select new BooksAuthorDTO
                        {
                            BookId = libro.Id,
                            BookTitle = libro.Title,
                            BookYear = libro.Year,
                            BookGenre = libro.Genre,
                            BookNumberOfPages = libro.NumberOfPages,
                            AuthorId = autor.Id,
                            AuthorFullName = autor.FullName,
                            AuthorDateOfBirth = autor.DateOfBirth.ToString(),
                            AuthorCityOfOrigin = autor.CityOfOrigin,
                            AuthorEmail = autor.Email
                        };
            return query.ToList();
        }
    }
}
