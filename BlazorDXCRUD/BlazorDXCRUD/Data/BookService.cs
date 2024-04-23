using BlazorDXCRUD.Models1;
using Microsoft.EntityFrameworkCore;

namespace BlazorDXCRUD.Data
{
    //Le implementamos la interfaz
    public class BookService : IBookService
    {
        //Context es la base de datos
        private readonly CreadorTablas _context;

        //Introducimos en context la base de datos
        public BookService(CreadorTablas context)
        {
            _context = context;
        }

        //Borrar libro
        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            _context.Books.Remove(book);

            return await _context.SaveChangesAsync() > 0;
        }

        //Obtener todos los libros
        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _context.Books.ToListAsync();
        }

        //Obtener un libro
        public async Task<Book> GetBookDetails(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        //Insertar un libro
        public async Task<bool> InsertBook(Book book)
        {
            _context.Books.Add(book);

            return await _context.SaveChangesAsync() > 0;
        }

        //Metodo para ver si el libro es nuevo y se debe insertar o si ya existe o se debe editar
        public async Task<bool> SaveBook(Book book)
        {
            if (book.BookId > 0)
            {
                return await UpdateBook(book);
            }
            else
            {
                return await InsertBook(book);
            }
        }

        //Editar libro
        public async Task<bool> UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
