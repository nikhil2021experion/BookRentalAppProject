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
    public class BooksController : ControllerBase
    {


        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        #region get all Books
        [HttpGet]
        public async Task<List<BookViewModel>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }
        #endregion

        #region add a book
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Books books)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bookID = await _bookRepository.AddBook(books);
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

        #region update a book
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Books books)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookRepository.UpdateBook(books);
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


        
        #region delete a book
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _bookRepository.DeleteBook(id);
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



        #region get books by id
        [HttpGet]
        [Route("GetBooksById/{id}")]
        public async Task<BookViewModel> GetBooksById(int? id)
        {
            try
            {
                var member = await _bookRepository.GetBooksById(id);
                if (member != null)
                {
                    return await _bookRepository.GetBooksById(id);
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
