using System.Collections.Generic;
using System.Linq;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Api;
using OnlineVisitsApi.Utilities;

namespace OnlineVisitsApi.Repositories.Impl
{
    public class PatientRepo : IPatientRepo
    {
        public TblPatient AddPatient(TblPatient patient)
        {
            return (TblPatient)new MainProvider().Add(patient);
        }
        public bool DeletePatient(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPatient, id);
        }
        public bool UpdatePatient(TblPatient patient, int logId)
        {
            return new MainProvider().Update(patient, logId);
        }
        public List<TblPatient> SelectAllPatients()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPatient).Cast<TblPatient>().ToList();
        }
        public TblPatient SelectPatientById(int id)
        {
            return (TblPatient)new MainProvider().SelectById(MainProvider.Tables.TblPatient, id);
        }
        public TblPatient SelectPatientByFirstName(string firstName)
        {
            return new MainProvider().SelectPatientByFirstName(firstName);
        }
        public TblPatient SelectPatientByLastName(string lastName)
        {
            return new MainProvider().SelectPatientByLastName(lastName);
        }
        public TblPatient SelectPatientByTellNo(string tellNo)
        {
            return new MainProvider().SelectPatientByTellNo(tellNo);
        }
        public List<TblPatient> SelectPatientByIdentificationNo(int identificationNo)
        {
            return new MainProvider().SelectPatientByIdentificationNo(identificationNo);
        }
        public TblPatient SelectPatientByUsernameAndPassword(string username, string password)
        {
            return new MainProvider().SelectPatientByUsernameAndPassword(username, password);
        }
        public TblPatient SelectPatientByUsername(string username)
        {
            return new MainProvider().SelectPatientByUsername(username);
        }
        public TblPatient SelectPatientByPassword(string password)
        {
            return new MainProvider().SelectPatientByPassword(password);
        }

        public string ReserveStage1(int doctorId)
        {
            return new MainProvider().ReserveStage1(doctorId);
        }

        public TblPatientDoctorRel ReserveStage2(int doctorId, int patientId, string stageOnesTime)
        {
            return new MainProvider().ReserveStage2(doctorId, patientId, stageOnesTime);
        }
    }
}