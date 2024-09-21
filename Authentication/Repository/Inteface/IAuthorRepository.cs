using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Inteface
{
    public interface IAuthorRepository
    {
        Task<bool> userAuthAsync(string name, string password);
        Task<AppUser?> GetAuthorByNameAsync(string name);
        Task<bool> CreateAuthorAsync(AppUser Author);
        Task<IEnumerable<AppUser>> GetAllAuthors();

        //Author permissions
        Task<bool> CreateContentAsync(Content content);
        Task<bool> GetContentByIdAsync(int contentId);
        Task<IEnumerable<Content>> GetAllContentAsync();
        Task<bool> PublishContent(int contentID, string authorID );
        Task<bool> hasPermissionAsync(string userID, string perm);
    }
}
