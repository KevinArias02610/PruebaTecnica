using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnicaFrontend.Models;
using System.Text;

namespace PruebaTecnicaFrontend.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient _httpClient;

        public BooksController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7130");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = new List<HomeModel>();
            HttpResponseMessage response = _httpClient.GetAsync("/Books/GetAllBooks").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                List<ResponseModel> json = JsonConvert.DeserializeObject<List<ResponseModel>>(content)!;

                foreach (var item in json)
                {
                    books.Add(new HomeModel
                    {
                        AuthorFullName = item.AuthorFullName,
                        BookGenre = item.BookGenre,
                        BookNumberOfPages = item.BookNumberOfPages,
                        BookTitle = item.BookTitle,
                        BookYear = item.BookYear
                    });
                }
            }
            return View(books);
        }

        #region RegistrarLibro
        public IActionResult RegisterBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterBook(HomeModel createBook)
        {
            string jsonBody = JsonConvert.SerializeObject(createBook);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/Books/RegisterBook", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
            TempData.Clear();
            if (apiResponse!.Status == "Ok")
            {
                TempData["SuccessMessage"] = apiResponse.Message;
            }
            else
            {
                TempData["ErrorMessage"] = apiResponse.Message;
            }
            return View();

        }
        #endregion
    }
}
