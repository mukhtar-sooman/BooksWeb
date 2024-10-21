namespace BooksWebApplication.Models
{
    public class BookModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int NumberOfCopys { get; set; }
        public int CategoriesId { get; set; }
        public int AddedByUserId { get; set; }
    }
}
