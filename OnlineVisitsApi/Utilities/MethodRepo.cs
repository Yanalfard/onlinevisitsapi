using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace OnlineVisitsApi.Utilities
{
    public class MethodRepo
    {
        private static readonly string ConnectionString = Config.ConnectionString;

        public static bool ExistInDb(string tableName, string columnName, string columnValue)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT id FROM {tableName} WHERE {columnName} = '{columnValue}'", connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) return true;
            return false;
        }

        public static string ImageToBase64(System.Drawing.Image image)
        {
            using (MemoryStream memoryStreams = new MemoryStream())
            {
                image.Save(memoryStreams, image.RawFormat);
                byte[] imageBytes = memoryStreams.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static System.Drawing.Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream, true);
            return image;
        }

        public static DateTime C24To12(string t24)
        {
            string[] datetime = t24.Split(' ');
            string time = datetime[1];
            string[] timelaps = time.Split(':');
            int hour = Convert.ToInt32(timelaps[0]);
            int min = Convert.ToInt32(timelaps[1]);
            int sec = 0;
            if (timelaps.Length > 2)
                sec = Convert.ToInt32(timelaps[2]);
            if (hour > 12)
            {
                hour -= 12;
                return DateTime.Parse(datetime[0] + " " + hour + ":" + min + ":" + sec + " PM");
            }
            if (hour == 12 && (min > 0 || sec > 0))
                return DateTime.Parse(datetime[0] + " " + hour + ":" + min + ":" + sec + " PM");
            if (hour == 0 && min == 0 && sec == 0)
                return DateTime.Parse(t24.Split('.')[0] + " AM");
            return DateTime.Parse(datetime[0] + " " + datetime[1] + " AM");
        }

        public static string C12To24(DateTime t12)
        {
            string[] datetime = t12.ToString().Split(' ');
            string[] cdate = datetime[0].Split('/');
            string date = cdate[2] + '-' + cdate[0] + '-' + cdate[1];
            string[] time = datetime[1].Split(':');
            int hour = Convert.ToInt32(time[0]);
            int min = Convert.ToInt32(time[1]);
            int sec = Convert.ToInt32(time[2]);
            if (datetime[2] == "PM")
                hour += 12;
            if (hour == 24)
                hour = 0;
            return date + " " + hour + ":" + min + ":" + sec;
        }
    }
}
