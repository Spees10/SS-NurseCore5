using SS_Nurse.DAL.Database;
using SS_NurseCore5.BL.Interfaces;
using SS_NurseCore5.Models;
using System.Linq;

namespace SS_NurseCore5.BL.Repositories
{
    public class NurseRep : INurseRep
    {
        private readonly NurseDbConteiner ndb;
        private readonly NurseDbConteiner _Imapper;

        public NurseRep(NurseDbConteiner ndb, NurseDbConteiner imapper)
        {
            this.ndb = ndb;
            _Imapper = imapper;
        }

        public IQueryable<NurseVM> Get()
        {
            IQueryable<NurseVM> data = GetAllNurses();
            return data;
        }

        public void Add(NurseVM nurse)
        {
            var data = nurse.ToViewModel();
            ndb.Nurse.Add(data);
            ndb.SaveChanges();
        }

        public void Edit(NurseVM nurse)
        {
            var data = nurse.ToViewModel();

            ndb.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            ndb.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedObject = ndb.Nurse.Find(id);
            //var DeletedObject = GetNurseById(id);
            ndb.Nurse.Remove(DeletedObject);
            ndb.SaveChanges();
        }


        /////////////////////////////
        public NurseVM GetNurseById(int id)
        {
            return ndb.Nurse.Where(a => a.id == id)
                                    .Select(a => new NurseVM
                                    {
                                        id=a.id,
                                        Name = a.Name,
                                        Phone = a.Phone,
                                        State = a.State,
                                        Availability = a.Availability
                                    }).FirstOrDefault();
        }
        private IQueryable<NurseVM> GetAllNurses()
        {
            return ndb.Nurse
                       .Select(a => new NurseVM
                       {
                           id = a.id,
                           Name = a.Name,
                           Phone = a.Phone,
                           State = a.State,
                           Availability = a.Availability
                       });
        }
    }
}