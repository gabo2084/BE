using BE.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BE.Infra.Data
{
    public class BEContext : DbContext
    {

        public readonly IConfiguration _configuration;

        public BEContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(_configuration.GetConnectionString("SystemDB"));
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}