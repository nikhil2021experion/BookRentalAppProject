using BookRentalAppProject.Models;
using BookRentalAppProject.Repository;
using BookRentalAppProject.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {


        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        #region get all genres
        [HttpGet]
        public async Task<List<GenreDetails>> GetAllGenres()
        {
            return await _genreRepository.GetAllGenres();
        }
        #endregion

        #region add a genre
        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] GenreDetails genreDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bookID = await _genreRepository.AddGenre(genreDetails);
                    if (bookID > 0)
                    {
                        return Ok(bookID);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region update a genre
        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreDetails genreDetails)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _genreRepository.UpdateGenre(genreDetails);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region delete a genre
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _genreRepository.DeleteGenre(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region get genre using id
        [HttpGet]
        [Route("GetGenreById/{id}")]
        public async Task<GenreViewModel> GetGenreById(int? id)
        {
            try
            {
                var member = await _genreRepository.GetGenreById(id);
                if (member != null)
                {
                    return await _genreRepository.GetGenreById(id);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
