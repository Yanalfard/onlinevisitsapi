namespace OnlineVisitsApi.Models.Regular
{
    public class TblDoctor
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

        public TblDoctor(int id)
        {
            this.id = id;
        }

		public TblDoctor(int id, string firstName, string lastName, string tellNo, string identificationNo, string province, string city, long cash, string username, string password, string secret)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            TellNo = tellNo;
            IdentificationNo = identificationNo;
            Province = province;
            City = city;
            Cash = cash;
            Username = username;
            Password = password;
            Secret = secret;
        }
        public TblDoctor(string firstName, string lastName, string tellNo, string identificationNo, string province, string city, long cash, string username, string password, string secret)
        {
            FirstName = firstName;
            LastName = lastName;
            TellNo = tellNo;
            IdentificationNo = identificationNo;
            Province = province;
            City = city;
            Cash = cash;
            Username = username;
            Password = password;
            Secret = secret;
        }

        public TblDoctor()
        {
            
        }
    }
}