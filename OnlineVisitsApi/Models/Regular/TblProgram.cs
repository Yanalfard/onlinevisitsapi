namespace OnlineVisitsApi.Models.Regular
{
    public class TblProgram
    {
        public int id { get; set; }
        public int Day { get; set; }
        public int TimeStart1 { get; set; }
        public int TimeEnd1 { get; set; }
        public int TimeStart2 { get; set; }
        public int TimeEnd2 { get; set; }
        public int TimeStart3 { get; set; }
        public int TimeEnd3 { get; set; }

        public TblProgram(int id)
        {
            this.id = id;
        }

		public TblProgram(int id, int day, int timeStart1, int timeEnd1, int timeStart2, int timeEnd2, int timeStart3, int timeEnd3)
        {
            this.id = id;
            Day = day;
            TimeStart1 = timeStart1;
            TimeEnd1 = timeEnd1;
            TimeStart2 = timeStart2;
            TimeEnd2 = timeEnd2;
            TimeStart3 = timeStart3;
            TimeEnd3 = timeEnd3;
        }
        public TblProgram(int day, int timeStart1, int timeEnd1, int timeStart2, int timeEnd2, int timeStart3, int timeEnd3)
        {
            Day = day;
            TimeStart1 = timeStart1;
            TimeEnd1 = timeEnd1;
            TimeStart2 = timeStart2;
            TimeEnd2 = timeEnd2;
            TimeStart3 = timeStart3;
            TimeEnd3 = timeEnd3;
        }

        public TblProgram()
        {
            
        }
    }
}