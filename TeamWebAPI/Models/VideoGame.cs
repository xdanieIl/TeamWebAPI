using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Platform { get; set; }

        public int ReleaseYear { get; set; }

        public double Rating { get; set; }
    }
}
