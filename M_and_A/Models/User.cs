using System.Data;

namespace M_and_A.Models
{
    public class User
    {
        public enum UserType
        {
            User,
            Admin
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserType Type { get; set; }
    }
}
