using ef_core_mongo_db.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ef_core_mongo_db.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _books;

        /// <summary>
        /// Inject IBookstoreDatabaseSettings settings
        /// </summary>
        /// <param name="settings"></param>
        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("bookstore-db");
            _books = database.GetCollection<Book>("books");
        }

        /// <summary>
        /// Finds books 
        /// </summary>
        /// <returns></returns>
        public List<Book> Get() => _books.Find(book => true).ToList();

        /// <summary>
        /// Finds a book by {id}
        /// </summary>
        /// <typeparam name="Book"></typeparam>
        /// <returns></returns>
        public Book Get(string id) => _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        /// <summary>
        /// Creates a new book in the collection.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        /// <summary>
        /// Updates a book in the collection by the book.id
        /// </summary>
        /// <param name="book.Id"></param>
        public void Update(string id, Book bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);

        /// <summary>
        /// Removes a book from the collection by book
        /// </summary>
        /// <param name="book.Id"></param>
        public void Remove(Book bookIn) => _books.DeleteOne(book => book.Id == bookIn.Id);

        /// <summary>
        /// Removes a book from the collection by book
        /// </summary>
        /// <param name="book.Id"></param>
        public void Remove(string id) => _books.DeleteOne(book => book.Id == id);
    }
}