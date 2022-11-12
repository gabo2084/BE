using System.ComponentModel.DataAnnotations;

namespace BE.Domain.Entities.Authentication
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}