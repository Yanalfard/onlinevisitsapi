using System.Net;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Models.Dto
{
    public class DtoTblPatientDoctorRel
    {
        public int id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Time { get; set; }
        public bool IsUp { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblPatientDoctorRel ToRegular()
        {
            return new TblPatientDoctorRel(id, PatientId, DoctorId, Time, IsUp);
        }

        public DtoTblPatientDoctorRel(TblPatientDoctorRel patientDoctorRel, HttpStatusCode statusEffect)
        {
            id = patientDoctorRel.id;
            PatientId = patientDoctorRel.PatientId;
            DoctorId = patientDoctorRel.DoctorId;
            Time = patientDoctorRel.Time;
            IsUp = patientDoctorRel.IsUp;

            StatusEffect = statusEffect;
        }

        public DtoTblPatientDoctorRel()
        {
        }
    }
}