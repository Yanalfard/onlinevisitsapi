namespace OnlineVisitsApi.Models.Regular
{
    public class TblPatient
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
        public string ReserveTime { get; set; }
        public string ReserveTime2 { get; set; }

        public TblPatient(int id)
        {
            this.id = id;
        }

		public TblPatient(int id, string firstName, string lastName, string tellNo, string identificationNo, string province, string city, string username, string password, string secret, string reserveTime, string reserveTime2)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            TellNo = tellNo;
            IdentificationNo = identificationNo;
            Province = province;
            City = city;
            Username = username;
            Password = password;
            Secret = secret;
            ReserveTime = reserveTime;
            ReserveTime2 = reserveTime2;
        }
        public TblPatient(string firstName, string lastName, string tellNo, string identificationNo, string province, string city, string username, string password, string secret, string reserveTime, string reserveTime2)
        {
            FirstName = firstName;
            LastName = lastName;
            TellNo = tellNo;
            IdentificationNo = identificationNo;
            Province = province;
            City = city;
            Username = username;
            Password = password;
            Secret = secret;
            ReserveTime = reserveTime;
            ReserveTime2 = reserveTime2;
        }

        public TblPatient()
        {
            
        }
    }
}