using System.Collections.Generic;
using System.Linq;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Api;
using OnlineVisitsApi.Utilities;

namespace OnlineVisitsApi.Repositories.Impl
{
    public class PatientDoctorRelRepo : IPatientDoctorRelRepo
    {
        public TblPatientDoctorRel AddPatientDoctorRel(TblPatientDoctorRel patientDoctorRel)
        {
            return (TblPatientDoctorRel)new MainProvider().Add(patientDoctorRel);
        }
        public bool DeletePatientDoctorRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPatientDoctorRel, id);
        }
        public bool UpdatePatientDoctorRel(TblPatientDoctorRel patientDoctorRel, int logId)
        {
            return new MainProvider().Update(patientDoctorRel, logId);
        }
        public List<TblPatientDoctorRel> SelectAllPatientDoctorRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPatientDoctorRel).Cast<TblPatientDoctorRel>().ToList();
        }
        public TblPatientDoctorRel SelectPatientDoctorRelById(int id)
        {
            return (TblPatientDoctorRel)new MainProvider().SelectById(MainProvider.Tables.TblPatientDoctorRel, id);
        }
        public List<TblPatientDoctorRel> SelectPatientDoctorRelByPatientId(int patientId)
        {
            return new MainProvider().SelectPatientDoctorRel(patientId, MainProvider.PatientDoctorRel.PatientId);
        }
        public List<TblPatientDoctorRel> SelectPatientDoctorRelByDoctorId(int doctorId)
        {
            return new MainProvider().SelectPatientDoctorRel(doctorId, MainProvider.PatientDoctorRel.DoctorId);
        }

    }
}