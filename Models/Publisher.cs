namespace Fat_DeliaGabriela_Lab2.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string PublisherName  { get; set; }
        
        public ICollection<Book>? Books { get; set; } //navigation property
    }
}
