using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Models;

namespace TeamWebAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        public DbSet<Hobby> Hobbies => Set<Hobby>();
    }
}