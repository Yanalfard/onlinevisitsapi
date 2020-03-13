using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Impl;
using OnlineVisitsApi.Services.Api;

namespace OnlineVisitsApi.Services.Impl
{
    public class DoctorProgramRelService : IDoctorProgramRelService
    {
        public TblDoctorProgramRel AddDoctorProgramRel(TblDoctorProgramRel doctorProgramRel)
        {
            return new DoctorProgramRelRepo().AddDoctorProgramRel(doctorProgramRel);
        }
        public bool DeleteDoctorProgramRel(int id)
        {
            return new DoctorProgramRelRepo().DeleteDoctorProgramRel(id);
        }
        public bool UpdateDoctorProgramRel(TblDoctorProgramRel doctorProgramRel, int logId)
        {
            return new DoctorProgramRelRepo().UpdateDoctorProgramRel(doctorProgramRel, logId);
        }
        public List<TblDoctorProgramRel> SelectAllDoctorProgramRels()
        {
            return new DoctorProgramRelRepo().SelectAllDoctorProgramRels();
        }
        public TblDoctorProgramRel SelectDoctorProgramRelById(int id)
        {
            return (TblDoctorProgramRel)new DoctorProgramRelRepo().SelectDoctorProgramRelById(id);
        }
        public List<TblDoctorProgramRel> SelectDoctorProgramRelByDoctorId(int doctorId)
        {
            return new DoctorProgramRelRepo().SelectDoctorProgramRelByDoctorId(doctorId);
        }
        public List<TblDoctorProgramRel> SelectDoctorProgramRelByProgramId(int programId)
        {
            return new DoctorProgramRelRepo().SelectDoctorProgramRelByProgramId(programId);
        }

    }
}