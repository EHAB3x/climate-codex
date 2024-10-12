namespace ClimateCodex.Server.Controllers.Repository
{
    public interface IDataService
    {
        object GetWeatherData(string gas, string location);
    }

    public class DataService : IDataService
    {
        // Your data source (could be a database, API, etc.)

        public object GetWeatherData(string gas, string location)
        {
            // Implement your logic to retrieve data based on gas and location
            // For example, filter data from a database or an API call

            // Mock data for demonstration
            var data = new
            {
                Gas = gas,
                Location = location,
                Value = "Sample data related to " + location + " for " + gas
            };

            return data; // Return the actual data
        }
    }

}
