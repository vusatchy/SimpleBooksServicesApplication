using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Work1
{
    class BookService:DBUtils,BookDAL
    {
        public  Book getById(int id)
        {     
            Book book = new Book();
            using(MySqlConnection connection = getConnection())
            {
               
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM book WHERE book.id=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                book.id = Int32.Parse(dataReader["id"].ToString());
                book.name = dataReader["name"].ToString();
                book.author = dataReader["author"].ToString();
                book.year = DateTime.Parse(dataReader["year"].ToString()).Date;
                dataReader.Close();
            }
            return book;
        }

        public void add(Book obj)
        {
            using(MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO book (name,author,year) VALUES(@name,@author,@year)";
                command.Parameters.AddWithValue("@name", obj.name);
                command.Parameters.AddWithValue("@author", obj.author);
                command.Parameters.AddWithValue("@year", obj.year.Date);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public  void update(Book obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE book SET name=@name,author=@author,year=@year WHERE id=@id";
                command.Parameters.AddWithValue("@id", obj.id);
                command.Parameters.AddWithValue("@name", obj.name);
                command.Parameters.AddWithValue("@author", obj.author);
                command.Parameters.AddWithValue("@year", obj.year.Date);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public  void delete(Book obj)
        {
            using (MySqlConnection connection = getConnection())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM book WHERE id = @id";
                command.Parameters.AddWithValue("@id", obj.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public  List<Book> getAll()
        {
            List<Book> books = new List<Book>();
            Book book = null;
            using (MySqlConnection connection = getConnection())
            {

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM book";
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    book = new Book();
                    book.id = Int32.Parse(dataReader["id"].ToString());
                    book.name = dataReader["name"].ToString();
                    book.author = dataReader["author"].ToString();
                    book.year = DateTime.Parse(dataReader["year"].ToString()).Date;;
                    books.Add(book);
                }
                dataReader.Close();
            }
            return books;
        }
    }
    
}
