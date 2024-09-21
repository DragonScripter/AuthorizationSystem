using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Interface
{
    public interface IUserService
    {
        Task<bool> userAuthAsync(string name, string password);
        Task<AppUser?> GetUserByNameAsync(string name);
        Task<bool> CreateUserAsync(AppUser User);
        Task<IEnumerable<AppUser>> GetAllUser();
        Task<bool> GetContentByIdAsync(int contentId);
        Task<IEnumerable<Content>> GetAllContentAsync();
    }
}
