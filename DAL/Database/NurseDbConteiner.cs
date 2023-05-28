using Microsoft.EntityFrameworkCore;
using SS_Nurse.DAL.Entities;

namespace SS_Nurse.DAL.Database
{
    public class NurseDbConteiner : DbContext
    {
        public NurseDbConteiner(DbContextOptions<NurseDbConteiner> options) : base(options) {
        }
        public DbSet<Nurse> Nurse{ get; set; }
    }
}
