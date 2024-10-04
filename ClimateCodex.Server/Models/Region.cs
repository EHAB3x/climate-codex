using System.ComponentModel.DataAnnotations;

namespace ClimateCodex.Server.Models
{
    
        public class Region
        {
            public int RegionId { get; set; }
            [Required]
            public string Name { get; set; }

            public ICollection<EmissionData> EmissionData { get; set; }
        }
    

}
