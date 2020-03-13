using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Repositories.Api
{
    public interface IDoctorProgramRelRepo
    {
        TblDoctorProgramRel AddDoctorProgramRel(TblDoctorProgramRel doctorProgramRel);
        bool DeleteDoctorProgramRel(int id);
        bool UpdateDoctorProgramRel(TblDoctorProgramRel doctorProgramRel, int logId);
        List<TblDoctorProgramRel> SelectAllDoctorProgramRels();
        TblDoctorProgramRel SelectDoctorProgramRelById(int id);
        List<TblDoctorProgramRel> SelectDoctorProgramRelByDoctorId(int doctorId);
        List<TblDoctorProgramRel> SelectDoctorProgramRelByProgramId(int programId);

    }
}