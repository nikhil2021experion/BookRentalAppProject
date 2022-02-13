using BookRentalAppProject.Models;
using BookRentalAppProject.Repository;
using BookRentalAppProject.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMemberRepository _memberRepository;
        private readonly IConfiguration _config;

        public MembersController(IMemberRepository memberRepository, IConfiguration config)
        {
            _memberRepository = memberRepository;
            _config = config;
        }

        #region get all Members
        [HttpGet]
        [Route("GetMembers")]
        public async Task<List<MembersViewModel>> GetAllMembers()
        {
            return await _memberRepository.GetAllMembers();
        }
        #endregion

        #region add a member
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

        #region update  member
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

        #region get members with fine
        [HttpGet]
        [Route("GetAllMembersWithFine")]
        public async Task<List<MembersViewModel>> GetAllMembersWithFine()
        {
            try
            {
                var member = await _memberRepository.GetAllMembersWithFine();
                if (member != null)
                {
                    return await _memberRepository.GetAllMembersWithFine();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion



        #region jwt

        [HttpGet("EnterCredentials={username}&{password}")]
        //[Authorize(AuthenticationSchemes ="Bearer")]
        public async Task<IActionResult> GetUserbyNameandPass(string username, string password)
        {

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //signing credential
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials);
            var response = Ok(new { Token = ' ', UserName = ' ', UserPassword=' ' ,Roleid = ' ' });

            if (ModelState.IsValid)
            {
                try
                {
                    var tokens = new JwtSecurityTokenHandler().WriteToken(token);
                    var memb = await _memberRepository.GetUserByuserNameAndPassword(username, password);
                    response = Ok(new
                    {
                        Token = tokens,
                        MemberName = memb.MemberName,
                        Password = memb.Password,
                        RoleId = memb.RoleId,
                        MemberId = memb.MemberId

                    });
                    return response;
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
