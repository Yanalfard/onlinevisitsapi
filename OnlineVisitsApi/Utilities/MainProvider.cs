using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Utilities
{
    public class MainProvider
    {
        private static readonly string ConnectionString = Config.ConnectionString;
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
            TblDoctor,
            TblPatientDoctorRel
        }

        public enum DoctorProgramRel
        {
            DoctorId,
            ProgramId
        }

        public enum PatientDoctorRel
        {
            PatientId,
            DoctorId,
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

                    _commandText = $"insert into TblProgram (Day , TimeStart1 , TimeEnd1 , TimeStart2 , TimeEnd2 , TimeStart3 , TimeEnd3) values (N'{program.Day}' , N'{program.TimeStart1}' , N'{program.TimeEnd1}' , N'{program.TimeStart2}' , N'{program.TimeEnd2}' , N'{program.TimeStart3}' , N'{program.TimeEnd3}' )";
                    command = new SqlCommand($"select TOP (1) * from TblProgram where Day = N'{program.Day}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblProgram(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Day"].ToString() != "" ? Convert.ToInt32(reader["Day"]) : 0, reader["TimeStart1"].ToString() != "" ? Convert.ToInt32(reader["TimeStart1"]) : 0, reader["TimeEnd1"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd1"]) : 0, reader["TimeStart2"].ToString() != "" ? Convert.ToInt32(reader["TimeStart2"]) : 0, reader["TimeEnd2"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd2"]) : 0, reader["TimeStart3"].ToString() != "" ? Convert.ToInt32(reader["TimeStart3"]) : 0, reader["TimeEnd3"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd3"]) : 0);
                }
                else if (table.GetType() == typeof(TblDoctorProgramRel))
                {
                    TblDoctorProgramRel doctorProgramRel = (TblDoctorProgramRel)tableObj;
                    _commandText = $"insert into TblDoctorProgramRel (DoctorId , ProgramId) values (N'{doctorProgramRel.DoctorId}' , N'{doctorProgramRel.ProgramId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblDoctorProgramRel where id = N'{doctorProgramRel.id}' ORDER BY id DESC", _connection);
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
                        _commandText = $"insert into TblPatient (FirstName , LastName , TellNo , IdentificationNo , Province , City , Username , Password , Secret) values (N'{patient.FirstName}' , N'{patient.LastName}' , N'{patient.TellNo}' , N'{patient.IdentificationNo}' , N'{patient.Province}' , N'{patient.City}' , N'{patient.Username}' , N'{patient.Password}' , N'{patient.Secret}' )";
                        command = new SqlCommand($"select TOP (1) * from TblPatient where Username = N'{patient.Username}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
                    }
                    else return new TblPatient(-1);
                }

                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    if (!MethodRepo.ExistInDb("TblDoctor", "Username", doctor.Username))
                    {
                        _commandText = $"insert into TblDoctor (FirstName , LastName , TellNo , IdentificationNo , Province , City , Cash , Username , Password , Secret , Section , ReservedTill , VisitFee) values (N'{doctor.FirstName}' , N'{doctor.LastName}' , N'{doctor.TellNo}' , N'{doctor.IdentificationNo}' , N'{doctor.Province}' , N'{doctor.City}' , N'{doctor.Cash}' , N'{doctor.Username}' , N'{doctor.Password}' , N'{doctor.Secret}' , N'{doctor.Section}' , N'{doctor.ReservedTill}' , N'{doctor.VisitFee}' )";
                        command = new SqlCommand($"select TOP (1) * from TblDoctor where Username = N'{doctor.Username}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
                    }
                    else return new TblDoctor(-1);
                }
                else if (table.GetType() == typeof(TblPatientDoctorRel))
                {
                    TblPatientDoctorRel patientDoctorRel = (TblPatientDoctorRel)tableObj;

                    _commandText = $"insert into TblPatientDoctorRel (PatientId , DoctorId , Time , IsUp) values (N'{patientDoctorRel.PatientId}' , N'{patientDoctorRel.DoctorId}' , N'{patientDoctorRel.Time}' , N'{patientDoctorRel.IsUp}' )";
                    command = new SqlCommand($"select TOP (1) * from TblPatientDoctorRel where DoctorId = N'{patientDoctorRel.DoctorId}' AND PatientId = '{patientDoctorRel.PatientId}' AND Time = '{patientDoctorRel.Time}' AND IsUp = '{patientDoctorRel.IsUp}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblPatientDoctorRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PatientId"].ToString() != "" ? Convert.ToInt32(reader["PatientId"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["Time"].ToString(), reader["IsUp"].ToString() != "" ? Convert.ToBoolean(reader["IsUp"]) : false);
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
                    _commandText = $"update TblProgram set Day = N'{program.Day}' , TimeStart1 = N'{program.TimeStart1}' , TimeEnd1 = N'{program.TimeEnd1}' , TimeStart2 = N'{program.TimeStart2}' , TimeEnd2 = N'{program.TimeEnd2}' , TimeStart3 = N'{program.TimeStart3}' , TimeEnd3 = N'{program.TimeEnd3}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblDoctorProgramRel))
                {
                    TblDoctorProgramRel doctorProgramRel = (TblDoctorProgramRel)tableObj;
                    _commandText = $"update TblDoctorProgramRel set DoctorId = N'{doctorProgramRel.DoctorId}' , ProgramId = N'{doctorProgramRel.ProgramId}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblPatient))
                {
                    TblPatient patient = (TblPatient)tableObj;
                    _commandText = $"update TblPatient set FirstName = N'{patient.FirstName}' , LastName = N'{patient.LastName}' , TellNo = N'{patient.TellNo}' , IdentificationNo = N'{patient.IdentificationNo}' , Province = N'{patient.Province}' , City = N'{patient.City}' , Username = N'{patient.Username}' , Password = N'{patient.Password}' , Secret = N'{patient.Secret}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    _commandText = $"update TblDoctor set FirstName = N'{doctor.FirstName}' , LastName = N'{doctor.LastName}' , TellNo = N'{doctor.TellNo}' , IdentificationNo = N'{doctor.IdentificationNo}' , Province = N'{doctor.Province}' , City = N'{doctor.City}' , Cash = N'{doctor.Cash}' , Username = N'{doctor.Username}' , Password = N'{doctor.Password}' , Secret = N'{doctor.Secret}' , Section = N'{doctor.Section}' , ReservedTill = N'{doctor.ReservedTill}' , VisitFee = N'{doctor.VisitFee}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblPatientDoctorRel))
                {
                    TblPatientDoctorRel patientDoctorRel = (TblPatientDoctorRel)tableObj;
                    _commandText = $"update TblPatientDoctorRel set PatientId = N'{patientDoctorRel.PatientId}' , DoctorId = N'{patientDoctorRel.DoctorId}' , Time = N'{patientDoctorRel.Time}' , IsUp = N'{patientDoctorRel.IsUp}' where id = N'{logId}'";
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
                            patients.Add(new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString()));
                        return patients;

                    case Tables.TblDoctor:
                        List<TblDoctor> doctors = new List<TblDoctor>();
                        while (reader.Read())
                            doctors.Add(new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0));
                        return doctors;

                    case Tables.TblPatientDoctorRel:
                        List<TblPatientDoctorRel> patientDoctorRels = new List<TblPatientDoctorRel>();
                        while (reader.Read())
                            patientDoctorRels.Add(new TblPatientDoctorRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PatientId"].ToString() != "" ? Convert.ToInt32(reader["PatientId"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["Time"].ToString(), reader["IsUp"].ToString() != "" ? Convert.ToBoolean(reader["IsUp"]) : false));
                        return patientDoctorRels;
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
                _command = new SqlCommand($"select * from {table.ToString()} where id = N'{id}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                if (table == Tables.TblProgram)
                    return new TblProgram(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Day"].ToString() != "" ? Convert.ToInt32(reader["Day"]) : 0, reader["TimeStart1"].ToString() != "" ? Convert.ToInt32(reader["TimeStart1"]) : 0, reader["TimeEnd1"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd1"]) : 0, reader["TimeStart2"].ToString() != "" ? Convert.ToInt32(reader["TimeStart2"]) : 0, reader["TimeEnd2"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd2"]) : 0, reader["TimeStart3"].ToString() != "" ? Convert.ToInt32(reader["TimeStart3"]) : 0, reader["TimeEnd3"].ToString() != "" ? Convert.ToInt32(reader["TimeEnd3"]) : 0);
                else if (table == Tables.TblDoctorProgramRel)
                    return new TblDoctorProgramRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["ProgramId"].ToString() != "" ? Convert.ToInt32(reader["ProgramId"]) : 0);
                else if (table == Tables.TblPatient)
                    return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
                else if (table == Tables.TblDoctor)
                    return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0, reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString(), reader["Section"].ToString(), reader["ReservedTill"].ToString(), reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
                else if (table == Tables.TblPatientDoctorRel)
                    return new TblPatientDoctorRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PatientId"].ToString() != "" ? Convert.ToInt32(reader["PatientId"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["Time"].ToString(), reader["IsUp"].ToString() != "" && Convert.ToBoolean(reader["IsUp"]));

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
                reader.Read();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
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
                reader.Read();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
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
                reader.Read();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
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
                    ret.Add(new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString()));
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
                reader.Read();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
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
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
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
                reader.Read();
                return new TblPatient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(), reader["Province"].ToString(), reader["City"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Secret"].ToString());
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

        public string ReserveStage1(int doctorId)
        {
            try
            {
                _command = new SqlCommand($"SELECT * FROM dbo.TblDoctor WHERE id = {doctorId}", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                TblDoctor doctor = new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0,
                    reader["FirstName"].ToString(), reader["LastName"].ToString(),
                    reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(),
                    reader["Province"].ToString(), reader["City"].ToString(),
                    reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0,
                    reader["Username"].ToString(), reader["Password"].ToString(),
                    reader["Secret"].ToString(), reader["Section"].ToString(),
                    reader["ReservedTill"].ToString(),
                    reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
                reader.Close();
                reader.Dispose();
                SqlCommand command2 = new SqlCommand($"SELECT * FROM dbo.TblProgram WHERE id IN (SELECT ProgramId FROM dbo.TblDoctorProgramRel WHERE DoctorId = {doctor.id})", _connection);
                SqlDataReader reader2 = command2.ExecuteReader();
                List<TblProgram> programs = new List<TblProgram>();
                while (reader2.Read())
                    programs.Add(new TblProgram(reader2["id"].ToString() != "" ? Convert.ToInt32(reader2["id"]) : 0,
                        reader2["Day"].ToString() != "" ? Convert.ToInt32(reader2["Day"]) : 0,
                        reader2["TimeStart1"].ToString() != "" ? Convert.ToInt32(reader2["TimeStart1"]) : 0,
                        reader2["TimeEnd1"].ToString() != "" ? Convert.ToInt32(reader2["TimeEnd1"]) : 0,
                        reader2["TimeStart2"].ToString() != "" ? Convert.ToInt32(reader2["TimeStart2"]) : 0,
                        reader2["TimeEnd2"].ToString() != "" ? Convert.ToInt32(reader2["TimeEnd2"]) : 0,
                        reader2["TimeStart3"].ToString() != "" ? Convert.ToInt32(reader2["TimeStart3"]) : 0,
                        reader2["TimeEnd3"].ToString() != "" ? Convert.ToInt32(reader2["TimeEnd3"]) : 0));
                reader2.Close();
                reader2.Dispose();
                int dayNo = 0;
                switch (DateTime.Today.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        dayNo = 0;
                        break;
                    case DayOfWeek.Sunday:
                        dayNo = 1;
                        break;
                    case DayOfWeek.Monday:
                        dayNo = 2;
                        break;
                    case DayOfWeek.Tuesday:
                        dayNo = 3;
                        break;
                    case DayOfWeek.Wednesday:
                        dayNo = 4;
                        break;
                    case DayOfWeek.Thursday:
                        dayNo = 5;
                        break;
                    case DayOfWeek.Friday:
                        dayNo = 6;
                        break;
                }

                bool isReserved = false;
                DateTime reserveTime = MethodRepo.C24To12(doctor.ReservedTill);
                int reservedHour = reserveTime.Hour;
                for (int i = dayNo; i < 7; i++)
                {
                    TblProgram nowProgram;
                    try
                    {
                        nowProgram = programs.Single(j => j.Day == i);
                    }
                    catch (InvalidOperationException)
                    {
                        nowProgram = null;
                    }
                    if (nowProgram != null)
                    {
                        if (reservedHour >= nowProgram.TimeStart1 && reservedHour < nowProgram.TimeEnd1)
                            isReserved = true;
                        else if (reservedHour >= nowProgram.TimeStart2 && reservedHour < nowProgram.TimeEnd2)
                            isReserved = true;
                        else if (reservedHour >= nowProgram.TimeStart3 && reservedHour < nowProgram.TimeEnd3)
                            isReserved = true;

                        if (isReserved)
                            return reserveTime.AddMinutes(20).ToString();      //---- JUB DONE
                    }
                }

                return "";

            }
            catch
            {
                return "";
            }
            finally
            {
                _disconnect();
            }
        }

        public bool ReserveStage2(int doctorId, int patientId, string stageOnesTime)
        {
            try
            {
                _command = new SqlCommand($"SELECT * FROM dbo.TblDoctor WHERE id = {doctorId}", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                TblDoctor doctor = new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0,
                    reader["FirstName"].ToString(), reader["LastName"].ToString(),
                    reader["TellNo"].ToString(), reader["IdentificationNo"].ToString(),
                    reader["Province"].ToString(), reader["City"].ToString(),
                    reader["Cash"].ToString() != "" ? long.Parse(reader["Cash"].ToString()) : 0,
                    reader["Username"].ToString(), reader["Password"].ToString(),
                    reader["Secret"].ToString(), reader["Section"].ToString(),
                    reader["ReservedTill"].ToString(),
                    reader["VisitFee"].ToString() != "" ? long.Parse(reader["VisitFee"].ToString()) : 0);
                reader.Close();
                bool isUpdated = Update(
                      new TblDoctor(doctor.id, doctor.FirstName, doctor.LastName, doctor.TellNo,
                          doctor.IdentificationNo, doctor.Province, doctor.City, doctor.Cash, doctor.Username,
                          doctor.Password, doctor.Secret, doctor.Section, stageOnesTime,
                          doctor.VisitFee), doctorId);
                if (isUpdated)
                {
                    _connection.Open();
                    object obj = Add(new TblPatientDoctorRel(patientId, doctorId, stageOnesTime, true));
                    if (obj is bool)
                        return false;
                    if (obj is TblPatientDoctorRel)
                        if (((TblPatientDoctorRel)obj).id != -1)
                            return true;
                        else
                            return false;
                }
                return isUpdated;      //---- JUB DONE
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
        #endregion

        #region TblDoctor

        public TblDoctor SelectDoctorByFirstName(string firstName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where FirstName = N'{firstName}'", _connection);
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
        public TblDoctor SelectDoctorByLastName(string lastName)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where LastName = N'{lastName}'", _connection);
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
        public TblDoctor SelectDoctorByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where TellNo = N'{tellNo}'", _connection);
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

        public List<TblDoctor> SelectDoctorBySection(string section)
        {
            try
            {
                List<TblDoctor> ret = new List<TblDoctor>();
                _command = new SqlCommand($"select* from TblDoctor where Section = N'{section}'", _connection);
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
        #endregion

        #region TblPatientDoctorRel

        public List<TblPatientDoctorRel> SelectPatientDoctorRel(int entry, PatientDoctorRel entryType)
        {
            try
            {
                List<TblPatientDoctorRel> ret = new List<TblPatientDoctorRel>();
                if (entryType == PatientDoctorRel.PatientId)
                    _command = new SqlCommand($"select* from TblPatientDoctorRel where PatientId = N'{entry}'", _connection);
                else if (entryType == PatientDoctorRel.DoctorId)
                    _command = new SqlCommand($"select* from TblPatientDoctorRel where DoctorId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPatientDoctorRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PatientId"].ToString() != "" ? Convert.ToInt32(reader["PatientId"]) : 0, reader["DoctorId"].ToString() != "" ? Convert.ToInt32(reader["DoctorId"]) : 0, reader["Time"].ToString(), reader["IsUp"].ToString() != "" ? Convert.ToBoolean(reader["IsUp"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblPatientDoctorRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion


    }
}
