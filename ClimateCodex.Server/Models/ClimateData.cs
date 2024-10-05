namespace ClimateCodex.Server.Models
{
    public class ClimateData
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public int Year { get; set; }
        public float CO2Emissions { get; set; }
        public float MethaneEmissions { get; set; }
        

        
    }
}
