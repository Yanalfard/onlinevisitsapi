using System.Net;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Models.Dto
{
    public class DtoTblDoctor
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TellNo { get; set; }
        public string IdentificationNo { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public long Cash { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }
        public string Section { get; set; }
        public string ReservedTill { get; set; }
        public long VisitFee { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblDoctor(TblDoctor doctor, HttpStatusCode statusEffect)
        {
            id = doctor.id;
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            TellNo = doctor.TellNo;
            IdentificationNo = doctor.IdentificationNo;
            Province = doctor.Province;
            City = doctor.City;
            Cash = doctor.Cash;
            Username = doctor.Username;
            Password = doctor.Password;
            Secret = doctor.Secret;
            Section = doctor.Section;
            ReservedTill = doctor.ReservedTill;
            VisitFee = doctor.VisitFee;

            StatusEffect = statusEffect;
        }

        public DtoTblDoctor()
        {
        }
    }
}