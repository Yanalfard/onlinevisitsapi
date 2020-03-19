using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Services.Impl;

namespace OnlineVisitsApi.Controllers
{
    [RoutePrefix("api/PatientCore")]
    public class PatientController : ApiController
    {
        [Route("AddPatient")]
        [HttpPost]
        public IHttpActionResult AddPatient(TblPatient patient)
        {
            var task = Task.Run(() => new PatientService().AddPatient(patient));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePatient")]
        [HttpPost]
        public IHttpActionResult DeletePatient(int id)
        {
            var task = Task.Run(() => new PatientService().DeletePatient(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePatient")]
        [HttpPost]
        public IHttpActionResult UpdatePatient(List<object> patientLogId)
        {
            TblPatient patient = JsonConvert.DeserializeObject<TblPatient>(patientLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(patientLogId[1].ToString());
            var task = Task.Run(() => new PatientService().UpdatePatient(patient, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPatients")]
        [HttpGet]
        public IHttpActionResult SelectAllPatients()
        {
            var task = Task.Run(() => new PatientService().SelectAllPatients());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientById")]
        [HttpPost]
        public IHttpActionResult SelectPatientById(int id)
        {
            var task = Task.Run(() => new PatientService().SelectPatientById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectPatientByTellNo(string tellNo)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectPatientByFirstName")]
        [HttpPost]
        public IHttpActionResult SelectPatientByFirstName(string firstName)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByFirstName(firstName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByLastName")]
        [HttpPost]
        public IHttpActionResult SelectPatientByLastName(string lastName)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByLastName(lastName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByIdentificationNo")]
        [HttpPost]
        public IHttpActionResult SelectPatientByIdentificationNo(int identificationNo)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByIdentificationNo(identificationNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByUsernameAndPassword")]
        [HttpPost]
        public IHttpActionResult SelectPatientByUsernameAndPassword(List<object> usernamePassword)
        {
            string username = JsonConvert.DeserializeObject<string>(usernamePassword[0].ToString());
            string password = JsonConvert.DeserializeObject<string>(usernamePassword[1].ToString());
            var task = Task.Run(() => new PatientService().SelectPatientByUsernameAndPassword(username, password));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByUsername")]
        [HttpPost]
        public IHttpActionResult SelectPatientByUsername(string username)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByUsername(username));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByPassword")]
        [HttpPost]
        public IHttpActionResult SelectPatientByPassword(string password)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByPassword(password));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("Reserve")]
        [HttpPost]
        public IHttpActionResult Reserve(int doctorId)
        {
            var task = Task.Run(() => new PatientService().Reserve(doctorId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
    }
}
