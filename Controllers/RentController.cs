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
    public class RentController : ControllerBase
    {
        private readonly IRentRepository _rentRepository;

        public RentController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        #region add a rent
        [HttpPost]
        public async Task<IActionResult> AddRent([FromBody] RentDetails rentDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rentID = await _rentRepository.AddRent(rentDetails);
                    if (rentID > 0)
                    {
                        return Ok(rentID);
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

        #region update a rent
        [HttpPut]
        public async Task<IActionResult> UpdateRent([FromBody] RentDetails rentDetails)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _rentRepository.UpdateRent(rentDetails);
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


       

    }
}
