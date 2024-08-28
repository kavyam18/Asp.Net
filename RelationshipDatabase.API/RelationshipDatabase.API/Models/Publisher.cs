namespace RelationshipDatabase.API.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Many To One
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        //Many To Many
        public ICollection<BookPublisher> BookPublishers { get; set; }
    }
}
