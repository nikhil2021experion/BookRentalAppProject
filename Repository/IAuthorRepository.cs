using BookRentalAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalAppProject.Repository
{
    public interface IAuthorRepository
    {
        //get all Authors
        Task<List<Authors>> GetAllAuthors();

        //add a Author
        Task<int> AddAuthors(Authors authors);

        //update a Author
        Task UpdateAuthor(Authors authors);

        Task<int> DeleteAuthor(int? id);
    }
}
