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
    public class AuthorsController : ControllerBase
    {



        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        #region get all authors
        [HttpGet]
        public async Task<List<Authors>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }
        #endregion

        #region get author using id
        [HttpGet]
        [Route("GetAuthorById/{id}")]
        public async Task<AuthorViewModel> GetAuthorById(int? id)
        {
            try
            {
                var member = await _authorRepository.GetAuthorById(id);
                if (member != null)
                {
                    return await _authorRepository.GetAuthorById(id);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region add an author
        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Authors authors)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var authorID = await _authorRepository.AddAuthors(authors);
                    if (authorID > 0)
                    {
                        return Ok(authorID);
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

        #region update an author
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] Authors authors)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorRepository.UpdateAuthor(authors);
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


        #region delete a author

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _authorRepository.DeleteAuthor(id);
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

    }
}
