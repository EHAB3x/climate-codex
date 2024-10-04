namespace ClimateCodex.Server.Models
{
    public class GHGType
    {
        public int GHGTypeId { get; set; }
        public string GasName { get; set; }
        public string Description { get; set; }

        public ICollection<EmissionData> EmissionData { get; set; }
    }
}
