using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Impl;
using OnlineVisitsApi.Services.Api;

namespace OnlineVisitsApi.Services.Impl
{
    public class DoctorService : IDoctorService
    {
        public TblDoctor AddDoctor(TblDoctor doctor)
        {
            return new DoctorRepo().AddDoctor(doctor);
        }
        public bool DeleteDoctor(int id)
        {
            return new DoctorRepo().DeleteDoctor(id);
        }
        public bool UpdateDoctor(TblDoctor doctor, int logId)
        {
            return new DoctorRepo().UpdateDoctor(doctor, logId);
        }
        public List<TblDoctor> SelectAllDoctors()
        {
            return new DoctorRepo().SelectAllDoctors();
        }
        public TblDoctor SelectDoctorById(int id)
        {
            return (TblDoctor)new DoctorRepo().SelectDoctorById(id);
        }
        public TblDoctor SelectDoctorByFirstName(string firstName)
        {
            return new DoctorRepo().SelectDoctorByFirstName(firstName);
        }
        public TblDoctor SelectDoctorByLastName(string lastName)
        {
            return new DoctorRepo().SelectDoctorByLastName(lastName);
        }
        public TblDoctor SelectDoctorByTellNo(string tellNo)
        {
            return new DoctorRepo().SelectDoctorByTellNo(tellNo);
        }
        public List<TblDoctor> SelectDoctorByIdentificationNo(int identificationNo)
        {
            return new DoctorRepo().SelectDoctorByIdentificationNo(identificationNo);
        }
        public TblDoctor SelectDoctorByUsernameAndPassword(string username, string password)
        {
            return new DoctorRepo().SelectDoctorByUsernameAndPassword(username, password);
        }
        public TblDoctor SelectDoctorByUsername(string username)
        {
            return new DoctorRepo().SelectDoctorByUsername(username);
        }
        public TblDoctor SelectDoctorByPassword(string password)
        {
            return new DoctorRepo().SelectDoctorByPassword(password);
        }

        public List<TblDoctor> SelectDoctorBySection(string section)
        {
            return new DoctorRepo().SelectDoctorBySection(section);
        }

        public List<TblDoctor> SelectDoctorIfHasProgram(string section)
        {
            return new DoctorRepo().SelectDoctorIfHasProgram(section);
        }

        public List<TblProgram> SelectProgramsByDoctorId(int doctorId)
        {
            List<TblDoctorProgramRel> stp1 = new DoctorProgramRelRepo().SelectDoctorProgramRelByDoctorId(doctorId);
            List<TblProgram> stp2 = new List<TblProgram>();
            foreach (TblDoctorProgramRel rel in stp1)
                stp2.Add(new ProgramRepo().SelectProgramById(rel.ProgramId));
            return stp2;
        }

    }
}