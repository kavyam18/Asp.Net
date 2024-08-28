namespace RelationshipDatabase.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
        //Many To Many Relations
        public ICollection<BookPublisher> BookPublishers { get; set; }

    }
}
