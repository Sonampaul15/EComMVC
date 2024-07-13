namespace ConsumeAmazonApi.DTO
{
    public class BooksDto
    {
        public int Id { get; set; }
        public string BookName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
