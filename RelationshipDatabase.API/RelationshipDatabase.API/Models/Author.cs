namespace RelationshipDatabase.API.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Link them Here
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        //Many To One
        public ICollection<Book> Books { get; set; }
    }
}
