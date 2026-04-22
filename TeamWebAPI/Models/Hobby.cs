using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class Hobby
    {
        public int Id { get; set; }

        public string HobbyName { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string SkillLevel { get; set; } = string.Empty;

        public int HoursPerWeek { get; set; }
    }
}