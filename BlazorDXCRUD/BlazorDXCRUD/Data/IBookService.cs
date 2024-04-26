using BlazorDXCRUD.Models1;

namespace BlazorDXCRUD.Data
{
    //Interfaz para el servicio de libros
    public interface IBookService
    {
        //Metodo para obtener todos los libros
        Task<IEnumerable<Book>> GetAllBook();

        //Metodo para obtener un libro en concreto
        Task<Book> GetBookDetails(int id);

        //Metodo para insertar un libro
        Task<bool> InsertBook(Book book);

        //Metodo para actualizar un libro
        Task<bool> UpdateBook(Book book);

        //Metodo para eliminar un libro
        Task<bool> DeleteBook(int id);

        //Metodo para guardar un libro
        Task<bool> SaveBook(Book book);
    }
}
