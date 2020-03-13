using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace OnlineVisitsApi.Utilities
{
    public class MethodRepo
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        private static SqlConnection _connection;
        private static SqlCommand _command;

        public MethodRepo()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        public static bool ExistInDb(string tableName, string columnName, string columnValue)
        {
            _command = new SqlCommand($"SELECT id FROM {tableName} WHERE {columnName} = '{columnValue}'", _connection);
            SqlDataReader reader = _command.ExecuteReader();
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
    }
}
