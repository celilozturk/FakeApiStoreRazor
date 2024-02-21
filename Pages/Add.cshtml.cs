using System.Net;
using System.Text.Json;
using FakeApiStoreRazor.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class AddModel : PageModel
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AddModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(){
            HttpClient httpClient=_httpClientFactory.CreateClient("BaseURL");
           var response= await httpClient.PostAsync("/products",new StringContent(JsonSerializer.Serialize(Product)));
           if(response.StatusCode is HttpStatusCode.OK){
            TempData["message"]="Product was added succesfully!";
            return RedirectToPage("Index");
           }
           else{
            TempData["message"]="Something went wrong!";
            return RedirectToPage("Index");
           }
        }
    }
}
