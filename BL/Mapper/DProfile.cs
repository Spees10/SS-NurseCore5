using AutoMapper;
using SS_Nurse.DAL.Entities;
using SS_NurseCore5.Models;

namespace SS_NurseCore5.BL.Mapper
{
    public class DProfile : Profile
    {
        public DProfile()
        {
            CreateMap<Nurse, NurseVM>();
            CreateMap<NurseVM, Nurse>();

        }
    }
}
