using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimateCodex.Server.Models
{
    public class EmissionData
    {
        public int EmissionDataId { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
       
        [ForeignKey("GHGType")]
        public int GHGTypeId { get; set; }

        [Range(1, 12)]
        public int Month { get; set; }
        
        [Range(2000, 2023)]
        public int Year { get; set; }
        public double EmissionValue { get; set; }

        public Region Region { get; set; }
        public GHGType GHGType { get; set; }
    }
}
