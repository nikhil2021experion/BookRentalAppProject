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
    }
}
