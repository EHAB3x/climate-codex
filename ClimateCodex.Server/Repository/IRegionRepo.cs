using ClimateCodex.Server.Data;
using ClimateCodex.Server.Models;

namespace ClimateCodex.Server.Repository
{
    public interface IRegionRepo
    {
        IEnumerable<Region> GetAllRegions();
        Region GetRegionById(int id);
        void AddRegion(Region region);
        void UpdateRegion(Region region);
        void DeleteRegion(int id);
    }
    public class RegionRepo : IRegionRepo
    {
        private readonly ClimateCodexDbContext _context;

        public RegionRepo(ClimateCodexDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            return _context.Regions.ToList(); 
        }

        public Region GetRegionById(int id)
        {
            return _context.Regions.FirstOrDefault(r => r.RegionId == id); 
        }

        public void AddRegion(Region region)
        {
            _context.Regions.Add(region); 
            _context.SaveChanges();
        }

        public void UpdateRegion(Region region)
        {
            _context.Regions.Update(region); 
            _context.SaveChanges();
        }

        public void DeleteRegion(int id)
        {
            var region = _context.Regions.FirstOrDefault(r => r.RegionId == id);
            if (region != null)
            {
                _context.Regions.Remove(region); 
                _context.SaveChanges();
            }
        }
    }
}
