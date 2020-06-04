using System.Collections.Generic;
using ef_core_mongo_db.Models;

namespace ef_core_mongo_db.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Finds books 
        /// </summary>
        /// <returns></returns>
        List<Book> Get();

        /// <summary>
        /// Finds a book by {id}
        /// </summary>
        /// <typeparam name="Book"></typeparam>
        /// <returns></returns>
        Book Get(string id);

        /// <summary>
        /// Creates a new book in the collection.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Book Create(Book book);

        /// <summary>
        /// Updates a book in the collection by the book.id
        /// </summary>
        /// <param name="book.Id"></param>
        void Update(string id, Book bookIn);

        /// <summary>
        /// Removes a book from the collection by book
        /// </summary>
        /// <param name="book.Id"></param>
        void Remove(Book bookIn);

        /// <summary>
        /// Removes a book from the collection by book.id
        /// </summary>
        /// <param name="book.Id"></param>
        void Remove(string id);
    }
}