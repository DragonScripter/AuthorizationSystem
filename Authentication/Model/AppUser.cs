using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class AppUser
    {
        public string Name { get; set; }
        public virtual ICollection<Content> Content { get; set; }
    }
}
