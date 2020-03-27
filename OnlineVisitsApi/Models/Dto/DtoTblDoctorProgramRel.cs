using System.Net;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Models.Dto
{
    public class DtoTblDoctorProgramRel
    {
        public int id { get; set; }
        public int DoctorId { get; set; }
        public int ProgramId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblDoctorProgramRel ToRegular()
        {
            return new TblDoctorProgramRel(id, DoctorId, ProgramId);
        }

        public DtoTblDoctorProgramRel(TblDoctorProgramRel doctorProgramRel, HttpStatusCode statusEffect)
        {
            id = doctorProgramRel.id;
            DoctorId = doctorProgramRel.DoctorId;
            ProgramId = doctorProgramRel.ProgramId;

            StatusEffect = statusEffect;
        }

        public DtoTblDoctorProgramRel()
        {
        }
    }
}