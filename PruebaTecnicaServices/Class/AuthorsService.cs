using PruebaTecnicaDataAccess.ContextDB;
using PruebaTecnicaDataAccess.ModelsDB;
using PruebaTecnicaDTOs.AuthorsDTO;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaServices.Class
{
    public class AuthorsService : IAuthorsService
    {
        ModelContext contextdb = new ModelContext();

        public void CreateAuthor(SaveAuthorDTO saveAuthor)
        {
            Author author = new()
            {
                CityOfOrigin = saveAuthor.CityOfOrigin,
                DateOfBirth = saveAuthor.DateOfBirth,
                Email = saveAuthor.Email,
                FullName = saveAuthor.FullName ?? ""
            };
            contextdb.Authors.Add(author);
            contextdb.SaveChanges();
        }

        public List<Author> GetAllAuthors()
        {
            try
            {
                return contextdb.Authors.ToList();
            }
            catch
            {
                return new List<Author>();
            }
        }

        public Author GetAuthorById(int id)
        {
            try
            {
                return contextdb.Authors.FirstOrDefault(author => author.Id == id)!;
            }
            catch
            {
                return new Author();
            }
        }

        public Author GetAuthorByName(string name)
        {
            try
            {
                return contextdb.Authors.FirstOrDefault(author => author.FullName.Trim().ToLower() == name.Trim().ToLower())!;
            }
            catch
            {
                return new Author();
            }
        }
    }
}
