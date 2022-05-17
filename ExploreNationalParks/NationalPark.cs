using System.ComponentModel.DataAnnotations;


namespace ExploreNationalParks
{
    public class NationalPark
    {
        [Key]
        public int ParkID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        
        [Required]
        [StringLength(2000)]
        public string? Description { get; set; }
        
        [Required]
        public decimal Acres { get; set; }

        [Required]
        public decimal Km2 { get; set; }

        [Required]
        public decimal Latitude { get; set; }
        
        [Required]
        public decimal Longitude { get; set; }

        [Required]
        [StringLength(100)]
        public string? DateEstablished { get; set; }

        [Required]
        [StringLength(1200)]
        public string? ImageURL { get; set; }

        [Required]
        [StringLength(500)]
        public string? NpsLink { get; set; }
        
        [Required]
        [StringLength(20)]
        public string? State { get; set; }

        [Required]
        public decimal Visitors { get; set; }
    }
}
