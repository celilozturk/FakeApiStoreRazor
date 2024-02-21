using System.Net;
using System.Text.Json;
using FakeApiStoreRazor.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [BindProperty]
        public Product Product { get; set; }
        public async Task OnGet(int id)
        {
            HttpClient httpClient=_httpClientFactory.CreateClient("BaseURL");
            var product= await httpClient.GetFromJsonAsync<Product>($"/products/{id}");
           if(product!=null) {
            Product=product;
           }
        }

        public async Task<IActionResult> OnPost(){
                HttpClient httpClient=_httpClientFactory.CreateClient("BaseURL");
              using var response= await httpClient.PutAsync($"/products/{Product.id}",new StringContent(JsonSerializer.Serialize(Product)));
                if(response.StatusCode is HttpStatusCode.OK){
                    TempData["message"]="Product was updated successfully.";
                    return RedirectToPage("Index");
                }
                else{
                     TempData["message"]="Product was not updated !";
                     return RedirectToPage("Index");
                }
                System.Console.WriteLine("Test");
        }
    }
}
