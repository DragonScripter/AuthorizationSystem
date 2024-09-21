using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Authentication.Repository.Inteface
{
   public interface IContributorRepository
    {
        Task<bool> userAuthAsync(string name, string password);
        Task<AppUser?> GetContributorByNameAsync(string name);
        Task<bool> CreateContributorAsync(AppUser Contributor);
        Task<IEnumerable<AppUser>> GetAllContributors();

        //Contributor permissions
        Task<bool> CreateContentAsync(Content content);
        Task<bool> GetContentByIdAsync(int contentId);
        Task<IEnumerable<Content>> GetAllContentAsync();
        Task<bool> hasPermissionAsync(string Id, string perm);
    }
}
