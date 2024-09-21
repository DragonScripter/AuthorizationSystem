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

        //Contributor permissions
        Task<bool> CreateContentAsync(Content content);
        Task<bool> hasPermissionAsync(string Id, string perm);
    }
}
