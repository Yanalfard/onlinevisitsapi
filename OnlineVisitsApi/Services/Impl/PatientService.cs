using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Impl;
using OnlineVisitsApi.Services.Api;

namespace OnlineVisitsApi.Services.Impl
{
    public class PatientService : IPatientService
    {
        public TblPatient AddPatient(TblPatient patient)
        {
            return (TblPatient)new PatientRepo().AddPatient(patient);
        }
        public bool DeletePatient(int id)
        {
            return new PatientRepo().DeletePatient(id);
        }
        public bool UpdatePatient(TblPatient patient, int logId)
        {
            return new PatientRepo().UpdatePatient(patient, logId);
        }
        public List<TblPatient> SelectAllPatients()
        {
            return new PatientRepo().SelectAllPatients();
        }
        public TblPatient SelectPatientById(int id)
        {
            return (TblPatient)new PatientRepo().SelectPatientById(id);
        }
        public TblPatient SelectPatientByFirstName(string firstName)
        {
            return new PatientRepo().SelectPatientByFirstName(firstName);
        }
        public TblPatient SelectPatientByLastName(string lastName)
        {
            return new PatientRepo().SelectPatientByLastName(lastName);
        }
        public TblPatient SelectPatientByTellNo(string tellNo)
        {
            return new PatientRepo().SelectPatientByTellNo(tellNo);
        }
        public List<TblPatient> SelectPatientByIdentificationNo(int identificationNo)
        {
            return new PatientRepo().SelectPatientByIdentificationNo(identificationNo);
        }
        public TblPatient SelectPatientByUsernameAndPassword(string username, string password)
        {
            return new PatientRepo().SelectPatientByUsernameAndPassword(username, password);
        }
        public TblPatient SelectPatientByUsername(string username)
        {
            return new PatientRepo().SelectPatientByUsername(username);
        }
        public TblPatient SelectPatientByPassword(string password)
        {
            return new PatientRepo().SelectPatientByPassword(password);
        }

        public string ReserveStage1(int doctorId)
        {
            return new PatientRepo().ReserveStage1(doctorId);
        }

        public bool ReserveStage2(int doctorId, int patientId, string stageOnesTime)
        {
            return new PatientRepo().ReserveStage2(doctorId, patientId, stageOnesTime);
        }

        public List<TblDoctor> SelectDoctorsByPatientId(int patientId)
        {
            List<TblPatientDoctorRel> stp1 = new PatientDoctorRelRepo().SelectPatientDoctorRelByPatientId(patientId);
            List<TblDoctor> stp2 = new List<TblDoctor>();
            foreach (TblPatientDoctorRel rel in stp1)
                stp2.Add(new DoctorRepo().SelectDoctorById(rel.DoctorId));
            return stp2;
        }

    }
}