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

        public TblPatient(int id)
        {
            this.id = id;
        }

		public TblPatient(int id, string firstName, string lastName, string tellNo, string identificationNo, string province, string city, string username, string password, string secret)
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
        }
        public TblPatient(string firstName, string lastName, string tellNo, string identificationNo, string province, string city, string username, string password, string secret)
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
        }

        public TblPatient()
        {
            
        }
    }
}