using FakeApiStoreRazor.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async void OnGet(int id)
        {
            HttpClient httpClient= _httpClientFactory.CreateClient("BaseURL");
            var product= await httpClient.GetFromJsonAsync<Product>($"/products/{id}");
            
        }
        public async Task<IActionResult> OnPost(){

        }
    }
}
