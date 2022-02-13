using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public interface IPublicationRepository
    {
        //get all book  Publishers 
        Task<List<PublicationDetails>> GetAllPublications();

        //add a publisher
        Task<int> AddPublication(PublicationDetails publicationDetails);

        //update a publisher
        Task UpdatePublication(PublicationDetails publicationDetails);

        //delete a publisher
        Task<int> DeletePublication(int? id);

        //get publisher by id
        Task<PublicationViewModel> GetPublisherById(int? id);
    }
}
