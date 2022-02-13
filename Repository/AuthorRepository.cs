using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookRentalContext _ContextTwo;

        public AuthorRepository(BookRentalContext ContextTwo)
        {
            _ContextTwo = ContextTwo;
        }


        #region Add a author
        public async Task<int> AddAuthors(Authors authors)
        {
            if (_ContextTwo != null)
            {
                await _ContextTwo.Authors.AddAsync(authors);
                await _ContextTwo.SaveChangesAsync();
                return authors.AuthorId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion

        #region get all authors
        public async Task<List<Authors>> GetAllAuthors()
        {
            if (_ContextTwo != null)
            {
                return await _ContextTwo.Authors.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region update an author
        public async Task UpdateAuthor(Authors authors)
        {
            if (_ContextTwo != null)
            {
                _ContextTwo.Entry(authors).State = EntityState.Modified;
                _ContextTwo.Authors.Update(authors);
                await _ContextTwo.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region delete Author
        public async Task<int> DeleteAuthor(int? id)
        {
            int result = 0;
            if (_ContextTwo != null)
            {                                                                   
                var author = await _ContextTwo.Authors.FirstOrDefaultAsync(p => p.AuthorId == id);
                //check condition
                if (author != null)
                {
                    //deleting the book
                    _ContextTwo.Authors.Remove(author);

                    //commit the changes after deletion
                    result = await _ContextTwo.SaveChangesAsync();
                }
                return result;
            }
            return result;
            //throw new NotImplementedException();
        }
        #endregion

        #region get author details using authorID
        public async Task<AuthorViewModel> GetAuthorById(int? id)
        {

            if (_ContextTwo != null)
            {
                //var members = await _ContextFour.Members.FindAsync(id);

                return await (from a in _ContextTwo.Authors
                              where a.AuthorId == id
                              select new AuthorViewModel
                              {
                                  AuthorId = a.AuthorId,
                                  AuthorName = a.AuthorName                                 
                              }).FirstOrDefaultAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
