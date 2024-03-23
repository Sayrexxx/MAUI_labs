using ISP.Entities;

namespace ISP.Services
{
    public interface IDbService
    {
        public IEnumerable<ProcedureGroups> GetAllProcedureGroups();
        public IEnumerable<Procedures> GetAllProcedures(int id);
        public void Init();
    }
}