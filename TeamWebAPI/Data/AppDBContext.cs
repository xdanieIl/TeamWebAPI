using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Models;
using System;

namespace TeamWebAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        public DbSet<Hobby> Hobbies => Set<Hobby>();
        public DbSet<BreakFastFoods> BreakFastFoods => Set<BreakFastFoods>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember
                {
                    Id = 1,
                    FullName = "Lorenzo Craig",
                    Birthdate = new DateTime(2006, 5, 11),
                    CollegeProgram = "IT",
                    YearInProgram = "Sophmore"
                }
                );
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby
                {
                    Id = 1,
                    HobbyName = "Gaming",
                    Category = "Indoor",
                    SkillLevel = "Easy",
                    HoursPerWeek = 12
                }
                );
            modelBuilder.Entity<BreakFastFoods>().HasData(
                new BreakFastFoods
                {
                    Id = 1,
                    FoodName = "Eggs",
                    Category = "Savory",
                    Calories = 100,
                    IsHealthy = true,
                    PreparationTime = 2
                }
                );
        }
    }
}