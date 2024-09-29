using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class AppUser : IdentityUser<int>
    {

        public required string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int RoleID { get; set; }
        public virtual RoleEF Role { get; set; }
        
        public virtual ICollection<Content> Content { get; set; } = new List<Content>();

        public AppUser() 
        {
            Role = new RoleEF();
        }
    }
}
