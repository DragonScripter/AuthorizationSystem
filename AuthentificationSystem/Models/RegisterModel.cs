using System.ComponentModel.DataAnnotations;

namespace AuthentificationSystem.Models
{
    public class RegisterModel
    { 
        public required string name { get; set; }
        public required string username { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
    }
}
