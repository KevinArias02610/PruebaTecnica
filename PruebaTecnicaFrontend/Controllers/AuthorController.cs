using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnicaFrontend.Models;
using System.Net.Http;
using System.Text;

namespace PruebaTecnicaFrontend.Controllers
{
    public class AuthorController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7130");
        }

        #region RegistrarAutor
        public IActionResult RegisterAutor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAutor(RegisterAuthor registerAuthor)
        {
            string jsonBody = JsonConvert.SerializeObject(registerAuthor);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/Authors/RegisterAuthor", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

            if (apiResponse!.Status == "Ok")
            {
                // La llamada a la API fue exitosa
                TempData["SuccessMessage"] = apiResponse.Message;
            }
            else
            {
                // La llamada a la API falló
                TempData["ErrorMessage"] = apiResponse.Message;
            }
            return View();

        }
        #endregion
    }
}
