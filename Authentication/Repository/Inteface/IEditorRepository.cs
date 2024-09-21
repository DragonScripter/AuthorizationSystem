using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Inteface
{
    public interface IEditorRepository
    {

        //Editor permissions
        Task UpdateContent(Content content);
        Task<bool> hasPermissionAsync(string userID, string perm);
    }
}
