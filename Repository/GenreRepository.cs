using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public class GenreRepository : IGenreRepository
    {

        private readonly BookRentalContext _ContextThree;

        public GenreRepository(BookRentalContext ContextThree)
        {
            _ContextThree = ContextThree;
        }


        #region add genre
        public async Task<int> AddGenre(GenreDetails genreDetails)
        {
            if (_ContextThree != null)
            {
                await _ContextThree.GenreDetails.AddAsync(genreDetails);
                await _ContextThree.SaveChangesAsync();
                return genreDetails.GenreId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion

        #region get all genres
        public async Task<List<GenreDetails>> GetAllGenres()
        {
            if (_ContextThree != null)
            {
                return await _ContextThree.GenreDetails.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region update a genre
        public async Task UpdateGenre(GenreDetails genreDetails)
        {
            if (_ContextThree != null)
            {
                _ContextThree.Entry(genreDetails).State = EntityState.Modified;
                _ContextThree.GenreDetails.Update(genreDetails);
                await _ContextThree.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion


        #region delete Genre
        public async Task<int> DeleteGenre(int? id)
        {
            int result = 0;
            if (_ContextThree != null)
            {                                                                   
                var genre = await _ContextThree.GenreDetails.FirstOrDefaultAsync(p => p.GenreId == id);
                //check condition
                if (genre != null)
                {
                    //deleting the book
                    _ContextThree.GenreDetails.Remove(genre);

                    //commit the changes after deletion
                    result = await _ContextThree.SaveChangesAsync();
                }
                return result;
            }
            return result;
            //throw new NotImplementedException();
        }
        #endregion


        #region get genre details using genreID
        public async Task<GenreViewModel> GetGenreById(int? id)
        {

            if (_ContextThree != null)
            {
                //var members = await _ContextFour.Members.FindAsync(id);

                return await (from g in _ContextThree.GenreDetails
                              where g.GenreId  == id
                              select new GenreViewModel
                              {
                                  GenreId = g.GenreId,
                                  GenreName = g.GenreName                            
                              }).FirstOrDefaultAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
