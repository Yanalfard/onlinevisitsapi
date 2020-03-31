using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Repositories.Api
{
    public interface IDoctorRepo
    {
        TblDoctor AddDoctor(TblDoctor doctor);
        bool DeleteDoctor(int id);
        bool UpdateDoctor(TblDoctor doctor, int logId);
        List<TblDoctor> SelectAllDoctors();
        TblDoctor SelectDoctorById(int id);
        TblDoctor SelectDoctorByFirstName(string firstName);
        TblDoctor SelectDoctorByLastName(string lastName);
        TblDoctor SelectDoctorByTellNo(string tellNo);
        List<TblDoctor> SelectDoctorByIdentificationNo(int identificationNo);
        TblDoctor SelectDoctorByUsernameAndPassword(string username ,string password);
        TblDoctor SelectDoctorByUsername(string username);
        TblDoctor SelectDoctorByPassword(string password);
        List<TblDoctor> SelectDoctorBySection(string section);

    }
}