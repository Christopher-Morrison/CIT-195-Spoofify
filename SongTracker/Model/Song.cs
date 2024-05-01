using System.ComponentModel.DataAnnotations;

namespace SongTracker.Model
{
    public class Song
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 1),Required]
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 1), Required]
        public string Album { get; set; }
        [StringLength(100, MinimumLength = 1), Required]
        public string Artist { get; set; }
        [Required]
        public float Length { get; set; }
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


    }
}
