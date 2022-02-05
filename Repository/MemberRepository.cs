using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public class MemberRepository : IMemberRepository
    {

        private readonly BookRentalContext _ContextFour;

        public MemberRepository(BookRentalContext ContextFour)
        {
            _ContextFour = ContextFour;
        }

        #region add a member
        public async Task<int> AddMember(Members members)
        {
            if (_ContextFour != null)
            {
                await _ContextFour.Members.AddAsync(members);
                await _ContextFour.SaveChangesAsync();
                return members.MemberId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion

        #region get all members
        public async Task<List<Members>> GetAllMembers()
        {
            if (_ContextFour != null)
            {
                return await _ContextFour.Members.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region update a member
        public async Task UpdateMember(Members members)
        {
            if (_ContextFour != null)
            {
                _ContextFour.Entry(members).State = EntityState.Modified;
                _ContextFour.Members.Update(members);
                await _ContextFour.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region get members details using memberID
        public async Task<UserViewModel> GetMemberById(int? id)
        {

            if (_ContextFour != null)
            {
                //var members = await _ContextFour.Members.FindAsync(id);

                return await (from m in _ContextFour.Members
                              where m.MemberId == id
                              select new UserViewModel
                              {
                                  MemberId = m.MemberId,
                                  MemberName = m.MemberName,
                                  Mobile = m.Mobile,
                                  Address = m.Address
                              }).FirstOrDefaultAsync();
                
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region get members details using member name
        public async Task<UserViewModel> GetMemberByName(string name)
        {

            if (_ContextFour != null)
            {
                var members = await _ContextFour.Members.FindAsync(name);

                return await (from m in _ContextFour.Members
                              
                              select new UserViewModel
                              {
                                  MemberId = m.MemberId,
                                  MemberName = m.MemberName,
                                  Mobile = m.Mobile,
                                  Address = m.Address
                              }).FirstOrDefaultAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
        /*
        #region get members with fine

        public async Task<List<MembersViewModel>> GetAllMembersWithFine()
        {

            if (_ContextFour != null)
            {
                
                return await(from r in _ContextFour.RentDetails
                             join b in _ContextFour.Books
                             on r.BookId equals b.BookId
                             join m in _ContextFour.Members
                             on r.MemberId equals m.MemberId
                             let difference = DbFunction.Diffdays(r.BookTakenDate, r.BookReturnedDate)
                             where difference >  10
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
        */
    }
}
