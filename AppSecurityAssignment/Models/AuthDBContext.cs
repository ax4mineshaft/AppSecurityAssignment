using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace AppSecurityAssignment.Models

{
    public class AuthDbContext : IdentityDbContext<member>
    {
        private readonly IConfiguration _configuration;
        /*public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options){ }*/
        public AuthDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("AuthConnectionString"); optionsBuilder.UseSqlServer(connectionString);
        }
    }
}