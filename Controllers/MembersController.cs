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
    public class MembersController : ControllerBase
    {

        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        #region get all Members
        [HttpGet]
        public async Task<List<Members>> GetAllMembers()
        {
            return await _memberRepository.GetAllMembers();
        }
        #endregion

        #region add a book
        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] Members members)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var memberID = await _memberRepository.AddMember(members);
                    if (memberID > 0)
                    {
                        return Ok(memberID);
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
        public async Task<IActionResult> UpdateMember([FromBody] Members members)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _memberRepository.UpdateMember(members);
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



        #region getting member details by id
        [HttpGet]
        [Route("GetMemberById/{id}")]
        public async Task<UserViewModel> GetMemberById(int? id)
        {
            try
            {
                var member = await _memberRepository.GetMemberById(id);
                if (member != null)
                {
                    return await _memberRepository.GetMemberById(id);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region getting member details by name
        [HttpGet]
        [Route("GetMemberByName/{name}")]
        public async Task<UserViewModel> GetMemberByName(string name)
        {
            try
            {
                var member = await _memberRepository.GetMemberByName(name);
                if (member != null)
                {
                    return await _memberRepository.GetMemberByName(name);
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
