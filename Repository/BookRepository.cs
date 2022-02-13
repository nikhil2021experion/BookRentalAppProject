using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly BookRentalContext _ContextOne;

        public BookRepository(BookRentalContext ContextOne)
        {
            _ContextOne = ContextOne;
        }

        #region add a book
        public async Task<int> AddBook(Books books)
        {
            if (_ContextOne != null)
            {
                await _ContextOne.Books.AddAsync(books);
                await _ContextOne.SaveChangesAsync();
                return books.BookId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion

        #region get all books
        public async Task<List<BookViewModel>> GetAllBooks()
        {
            if (_ContextOne != null)
            {
               // return await _ContextOne.Books.ToListAsync();

                return await (from b in _ContextOne.Books

                              join p in _ContextOne.PublicationDetails
                              on b.PublicationId equals p.PublicationId

                              join a in _ContextOne.Authors
                              on b.AuthorId equals a.AuthorId

                              join g in _ContextOne.GenreDetails
                              on b.GenreId equals g.GenreId
                              select new BookViewModel
                              {
                                  BookId = b.BookId,
                                  BookName = b.BookName,
                                  AuthorId = a.AuthorId,
                                  PublicationId = p.PublicationId,
                                  GenreId = g.GenreId,
                                  Price = b.Price
                              }).ToListAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region update a book
        public async Task UpdateBook(Books books)
        {
            if (_ContextOne != null)
            {
                _ContextOne.Entry(books).State = EntityState.Modified;
                _ContextOne.Books.Update(books);
                await _ContextOne.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion


        #region delete Book
        public async Task<int> DeleteBook(int? id)
        {
            int result = 0;
            if (_ContextOne != null)
            {                                                                   //linq expression
                var book = await _ContextOne.Books.FirstOrDefaultAsync(p => p.BookId == id);
                //check condition
                if (book != null)
                {
                    //deleting the book
                    _ContextOne.Books.Remove(book);

                    //commit the changes after deletion
                    result = await _ContextOne.SaveChangesAsync();
                }
                return result;
            }
            return result;
            //throw new NotImplementedException();
        }
        #endregion



        #region get book details using BookID
        public async Task<BookViewModel> GetBooksById(int? id)
        {

            if (_ContextOne != null)
            {
                var bookss = await _ContextOne.Books.FindAsync(id);

                return await (from b in _ContextOne.Books
                              
                              join p in _ContextOne.PublicationDetails
                              on b.PublicationId equals p.PublicationId
                              join a in _ContextOne.Authors
                              on b.AuthorId equals a.AuthorId
                              join g in _ContextOne.GenreDetails
                              on b.GenreId equals g.GenreId
                              where b.BookId == id 
                              select new BookViewModel
                              {
                                  BookId = b.BookId,
                                  BookName = b.BookName,
                                  AuthorId = a.AuthorId,
                                  PublicationId = p.PublicationId,
                                  GenreId = g.GenreId,
                                  Price =b.Price
                              }).FirstOrDefaultAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
