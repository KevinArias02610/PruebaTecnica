using PruebaTecnicaBusiness.Interfaces;
using PruebaTecnicaDTOs.AuthorsDTO;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaBusiness.Class
{
    public class Author : IAuthor
    {
        private readonly IAuthorsService _authorService;
        public Author(IAuthorsService authorsService)
        {
            _authorService = authorsService;
        }
        public List<AuthorDTO> GetAllAuthors()
        {
            try
            {
                List<PruebaTecnicaDataAccess.ModelsDB.Author> resp = _authorService.GetAllAuthors();

                if (resp.Count > 0)
                {
                    List<AuthorDTO> response = resp.Select(au => new AuthorDTO
                    {
                        Id = au.Id,
                        FullName = au.FullName,
                        DateOfBirth = au.DateOfBirth,
                        CityOfOrigin = au.CityOfOrigin,
                        Email = au.Email
                    }).ToList();

                    return response;
                }
                else
                {
                    return new List<AuthorDTO>();
                }
            }
            catch
            {
                return new List<AuthorDTO>();
            }
        }

        public AuthorDTO GetAuthorById(int id)
        {
            try
            {
                PruebaTecnicaDataAccess.ModelsDB.Author resp = _authorService.GetAuthorById(id);

                AuthorDTO response = new()
                {
                    Id = resp.Id,
                    FullName = resp.FullName,
                    DateOfBirth = resp.DateOfBirth,
                    CityOfOrigin = resp.CityOfOrigin,
                    Email = resp.Email
                };
                return response;
            }
            catch
            {
                return new AuthorDTO();
            }
        }
    }
}
