using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public interface IRentRepository
    {
        Task<List<RentViewModel>> GetAllBooksWithRentDetails();

        //add a rent
        Task<int> AddRent(RentDetails rentDetails);

        //update a Book
        Task UpdateRent(RentDetails rentDetails);

        Task<RentViewModel> GetRentById(int? id);


    }
}
