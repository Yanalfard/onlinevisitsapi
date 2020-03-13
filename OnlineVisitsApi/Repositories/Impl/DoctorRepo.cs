using System.Collections.Generic;
using System.Linq;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Api;
using OnlineVisitsApi.Utillities;

namespace OnlineVisitsApi.Repositories.Impl
{
    public class DoctorRepo : IDoctorRepo
    {
        public TblDoctor AddDoctor(TblDoctor doctor)
        {
            return (TblDoctor)new MainProvider().Add(doctor);
        }
        public bool DeleteDoctor(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblDoctor, id);
        }
        public bool UpdateDoctor(TblDoctor doctor, int logId)
        {
            return new MainProvider().Update(doctor, logId);
        }
        public List<TblDoctor> SelectAllDoctors()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblDoctor).Cast<TblDoctor>().ToList();
        }
        public TblDoctor SelectDoctorById(int id)
        {
            return (TblDoctor)new MainProvider().SelectById(MainProvider.Tables.TblDoctor, id);
        }
        public TblDoctor SelectDoctorByFirstName(string firstName)
        {
            return new MainProvider().SelectDoctorByFirstName(firstName);
        }
        public TblDoctor SelectDoctorByLastName(string lastName)
        {
            return new MainProvider().SelectDoctorByLastName(lastName);
        }
        public TblDoctor SelectDoctorByTellNo(string tellNo)
        {
            return new MainProvider().SelectDoctorByTellNo(tellNo);
        }
        public List<TblDoctor> SelectDoctorByIdentificationNo(int identificationNo)
        {
            return new MainProvider().SelectDoctorByIdentificationNo(identificationNo);
        }
        public TblDoctor SelectDoctorByUsernameAndPassword(string username ,string password)
        {
            return new MainProvider().SelectDoctorByUsernameAndPassword(username, password);
        }
        public TblDoctor SelectDoctorByUsername(string username)
        {
            return new MainProvider().SelectDoctorByUsername(username);
        }
        public TblDoctor SelectDoctorByPassword(string password)
        {
            return new MainProvider().SelectDoctorByPassword(password);
        }

    }
}