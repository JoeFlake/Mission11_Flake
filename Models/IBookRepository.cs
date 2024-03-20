namespace Mission11_Flake.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
