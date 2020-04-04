namespace OnlineVisitsApi.Models.Regular
{
    public class TblPatientDoctorRel
    {
        public int id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Time { get; set; }
        public bool IsUp { get; set; }

        public TblPatientDoctorRel(int id)
        {
            this.id = id;
        }

		public TblPatientDoctorRel(int id, int patientId, int doctorId, string time, bool isUp)
        {
            this.id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            Time = time;
            IsUp = isUp;
        }
        public TblPatientDoctorRel(int patientId, int doctorId, string time, bool isUp)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            Time = time;
            IsUp = isUp;
        }

        public TblPatientDoctorRel()
        {
            
        }
    }
}