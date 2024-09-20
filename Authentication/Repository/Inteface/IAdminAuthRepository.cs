using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Inteface
{
    public interface IAdminAuth
    {
        Task<bool> userAuthAsync(string name, string password);
        Task<AppUser> GetAdminByNameAsync(string name);
        Task<bool> CreateAdminAsync(AppUser Admin);
        Task<IEnumerable<AppUser>> GetAllAdmin();

        //Contributor permissions
        Task<bool> CreateContentAsync(Content content);
        Task<bool> GetContentByIdAsync(int contentId);
        Task<IEnumerable<Content>> GetAllContentAsync();
        Task<bool> UpdateContent(Content content);
        Task<bool> DeleteContent(Content content);
        Task<bool> PublishContent(Content content);

    }
}
