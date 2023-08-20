using PruebaTecnicaDataAccess.ContextDB;
using PruebaTecnicaDataAccess.ModelsDB;
using PruebaTecnicaDTOs.AuthorsDTO;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PruebaTecnicaServices.Class
{
    public class AuthorsService : IAuthorsService
    {
        ModelContext contextdb = new ModelContext();

        public bool CreateAuthor(SaveAuthorDTO saveAuthor)
        {
            try
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
                return true;
            }
            catch
            {
                return false; // Error al crear
            }
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
