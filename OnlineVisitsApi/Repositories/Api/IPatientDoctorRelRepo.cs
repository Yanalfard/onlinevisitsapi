using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Repositories.Api
{
    public interface IPatientDoctorRelRepo
    {
        TblPatientDoctorRel AddPatientDoctorRel(TblPatientDoctorRel patientDoctorRel);
        bool DeletePatientDoctorRel(int id);
        bool UpdatePatientDoctorRel(TblPatientDoctorRel patientDoctorRel, int logId);
        List<TblPatientDoctorRel> SelectAllPatientDoctorRels();
        TblPatientDoctorRel SelectPatientDoctorRelById(int id);
        List<TblPatientDoctorRel> SelectPatientDoctorRelByPatientId(int patientId);
        List<TblPatientDoctorRel> SelectPatientDoctorRelByDoctorId(int doctorId);

    }
}