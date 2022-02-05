using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public interface IBookRepository
    {

        //get all Books
        Task<List<BookViewModel>> GetAllBooks();

        //add a Book
        Task<int> AddBook(Books books);

        //update a Book
        Task UpdateBook(Books books);

        Task<int> DeleteBook(int? id);

        Task<BookViewModel> GetBooksById(int? id);
    }
}
