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
            //Obtenemos la base de datos
            _context = context;
        }

        //Borrar libro
        public async Task<bool> DeleteBook(int id)
        {
            //Obtenemos el libro por su id
            var book = await _context.Books.FindAsync(id);

            //Borramos el libro obtenido por su id
            _context.Books.Remove(book);

            //Devolvemos el resultado al borrar el libro, que deberá de ser 1 (1 fila afectada)
            return await _context.SaveChangesAsync() > 0;
        }

        //Obtener todos los libros
        public async Task<IEnumerable<Book>> GetAllBook()
        {
            //Obtenemos una lista con todos los libros y la returnamos
            return await _context.Books.ToListAsync();
        }

        //Obtener un libro
        public async Task<Book> GetBookDetails(int id)
        {
            //Obtenemos un libro por su id y lo returnamos
            return await _context.Books.FindAsync(id);
        }

        //Insertar un libro
        public async Task<bool> InsertBook(Book book)
        {
            //Insertamos el libro pasado por parametro
            _context.Books.Add(book);

            //Devolvemos el resultado al insertar el libro, que deberá de ser 1 (1 fila afectada)
            return await _context.SaveChangesAsync() > 0;
        }

        //Metodo para ver si el libro es nuevo y se debe insertar o si ya existe o se debe editar
        public async Task<bool> SaveBook(Book book)
        {
            //Si la id del libro no es 0 es un libro editado, si es 0 es un nuevo libro (sin id)
            if (book.BookId > 0)
            {
                return await UpdateBook(book);
            }
            else
            {
                return await InsertBook(book);
            }
            //Returnamos el resultado de la funcion ya sea de update o insert
        }

        //Editar libro
        public async Task<bool> UpdateBook(Book book)
        {
            //Hacemos un UPDATE del libro pasado por parametro
            _context.Entry(book).State = EntityState.Modified;

            //Returnamos el resultado al hacer UPDATE
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
