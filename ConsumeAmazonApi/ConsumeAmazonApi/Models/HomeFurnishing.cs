using System.ComponentModel.DataAnnotations;

namespace ConsumeAmazonApi.Models
{
    public class HomeFurnishing
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Price { get; set; } = string.Empty;
        [Required]
        public string Brand { get; set; } = string.Empty;
    }
}
