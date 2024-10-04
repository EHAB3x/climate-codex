using ClimateCodex.Server.Data;
using ClimateCodex.Server.Models;

namespace ClimateCodex.Server.Repository
{
    public interface IClimateDataRepo
    {

        IEnumerable<ClimateData> GetAllClimateData(); 
        ClimateData GetClimateDataById(int id);       
        void AddClimateData(ClimateData climateData); 
        void UpdateClimateData(ClimateData climateData); 
        void DeleteClimateData(int id);
    }
    public class ClimateDataRepo : IClimateDataRepo
    {
        private readonly ClimateCodexDbContext _context;

        public ClimateDataRepo(ClimateCodexDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ClimateData> GetAllClimateData()
        {
            return _context.ClimateData.ToList();
        }

        public ClimateData GetClimateDataById(int id)
        {
            return _context.ClimateData.Find(id);
        }

        public void AddClimateData(ClimateData climateData)
        {
            _context.ClimateData.Add(climateData);
            _context.SaveChanges();
        }

        public void UpdateClimateData(ClimateData climateData)
        {
            _context.ClimateData.Update(climateData);
            _context.SaveChanges();
        }

        public void DeleteClimateData(int id)
        {
            var climateData = _context.ClimateData.Find(id);
            if (climateData != null)
            {
                _context.ClimateData.Remove(climateData);
                _context.SaveChanges();
            }
        }
    }
}
