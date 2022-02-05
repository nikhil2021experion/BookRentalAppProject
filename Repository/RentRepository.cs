using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public class RentRepository : IRentRepository
    {
        private readonly BookRentalContext _contextSix;

        public RentRepository(BookRentalContext contextSix)
        {
            _contextSix = contextSix;
        }


        #region getting list of all books with details
        public async  Task<List<RentViewModel>> GetAllBooksWithRentDetails()
        {
            if (_contextSix != null)
            {
                return await (from r in _contextSix.RentDetails
                              join b in _contextSix.Books
                              on r.BookId equals b.BookId
                              join p in _contextSix.PublicationDetails
                              on b.PublicationId equals p.PublicationId
                              join a in _contextSix.Authors
                              on b.AuthorId equals a.AuthorId
                              join g in _contextSix.GenreDetails
                              on b.GenreId equals g.GenreId
                              select new RentViewModel
                              {
                                  
                                  BookId = b.BookId,
                                  BookName = b.BookName,
                                  PublicationName = p.PublicationName,
                                  AuthorName = a.AuthorName,
                                  GenreName = g.GenreName,
                                  Price = b.Price,
                                  RentPrice = r.RentPrice
                              }).ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
