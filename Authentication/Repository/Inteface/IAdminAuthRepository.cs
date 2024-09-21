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
        //Admin permissions
        Task<bool> CreateContentAsync(Content content);
        Task<bool> UpdateContent(Content content);
        Task<bool> DeleteContent(Content content);
        Task<bool> PublishContent(Content content);
        Task<bool> hasPermissionAsync(string userID, string perm);

    }
}
