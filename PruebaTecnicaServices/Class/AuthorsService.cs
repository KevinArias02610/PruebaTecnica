using PruebaTecnicaDataAccess.DBContext;
using PruebaTecnicaDataAccess.ModelsDB;
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

        public List<Author> GetAllAuthors()
        {
            try
            {
                return contextdb.Authors.ToList();
            }catch
            {
                return new List<Author>();
            }
        }
    }
}
