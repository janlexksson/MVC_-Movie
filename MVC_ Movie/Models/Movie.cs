namespace MVC__Movie.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; }   
        public string Genre { get; set; }
        public string PicUrl { get; set; }

        public Customer? Customer { get; set; }// Lista istället    - blir many to many rel public List<Customer>? Customer { get; set; } // Hjälp av Ernst 4/7
        public int CustomerId { get; set; }  //Lista istället  - Fick det inte att fungera!!!!!
    }
}
