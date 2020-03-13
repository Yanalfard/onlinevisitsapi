using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Utilities
{
    public class MainProvider
    {
        private static readonly string ConnectionString =
            "Data Source=109.169.76.94;Initial Catalog=azarkand_OnlineVisits;User ID=azarkand_Yanal;Password=1710ahmad.fard";
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _commandText = "";

        public MainProvider()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        private void _disconnect()
        {
            _command.Dispose();
            _connection.Close();
        }

        public enum Tables
        {
            TblProgram,
            TblDoctorProgramRel,
            TblPatient,
            TblDoctor
        }

        public enum DoctorProgramRel
        {
            DoctorId,
            ProgramId
        }

        public object Add<T>(T table)
        {
            try
            {
                object tableObj = table;
                SqlCommand command;
                if (table.GetType() == typeof(TblProgram))
                {
                    TblProgram program = (TblProgram)tableObj;

                    _commandText = $"insert into TblProgram (Day , TimeStart1 , TimeEnd1 , TimeStart2 , TimeEnd2 , TimeStart3 , TimeEnd3) values ('{program.Day}' , '{program.TimeStart1}' , '{program.TimeEnd1}' , '{program.TimeStart2}' , '{program.TimeEnd2}' , '{program.TimeStart3}' , '{program.TimeEnd3}' )";
                    command = new SqlCommand($"select TOP (1) * from TblProgram where Day = '{program.Day}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblProgram(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Day"].ToString() != "" ? Convert.ToInt32(reader["Day"]) : 0, reader["TimeStart1"].ToString() != "" ? Convert.ToInt32(reader["TimeStart1"]) : 0, reader["TimeEnd1"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd1"]) : 0, reader["TimeStart2"].ToString() != "" ? Convert.ToInt32(reader["TimeStart2"]) : 0, reader["TimeEnd2"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd2"]) : 0, reader["TimeStart3"].ToString() != "" ? Convert.ToInt32(reader["TimeStart3"]) : 0, reader["TimeEnd3"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd3"]) : 0);
                }
                else if (table.GetType() == typeof(TblDoctorProgramRel))
                {
                    TblDoctorProgramRel doctorProgramRel = (TblDoctorProgramRel)tableObj;

                    _commandText = $"insert into TblDoctorProgramRel (DoctorId , ProgramId) values ('{doctorProgramRel.DoctorId}' , '{doctorProgramRel.ProgramId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblDoctorProgramRel where id = '{doctorProgramRel.id}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblDoctorProgramRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["ProgramId"].ToString() != "" ? Convert.ToInt32(reader["ProgramId"]) : 0);
                }
                else if (table.GetType() == typeof(TblPatient))
                {
                    TblPatient patient = (TblPatient)tableObj;
                    if (!MethodRepo.ExistInDb("TblPatient", "Username", patient.Username))
                    {
                        _commandText = $"insert into TblPatient (FirstName , LastName , TellNo , IdentificationNo , Province , City , Username , Password , Secret , ReserveTime , ReserveTime2) values ('{patient.FirstName}' , '{patient.LastName}' , '{patient.TellNo}' , '{patient.IdentificationNo}' , '{patient.Province}' , '{patient.City}' , '{patient.Username}' , '{patient.Password}' , '{patient.Secret}' , '{patient.ReserveTime}' , '{patient.ReserveTime2}' )";
                        command = new SqlCommand($"select TOP (1) * from TblPatient where Username = '{patient.Username}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
                    }
                    else return false;
                }
                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    if (!MethodRepo.ExistInDb("TblDoctor", "Username", doctor.Username))
                    {
                        _commandText = $"insert into TblDoctor (FirstName , LastName , TellNo , IdentificationNo , Province , City , Cash , Username , Password , Secret , Section , ReservedTill , VisitFee) values ('{doctor.FirstName}' , '{doctor.LastName}' , '{doctor.TellNo}' , '{doctor.IdentificationNo}' , '{doctor.Province}' , '{doctor.City}' , '{doctor.Cash}' , '{doctor.Username}' , '{doctor.Password}' , '{doctor.Secret}' , '{doctor.Section}' , '{doctor.ReservedTill}' , '{doctor.VisitFee}' )";
                        command = new SqlCommand($"select TOP (1) * from TblDoctor where Username = '{doctor.Username}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
                    }
                    else return false;
                }
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public bool Update<T>(T table, int logId)
        {
            try
            {
                object tableObj = table;
                if (table.GetType() == typeof(TblProgram))
                {
                    TblProgram program = (TblProgram)tableObj;
                    _commandText = $"update TblProgram set Day = '{program.Day}' , TimeStart1 = '{program.TimeStart1}' , TimeEnd1 = '{program.TimeEnd1}' , TimeStart2 = '{program.TimeStart2}' , TimeEnd2 = '{program.TimeEnd2}' , TimeStart3 = '{program.TimeStart3}' , TimeEnd3 = '{program.TimeEnd3}' where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblDoctorProgramRel))
                {
                    TblDoctorProgramRel doctorProgramRel = (TblDoctorProgramRel)tableObj;
                    _commandText = $"update TblDoctorProgramRel set DoctorId = '{doctorProgramRel.DoctorId}' , ProgramId = '{doctorProgramRel.ProgramId}' where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblPatient))
                {
                    TblPatient patient = (TblPatient)tableObj;
                    _commandText = $"update TblPatient set FirstName = '{patient.FirstName}' , LastName = '{patient.LastName}' , TellNo = '{patient.TellNo}' , IdentificationNo = '{patient.IdentificationNo}' , Province = '{patient.Province}' , City = '{patient.City}' , Username = '{patient.Username}' , Password = '{patient.Password}' , Secret = '{patient.Secret}' , ReserveTime = '{patient.ReserveTime}' , ReserveTime2 = '{patient.ReserveTime2}' where id = '{logId}'";
                }
                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    _commandText = $"update TblDoctor set FirstName = '{doctor.FirstName}' , LastName = '{doctor.LastName}' , TellNo = '{doctor.TellNo}' , IdentificationNo = '{doctor.IdentificationNo}' , Province = '{doctor.Province}' , City = '{doctor.City}' , Cash = '{doctor.Cash}' , Username = '{doctor.Username}' , Password = '{doctor.Password}' , Secret = '{doctor.Secret}' , Section = '{doctor.Section}' , ReservedTill = '{doctor.ReservedTill}' , VisitFee = '{doctor.VisitFee}' where id = '{logId}'";
                }
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public bool Delete(Tables tableType, int id)
        {
            try
            {
                _commandText = $"delete from {tableType.ToString()} where id = N'{id}'";
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public IEnumerable SelectAll(Tables tableType)
        {
            try
            {
                _commandText = $"select * from {tableType.ToString()}";
                _command = new SqlCommand(_commandText, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                switch (tableType)
                {
                    case Tables.TblProgram:
                        List<TblProgram> programs = new List<TblProgram>();
                        while (reader.Read())
                            programs.Add(new TblProgram(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Day"].ToString() != "" ? Convert.ToInt32(reader["Day"]) : 0, reader["TimeStart1"].ToString() != "" ? Convert.ToInt32(reader["TimeStart1"]) : 0, reader["TimeEnd1"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd1"]) : 0, reader["TimeStart2"].ToString() != "" ? Convert.ToInt32(reader["TimeStart2"]) : 0, reader["TimeEnd2"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd2"]) : 0, reader["TimeStart3"].ToString() != "" ? Convert.ToInt32(reader["TimeStart3"]) : 0, reader["TimeEnd3"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd3"]) : 0));
                        return programs;
                    case Tables.TblDoctorProgramRel:
                        List<TblDoctorProgramRel> doctorProgramRels = new List<TblDoctorProgramRel>();
                        while (reader.Read())
                            doctorProgramRels.Add(new TblDoctorProgramRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["ProgramId"].ToString() != "" ? Convert.ToInt32(reader["ProgramId"]) : 0));
                        return doctorProgramRels;
                    case Tables.TblPatient:
                        List<TblPatient> patients = new List<TblPatient>();
                        while (reader.Read())
                            patients.Add(new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString()));
                        return patients;
                    case Tables.TblDoctor:
                        List<TblDoctor> doctors = new List<TblDoctor>();
                        while (reader.Read())
                            doctors.Add(new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0));
                        return doctors;
                    default:
                        return new List<bool>();
                }
            }
            catch
            {
                return new List<bool>();
            }
            finally
            {
                _disconnect();
            }
        }

        public object SelectById(Tables table, int id)
        {
            try
            {
                _command = new SqlCommand($"select * from {table.ToString()} where id = '{id}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                if (table == Tables.TblProgram)
                    return new TblProgram(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Day"].ToString() != "" ? Convert.ToInt32(reader["Day"]) : 0, reader["TimeStart1"].ToString() != "" ? Convert.ToInt32(reader["TimeStart1"]) : 0, reader["TimeEnd1"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd1"]) : 0, reader["TimeStart2"].ToString() != "" ? Convert.ToInt32(reader["TimeStart2"]) : 0, reader["TimeEnd2"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd2"]) : 0, reader["TimeStart3"].ToString() != "" ? Convert.ToInt32(reader["TimeStart3"]) : 0, reader["TimeEnd3"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd3"]) : 0);
                else if (table == Tables.TblDoctorProgramRel)
                    return new TblDoctorProgramRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["ProgramId"].ToString() != "" ? Convert.ToInt32(reader["ProgramId"]) : 0);
                else if (table == Tables.TblPatient)
                    return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
                else if (table == Tables.TblDoctor)
                    return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                _disconnect();
            }
        }

        #region TblProgram

        #endregion


        #region TblDoctorProgramRel

        public List<TblDoctorProgramRel> SelectDoctorProgramRel(int entry, DoctorProgramRel entryType)
        {
            try
            {
                List<TblDoctorProgramRel> ret = new List<TblDoctorProgramRel>();
                if (entryType == DoctorProgramRel.DoctorId)
                    _command = new SqlCommand($"select* from TblDoctorProgramRel where DoctorId = N'{entry}'", _connection);
                else if (entryType == DoctorProgramRel.ProgramId)
                    _command = new SqlCommand($"select* from TblDoctorProgramRel where ProgramId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblDoctorProgramRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["ProgramId"].ToString() != "" ? Convert.ToInt32(reader["ProgramId"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblDoctorProgramRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion


        #region TblPatient

        public TblPatient SelectPatientByFirstName(string firstName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where FirstName = N'{firstName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblPatient SelectPatientByLastName(string lastName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where LastName = N'{lastName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblPatient SelectPatientByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblPatient> SelectPatientByIdentificationNo(int identificationNo)
        {
            try
            {
                List<TblPatient> ret = new List<TblPatient>();
                _command = new SqlCommand($"select* from TblPatient where IdentificationNo = N'{identificationNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString()));
                return ret;
            }
            catch
            {
                return new List<TblPatient>();
            }
            finally
            {
                _disconnect();
            }
        }
        public TblPatient SelectPatientByUsername(string username)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where Username = N'{username}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblPatient SelectPatientByUsernameAndPassword(string username, string password)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where Username = N'{username} and Password = N'{password}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblPatient SelectPatientByPassword(string password)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPatient where Password = N'{password}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["ReserveTime"].ToString(), reader["ReserveTime2"].ToString());
            }
            catch
            {
                return new TblPatient(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion


        #region TblDoctor

        public TblDoctor SelectDoctorByFirstName(string firstName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where FirstName = N'{firstName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblDoctor SelectDoctorByLastName(string lastName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where LastName = N'{lastName}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblDoctor SelectDoctorByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblDoctor> SelectDoctorByIdentificationNo(int identificationNo)
        {
            try
            {
                List<TblDoctor> ret = new List<TblDoctor>();
                _command = new SqlCommand($"select* from TblDoctor where IdentificationNo = N'{identificationNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0));
                return ret;
            }
            catch
            {
                return new List<TblDoctor>();
            }
            finally
            {
                _disconnect();
            }
        }
        public TblDoctor SelectDoctorByUsername(string username)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where Username = N'{username}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblDoctor SelectDoctorByUsernameAndPassword(string username, string password)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where Username = N'{username} and Password = N'{password}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public TblDoctor SelectDoctorByPassword(string password)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where Password = N'{password}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        #endregion


    }
}
