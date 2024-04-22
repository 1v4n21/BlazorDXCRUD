using BlazorDXCRUD.Models1;

namespace BlazorDXCRUD.Data
{
    //Interfaz para el servicio de libros
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBook();
        Task<Book> GetBookDetails(int id);
        Task<bool> InsertBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<bool> SaveBook(Book book);
    }
}
