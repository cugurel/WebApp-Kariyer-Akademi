namespace WebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public decimal ImdbRate { get; set; }
        public string ImageUrl { get; set; }
    }
}
