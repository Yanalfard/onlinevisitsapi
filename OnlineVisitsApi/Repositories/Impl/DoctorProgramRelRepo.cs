using System.Collections.Generic;
using System.Linq;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Api;
using OnlineVisitsApi.Utillities;

namespace OnlineVisitsApi.Repositories.Impl
{
    public class DoctorProgramRelRepo : IDoctorProgramRelRepo
    {
        public TblDoctorProgramRel AddDoctorProgramRel(TblDoctorProgramRel doctorProgramRel)
        {
            return (TblDoctorProgramRel)new MainProvider().Add(doctorProgramRel);
        }
        public bool DeleteDoctorProgramRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblDoctorProgramRel, id);
        }
        public bool UpdateDoctorProgramRel(TblDoctorProgramRel doctorProgramRel, int logId)
        {
            return new MainProvider().Update(doctorProgramRel, logId);
        }
        public List<TblDoctorProgramRel> SelectAllDoctorProgramRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblDoctorProgramRel).Cast<TblDoctorProgramRel>().ToList();
        }
        public TblDoctorProgramRel SelectDoctorProgramRelById(int id)
        {
            return (TblDoctorProgramRel)new MainProvider().SelectById(MainProvider.Tables.TblDoctorProgramRel, id);
        }
        public List<TblDoctorProgramRel> SelectDoctorProgramRelByDoctorId(int doctorId)
        {
            return new MainProvider().SelectDoctorProgramRel(doctorId, MainProvider.DoctorProgramRel.DoctorId);
        }
        public List<TblDoctorProgramRel> SelectDoctorProgramRelByProgramId(int programId)
        {
            return new MainProvider().SelectDoctorProgramRel(programId, MainProvider.DoctorProgramRel.ProgramId);
        }

    }
}