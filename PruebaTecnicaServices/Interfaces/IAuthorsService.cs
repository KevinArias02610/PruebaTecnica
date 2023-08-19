using PruebaTecnicaDataAccess.ModelsDB;
using PruebaTecnicaDTOs.AuthorsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaServices.Interfaces
{
    public interface IAuthorsService
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        Author GetAuthorByName(string name);
        void CreateAuthor(SaveAuthorDTO name);
    }
}
