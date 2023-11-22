namespace LibraryBookApi.DTOs
{
    public class LibraryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookDTO> Books { get; set; } = new List<BookDTO>();
    }
}
