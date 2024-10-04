using ClimateCodex.Server.Data;
using ClimateCodex.Server.Models;

namespace ClimateCodex.Server.Repository
{
    public interface IGHGTypeRepo
    {
        IEnumerable<GHGType> GetAllGHGTypes();
        GHGType GetGHGTypeById(int id);
        void AddGHGType(GHGType type);
        void UpdateGHGType(GHGType type);
        void DeleteGHGType(int id);
    }
    public class GHGTypeRepo : IGHGTypeRepo
    {
        private readonly ClimateCodexDbContext _context;

        public GHGTypeRepo(ClimateCodexDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GHGType> GetAllGHGTypes()
        {
            return _context.GHGTypes.ToList(); 
        }

        public GHGType GetGHGTypeById(int id)
        {
            return _context.GHGTypes.Find(id);
        }

        public void AddGHGType(GHGType type)
        {
            _context.GHGTypes.Add(type);
            _context.SaveChanges();
        }

        public void UpdateGHGType(GHGType type)
        {
            _context.GHGTypes.Update(type);
            _context.SaveChanges();
        }

        public void DeleteGHGType(int id)
        {
            var type = _context.GHGTypes.Find(id);
            if (type != null)
            {
                _context.GHGTypes.Remove(type);
                _context.SaveChanges();
            }
        }
    }
}
