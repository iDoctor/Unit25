using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit25.Models;

namespace Unit25.Repositories
{
    public class BookRepository
    {
        // CREATE
        public int? AddNewBook(string name, string author, int year, string genre)
        {
            int? newBookId;

            try
            {
                Book book = new Book()
                {
                    Name = name,
                    Author = author,
                    Year = year,
                    Genre = genre
                };

                using var db = new AppContext();
                db.Books.Add(book);
                db.SaveChanges();

                newBookId = book.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return newBookId;
        }


        // READ
        public List<Book> GetAllBooks()
        {
            List<Book> booksList;
            try
            {
                using var db = new AppContext();
                booksList = db.Books.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return booksList;
        }
        public Book? GetBookById(int id)
        {
            Book? book;
            try
            {
                using var db = new AppContext();
                book = db.Books.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return book;
        }

        public List<Book> GetBooksWithSimilarName(string name)
        {
            List<Book> booksList;
            try
            {
                using var db = new AppContext();
                booksList = db.Books.Where(x => x.Name.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return booksList;
        }

        // CUSTOM READ
        // 1
        public List<Book> GetBookCustom1(int year1, int year2)
        {
            List<Book> booksList;
            try
            {
                using var db = new AppContext();
                booksList = db.Books.Where(x => x.Year >= year1 && x.Year <= year2).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return booksList;
        }

        //2
        //... Далее аналогично методу 1


        // UPDATE
        public int? UpdateBook(int id, string name, int year)
        {
            int? bookId = null;

            try
            {
                using var db = new AppContext();

                var book = db.Books.FirstOrDefault(x => x.Id == id);

                if (book != null)
                {
                    if (!string.IsNullOrEmpty(name))
                        book.Name = name;

                    if (year != 0)
                        book.Year = year;

                    if (!string.IsNullOrEmpty(name) || year != 0)
                        db.SaveChanges();

                    bookId = book.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return bookId;
        }


        // DELETE
        public int? DeleteBook(int id)
        {
            int? bookId = null;

            try
            {
                using var db = new AppContext();

                var book = db.Books.FirstOrDefault(x => x.Id == id);

                if (book != null)
                {
                    db.Books.Remove(book);
                    bookId = book.Id;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return bookId;
        }
    }
}
