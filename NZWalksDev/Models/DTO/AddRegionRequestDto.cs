using System.ComponentModel.DataAnnotations;

namespace NZWalksDev.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="")]
        [MaxLength(3, ErrorMessage ="")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
