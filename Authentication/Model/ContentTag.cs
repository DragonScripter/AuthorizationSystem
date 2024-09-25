using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class ContentTag
    {
        public int ContentID { get; set; }
        public required Content Content { get; set; }

        public int TagID { get; set; }
        public Tag? Tag { get; set; }
    }
}
