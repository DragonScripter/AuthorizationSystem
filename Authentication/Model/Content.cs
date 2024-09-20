using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class Content
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required] 
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }

        public bool isPublished { get; set; } = false;

        [StringLength(200)]
        public string description { get; set; }

        public ICollection<string> Tags { get; set; } = new List<string>();
        public string imageUrl { get; set; }



    }
}
