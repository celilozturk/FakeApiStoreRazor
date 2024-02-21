using FakeApiStoreRazor.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fakeapistorerazorpage.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }
    public List<Product> Products { get; set; }
    public async Task OnGet()
    {
        var httpClient= _httpClientFactory.CreateClient("BaseURL");
        var products=await httpClient.GetFromJsonAsync<IEnumerable<Product>>("/products");
        if(products!=null)
        Products=products.ToList();
       // await System.Console.Out.WriteLineAsync(response.ToString());
    }
}
