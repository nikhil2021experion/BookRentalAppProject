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
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationRepository _publicationRepository;

        public PublicationsController(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }


        #region get all publications
        [HttpGet]
        public async Task<List<PublicationDetails>> GetAllPublications()
        {
            return await _publicationRepository.GetAllPublications();
        }
        #endregion

        #region get publisher using id
        [HttpGet]
        [Route("GetPublisherById/{id}")]
        public async Task<PublicationViewModel> GetPublisherById(int? id)
        {
            try
            {
                var publisher = await _publicationRepository.GetPublisherById(id);
                if (publisher != null)
                {
                    return await _publicationRepository.GetPublisherById(id);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region add a publication
        [HttpPost]
        public async Task<IActionResult> AddPublication([FromBody] PublicationDetails publicationDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var publicationID = await _publicationRepository.AddPublication(publicationDetails);
                    if (publicationID > 0)
                    {
                        return Ok(publicationID);
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

        #region update a publication
        [HttpPut]
        public async Task<IActionResult> UpdatePublication([FromBody] PublicationDetails publicationDetails)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _publicationRepository.UpdatePublication(publicationDetails);
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


        #region delete a publication

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _publicationRepository.DeletePublication(id);
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
