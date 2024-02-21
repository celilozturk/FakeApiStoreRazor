using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FakeApiStoreRazor.Pages.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Price")]
        public decimal price { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Category")]
        public string category { get; set; }
        [DisplayName("Image")]
        public string image { get; set; }
    }
}