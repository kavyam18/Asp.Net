namespace RelationshipDatabase.API.Models
{
    public class BookPublisher
    {
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
    }
}
