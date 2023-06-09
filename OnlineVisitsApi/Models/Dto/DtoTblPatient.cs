using System.Net;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Models.Dto
{
    public class DtoTblPatient
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TellNo { get; set; }
        public string IdentificationNo { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblPatient ToRegular()
        {
            return new TblPatient(id, FirstName, LastName, TellNo, IdentificationNo, Province, City, Username, Password, Secret);
        }

        public DtoTblPatient(TblPatient patient, HttpStatusCode statusEffect)
        {
            id = patient.id;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            TellNo = patient.TellNo;
            IdentificationNo = patient.IdentificationNo;
            Province = patient.Province;
            City = patient.City;
            Username = patient.Username;
            Password = patient.Password;
            Secret = patient.Secret;

            StatusEffect = statusEffect;
        }

        public DtoTblPatient()
        {
        }
    }
}