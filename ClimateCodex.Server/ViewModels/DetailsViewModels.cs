using ClimateCodex.Server.Models;

namespace ClimateCodex.Server.ViewModels
{
    public class DetailsViewModels
    {
       
            public ClimateData ClimateData { get; set; }
            public EmissionData EmissionData { get; set; }
            public GHGType GHGType { get; set; }
            public User User { get; set; }
            public Region Region { get; set; } 

    }
}
