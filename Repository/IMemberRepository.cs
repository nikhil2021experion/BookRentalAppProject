using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public interface IMemberRepository
    {
        //get all Members
        Task<List<MembersViewModel>> GetAllMembers();

        //add a Member
        Task<int> AddMember(Members members);

        //update a Member
        Task UpdateMember(Members members);

        //get member details using memberId
        Task<UserViewModel> GetMemberById(int? id);

        //getting member details by member name
        Task<UserViewModel> GetMemberByName(string name);

        //getting members with their fine amount
        Task<List<MembersViewModel>> GetAllMembersWithFine();


        Task<MembersViewModel> GetUserByuserNameAndPassword(string user, string pass);
    }
}
