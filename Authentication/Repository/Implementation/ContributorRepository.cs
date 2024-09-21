using Authentication.Model;
using Authentication.Repository.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Implementation
{
    public class ContributorRepository : IContributorRepository
    {
        public Task<bool> CreateContentAsync(Content content)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateContributorAsync(AppUser Contributor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Content>> GetAllContentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> GetAllContributors()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetContentByIdAsync(int contentId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetContributorByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> userAuthAsync(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
