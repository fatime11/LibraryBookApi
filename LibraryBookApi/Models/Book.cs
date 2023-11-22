namespace LibraryBookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
