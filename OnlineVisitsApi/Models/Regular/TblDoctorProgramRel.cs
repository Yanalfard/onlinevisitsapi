namespace OnlineVisitsApi.Models.Regular
{
    public class TblDoctorProgramRel
    {
        public int id { get; set; }
        public int DoctorId { get; set; }
        public int ProgramId { get; set; }

        public TblDoctorProgramRel(int id)
        {
            this.id = id;
        }

		public TblDoctorProgramRel(int id, int doctorId, int programId)
        {
            this.id = id;
            DoctorId = doctorId;
            ProgramId = programId;
        }
        public TblDoctorProgramRel(int doctorId, int programId)
        {
            DoctorId = doctorId;
            ProgramId = programId;
        }

        public TblDoctorProgramRel()
        {
            
        }
    }
}