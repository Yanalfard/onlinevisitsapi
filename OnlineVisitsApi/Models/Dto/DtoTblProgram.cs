using System.Net;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Models.Dto
{
    public class DtoTblProgram
    {
        public int id { get; set; }
        public int Day { get; set; }
        public int TimeStart1 { get; set; }
        public int TimeEnd1 { get; set; }
        public int TimeStart2 { get; set; }
        public int TimeEnd2 { get; set; }
        public int TimeStart3 { get; set; }
        public int TimeEnd3 { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblProgram ToRegular()
        {
            return new TblProgram(id, Day, TimeStart1, TimeEnd1, TimeStart2, TimeEnd2, TimeStart3, TimeEnd3);
        }

        public DtoTblProgram(TblProgram program, HttpStatusCode statusEffect)
        {
            id = program.id;
            Day = program.Day;
            TimeStart1 = program.TimeStart1;
            TimeEnd1 = program.TimeEnd1;
            TimeStart2 = program.TimeStart2;
            TimeEnd2 = program.TimeEnd2;
            TimeStart3 = program.TimeStart3;
            TimeEnd3 = program.TimeEnd3;

            StatusEffect = statusEffect;
        }

        public DtoTblProgram()
        {
        }
    }
}