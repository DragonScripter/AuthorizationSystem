using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int RoleID { get; set; }
        public virtual RoleEF Role { get; set; }
        
        public virtual ICollection<Content> Content { get; set; } = new List<Content>();

    }
}
