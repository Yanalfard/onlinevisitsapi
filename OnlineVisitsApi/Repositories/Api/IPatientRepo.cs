using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Repositories.Api
{
    public interface IPatientRepo
    {
        TblPatient AddPatient(TblPatient patient);
        bool DeletePatient(int id);
        bool UpdatePatient(TblPatient patient, int logId);
        List<TblPatient> SelectAllPatients();
        TblPatient SelectPatientById(int id);
        TblPatient SelectPatientByTellNo(string tellNo);
        TblPatient SelectPatientByFirstName(string firstName);
        TblPatient SelectPatientByLastName(string lastName);
        List<TblPatient> SelectPatientByIdentificationNo(int identificationNo);
        TblPatient SelectPatientByUsernameAndPassword(string username ,string password);
        TblPatient SelectPatientByUsername(string username);
        TblPatient SelectPatientByPassword(string password);

    }
}