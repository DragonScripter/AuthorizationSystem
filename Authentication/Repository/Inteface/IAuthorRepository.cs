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

        //Author permissions
        Task<bool> CreateContentAsync(Content content);
        Task<bool> PublishContent(int contentID, string authorID );
        Task<bool> hasPermissionAsync(string userID, string perm);
    }
}
