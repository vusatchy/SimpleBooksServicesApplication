using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Work1
{
    class BookController
    {
        private BookDAL service = new BookService();
       

        public BookController()
        {
            
        }

        public Book getBookById(int id)
        {
            return service.getById(id);
        }

        public void deleteBook(Book book)
        {
            service.delete(book);
        }

        public void addBook(Book book)
        {
            service.add(book);
        }

        public void updateBook(Book book)
        {
            service.update(book);
        }

        public List<Book> getAllBooks()
        {
            return service.getAll();
        }

        public List<Book> getSortedListOfBooksByName(){
            List<Book> books = getAllBooks();
            books.Sort((x, y) => x.name.CompareTo(y.name));
            return books;
        }

        public List<Book> getSortedListOfBooksById()
        {
            List<Book> books = getAllBooks();
            books.Sort((x, y) => x.id.CompareTo(y.id));
            return books;
        }

        public List<Book> getSortedListOfBooksByAuthor()
        {
            List<Book> books = getAllBooks();
            books.Sort((x, y) => x.author.CompareTo(y.author));
            return books;
        }

        public List<Book> getSortedListOfBooksByYear()
        {
            List<Book> books = getAllBooks();
            books.Sort((x, y) => x.year.CompareTo(y.year));
            return books;
        }

        public List<Book> getBooksByNameLike(String name)
        {
            List<Book> books = getAllBooks();
            String pattern = name;
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            books = books.FindAll(x => regex.Match(x.name).Success);
            return books;
        }

    }
}
