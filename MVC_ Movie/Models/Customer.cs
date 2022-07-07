namespace MVC__Movie.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string TelefonNumber { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
