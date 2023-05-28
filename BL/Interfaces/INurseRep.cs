using SS_NurseCore5.Models;
using System.Linq;

namespace SS_NurseCore5.BL.Interfaces
{
    public interface INurseRep
    {
        IQueryable<NurseVM> Get();
        NurseVM GetNurseById(int id);
        void Add(NurseVM nurse);
        void Edit(NurseVM nurse);
        void Delete(int id);
    }
}
