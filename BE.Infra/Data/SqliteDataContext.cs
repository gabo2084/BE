using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BE.Infra.Data
{
    public class SqliteDataContext : BEContext
    {
        public SqliteDataContext(IConfiguration configuration) : base(configuration)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(_configuration.GetConnectionString("SystemDB"));
        }
    }
}