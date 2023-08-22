using PruebaTecnicaBusiness.Interfaces;
using PruebaTecnicaDTOs.AuthorsDTO;
using PruebaTecnicaDTOs.GenericDTO;
using PruebaTecnicaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            _authorService = authorsService; //Inyección de interfaz de servicios uthorsService
        }

        public List<AuthorDTO> GetAllAuthors()
        {
            try
            {
                List<PruebaTecnicaDataAccess.ModelsDB.Author> resp = _authorService.GetAllAuthors(); //Consumo de servicio consulta a BD

                if (resp.Count > 0)
                {
                    List<AuthorDTO> response = resp.Select(au => new AuthorDTO
                    {
                        Id = au.Id,
                        FullName = au.FullName,
                        DateOfBirth = au.DateOfBirth,
                        CityOfOrigin = au.CityOfOrigin,
                        Email = au.Email
                    }).ToList(); //Mediante una consulta LINQ mapeamos el objeto en base a la respuesta del servicio

                    return response;
                }
                else
                {
                    return new List<AuthorDTO>(); //En caso de no obtener respuesta retornamos la lista vacía.
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
                PruebaTecnicaDataAccess.ModelsDB.Author resp = _authorService.GetAuthorById(id); //Consumo de servicio consulta por id a BD

                AuthorDTO response = new()
                {
                    Id = resp.Id,
                    FullName = resp.FullName,
                    DateOfBirth = resp.DateOfBirth,
                    CityOfOrigin = resp.CityOfOrigin,
                    Email = resp.Email
                };
                return response; //Mapeamos el objeto en base a la respuesta del servicio
            }
            catch
            {
                return new AuthorDTO();
            }
        }

        public ResponseDTO RegisterAuthor(RegisterAuthorDTO registerBookDTO)
        {
            ResponseDTO response = new();
            try
            {
                if (string.IsNullOrEmpty(registerBookDTO.FullName) || string.IsNullOrEmpty(registerBookDTO.DateOfBirth) || string.IsNullOrEmpty(registerBookDTO.CityOfOrigin) || string.IsNullOrEmpty(registerBookDTO.Email))
                    throw new Exception("Complete la información del autor.");

                var author = _authorService.GetAuthorByName(registerBookDTO.FullName!);
                if (author != null)
                    throw new Exception("El autor ya está registrado.");

                DateTime fecha = Convert.ToDateTime(registerBookDTO.DateOfBirth);
                bool resp = _authorService.CreateAuthor(new SaveAuthorDTO()
                {
                    CityOfOrigin = registerBookDTO.CityOfOrigin,
                    Email = registerBookDTO.Email,
                    DateOfBirth = fecha,
                    FullName = registerBookDTO.FullName
                });

                if(resp)
                {
                    response.Status = "Ok";
                    response.Message = "Autor creado correctamente.";
                }
            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
