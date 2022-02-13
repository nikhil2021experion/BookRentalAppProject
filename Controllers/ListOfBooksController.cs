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
    public class ListOfBooksController : ControllerBase
    {
        private readonly IRentRepository _rentRepository;

        public ListOfBooksController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        #region get list of books
        [HttpGet]
        
        public async Task<List<RentViewModel>> GetAllBooksWithRentDetails()
        {
            try
            {
                var books = await _rentRepository.GetAllBooksWithRentDetails();
                if (books != null)
                {
                    return books;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


        #region get rent by id
        [HttpGet]
        [Route("GetRentById/{id}")]
        public async Task<RentViewModel> GetRentById(int? id)
        {
            try
            {
                var member = await _rentRepository.GetRentById(id);
                if (member != null)
                {
                    return await _rentRepository.GetRentById(id);
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
