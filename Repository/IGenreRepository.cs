using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public interface IGenreRepository
    {
        //get all Genre
        Task<List<GenreDetails>> GetAllGenres();

        //add a Book
        Task<int> AddGenre(GenreDetails genreDetails);

        //update a Book
        Task UpdateGenre(GenreDetails genreDetails);

        Task<int> DeleteGenre(int? id);

        //get genre using id
        Task<GenreViewModel> GetGenreById(int? id);
    }
}
