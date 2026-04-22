using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class BreakFastFoods
    {
        public int Id { get; set; }

        public string FoodName { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int Calories { get; set; }

        public bool IsHealthy { get; set; }

        public int PreparationTime { get; set; }
    }
}
