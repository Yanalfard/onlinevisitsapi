using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Impl;
using OnlineVisitsApi.Services.Api;

namespace OnlineVisitsApi.Services.Impl
{
    public class PatientDoctorRelService : IPatientDoctorRelService
    {
        public TblPatientDoctorRel AddPatientDoctorRel(TblPatientDoctorRel patientDoctorRel)
        {
            return (TblPatientDoctorRel)new PatientDoctorRelRepo().AddPatientDoctorRel(patientDoctorRel);
        }
        public bool DeletePatientDoctorRel(int id)
        {
            return new PatientDoctorRelRepo().DeletePatientDoctorRel(id);
        }
        public bool UpdatePatientDoctorRel(TblPatientDoctorRel patientDoctorRel, int logId)
        {
            return new PatientDoctorRelRepo().UpdatePatientDoctorRel(patientDoctorRel, logId);
        }
        public List<TblPatientDoctorRel> SelectAllPatientDoctorRels()
        {
            return new PatientDoctorRelRepo().SelectAllPatientDoctorRels();
        }
        public TblPatientDoctorRel SelectPatientDoctorRelById(int id)
        {
            return (TblPatientDoctorRel)new PatientDoctorRelRepo().SelectPatientDoctorRelById(id);
        }
        public List<TblPatientDoctorRel> SelectPatientDoctorRelByPatientId(int patientId)
        {
            return new PatientDoctorRelRepo().SelectPatientDoctorRelByPatientId(patientId);
        }
        public List<TblPatientDoctorRel> SelectPatientDoctorRelByDoctorId(int doctorId)
        {
            return new PatientDoctorRelRepo().SelectPatientDoctorRelByDoctorId(doctorId);
        }

    }
}