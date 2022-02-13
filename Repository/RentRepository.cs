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
                return await (from b in _contextSix.Books                              
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
                                  RentPrice = (double)b.Price * 5 / 100
                              }).ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion


        #region add a rent
        public async Task<int> AddRent(RentDetails rentDetails)
        {
            if (_contextSix != null)
            {
                await _contextSix.RentDetails.AddAsync(rentDetails);
                await _contextSix.SaveChangesAsync();
                return rentDetails.RentId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion


        #region update a rent
        public async Task UpdateRent(RentDetails rentDetails)
        {
            if (_contextSix != null)
            {
                _contextSix.Entry(rentDetails).State = EntityState.Modified;
                _contextSix.RentDetails.Update(rentDetails);
                await _contextSix.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion



        #region get rent details using rentID
        public async Task<RentViewModel> GetRentById(int? id)
        {

            if (_contextSix != null)
            {
                //var bookss = await _contextSix.Books.FindAsync(id);

                return await (from r in _contextSix.RentDetails

                              join b in _contextSix.Books
                              on r.BookId equals b.BookId
                              join m in _contextSix.Members
                              on r.MemberId equals m.MemberId
                              
                              where b.BookId == id
                              select new RentViewModel
                              {
                                  BookId = b.BookId,
                                  BookName = b.BookName,
                                  //MemberId = r.MemberId,
                                  //MemberName = m.MemberName,
                                  BookTakenDate = r.BookTakenDate,
                                  BookReturnedDate = r.BookReturnedDate
                                  
                              }).FirstOrDefaultAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

    }
}
