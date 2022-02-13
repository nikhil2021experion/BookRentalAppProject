using BookRentalAppProject.Models;
using BookRentalAppProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly BookRentalContext _ContextFive;

        public  PublicationRepository(BookRentalContext ContextFive)
        {
            _ContextFive = ContextFive;
        }


        #region Add a publication
        public async Task<int> AddPublication(PublicationDetails publicationDetails)
        {
            if (_ContextFive != null)
            {
                await _ContextFive.PublicationDetails.AddAsync(publicationDetails);
                await _ContextFive.SaveChangesAsync();
                return publicationDetails.PublicationId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion

        #region get all publication
        public async Task<List<PublicationDetails>> GetAllPublications()
        {
            if (_ContextFive != null)
            {
                return await _ContextFive.PublicationDetails.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region update a publication
        public async Task UpdatePublication(PublicationDetails publicationDetails)
        {
            if (_ContextFive != null)
            {
                _ContextFive.Entry(publicationDetails).State = EntityState.Modified;
                _ContextFive.PublicationDetails.Update(publicationDetails);
                await _ContextFive.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region delete publication
        public async Task<int> DeletePublication(int? id)
        {
            int result = 0;
            if (_ContextFive != null)
            {
                var publisher = await _ContextFive.PublicationDetails.FirstOrDefaultAsync(p => p.PublicationId == id);
                //check condition
                if (publisher != null)
                {
                    //deleting the book
                    _ContextFive.PublicationDetails.Remove(publisher);

                    //commit the changes after deletion
                    result = await _ContextFive.SaveChangesAsync();
                }
                return result;
            }
            return result;
            //throw new NotImplementedException();
        }
        #endregion

        #region get publication details using PublicationID
        public async Task<PublicationViewModel> GetPublisherById(int? id)
        {

            if (_ContextFive != null)
            {
                //var members = await _ContextFour.Members.FindAsync(id);

                return await (from p in _ContextFive.PublicationDetails
                              where p.PublicationId == id
                              select new PublicationViewModel
                              {
                                  PublicationId = p.PublicationId,
                                  PublicationName = p.PublicationName
                              }).FirstOrDefaultAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
