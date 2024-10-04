using ClimateCodex.Server.Data;
using ClimateCodex.Server.Models;

namespace ClimateCodex.Server.Repository
{
    public interface IEmissionDataRepo
    {
        IEnumerable<EmissionData> GetAllEmissionData();
        EmissionData GetEmissionDataById(int id);
        void AddEmissionData(EmissionData data);
        void UpdateEmissionData(EmissionData data);
        void DeleteEmissionData(int id);
        bool SaveChanges();
    }
    public class EmissionDataRepo : IEmissionDataRepo
    {
        private readonly ClimateCodexDbContext _context;

        public EmissionDataRepo(ClimateCodexDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmissionData> GetAllEmissionData()
        {
            return _context.EmissionDatas.ToList();
        }

        public EmissionData GetEmissionDataById(int id)
        {
            return _context.EmissionDatas.FirstOrDefault(e => e.EmissionDataId == id);
        }

        public void AddEmissionData(EmissionData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            _context.EmissionDatas.Add(data);
        }

        public void UpdateEmissionData(EmissionData data)
        {

        }

        public void DeleteEmissionData(int id)
        {
            var emissionData = _context.EmissionDatas.FirstOrDefault(e => e.EmissionDataId == id);
            if (emissionData != null)
            {
                _context.EmissionDatas.Remove(emissionData);
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
