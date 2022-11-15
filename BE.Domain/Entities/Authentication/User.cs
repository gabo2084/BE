

using System.Text.Json.Serialization;

namespace BE.Domain.Entities.Authentication
{
    public class User
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public int RoleId { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set;}
 

        //Navigation Properties

        public Role Role { get; set; }
    }
}