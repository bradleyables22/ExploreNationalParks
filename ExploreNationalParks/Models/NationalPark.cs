using System.ComponentModel.DataAnnotations;


namespace ExploreNationalParks
{
    public class NationalPark
    {
        [Key]
        public int ParkID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
        
        [Required]
        public int Acres { get; set; }

        [Required]
        public int Km2 { get; set; }

        [Required]
        public int Latitude { get; set; }
        
        [Required]
        public int Longitude { get; set; }

        [Required]
        public DateTime DateEstablished { get; set; }

        [Required]
        [StringLength(1200)]
        public string ImageURL { get; set; }

        [Required]
        [StringLength(500)]
        public string NpsLink { get; set; }
        
        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        public int Visitors { get; set; }
    }
}
