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
        [BindProperty]
        public Product Product { get; set; }
        public async Task OnGet(int id)
        {
            HttpClient httpClient= _httpClientFactory.CreateClient("BaseURL");
             Product= await httpClient.GetFromJsonAsync<Product>($"/products/{id}");
          //  if(product!=null) Product=product;
        }
        public async Task<IActionResult> OnPost(){
                HttpClient httpClient= _httpClientFactory.CreateClient("BaseURL");
              using var response= await httpClient.DeleteAsync($"/products/{Product.id}");
              if(response.IsSuccessStatusCode){
                TempData["message"]="Product was deleted successfully.";
                return RedirectToPage("Index");
              }
              else{
                 TempData["message"]="Something went wrong!";
                return RedirectToPage("Index");
              }
        }
    }
}
