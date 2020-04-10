using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Services.Impl;

namespace OnlineVisitsApi.Controllers
{
    [RoutePrefix("api/DoctorCore")]
    public class DoctorController : ApiController
    {
        [Route("AddDoctor")]
        [HttpPost]
        public IHttpActionResult AddDoctor(TblDoctor doctor)
        {
            var task = Task.Run(() => new DoctorService().AddDoctor(doctor));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteDoctor")]
        [HttpPost]
        public IHttpActionResult DeleteDoctor(int id)
        {
            var task = Task.Run(() => new DoctorService().DeleteDoctor(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateDoctor")]
        [HttpPost]
        public IHttpActionResult UpdateDoctor(List<object> doctorLogId)
        {
            TblDoctor doctor = JsonConvert.DeserializeObject<TblDoctor>(doctorLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(doctorLogId[1].ToString());
            var task = Task.Run(() => new DoctorService().UpdateDoctor(doctor, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllDoctors")]
        [HttpGet]
        public IHttpActionResult SelectAllDoctors()
        {
            var task = Task.Run(() => new DoctorService().SelectAllDoctors());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctor> dto = new List<DtoTblDoctor>();
                    foreach (TblDoctor obj in task.Result)
                        dto.Add(new DtoTblDoctor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorById")]
        [HttpPost]
        public IHttpActionResult SelectDoctorById(int id)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectDoctorByFirstName")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByFirstName(string firstName)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByFirstName(firstName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByLastName")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByLastName(string lastName)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByLastName(lastName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByTellNo(string tellNo)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByIdentificationNo")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByIdentificationNo(int identificationNo)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByIdentificationNo(identificationNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctor> dto = new List<DtoTblDoctor>();
                    foreach (TblDoctor obj in task.Result)
                        dto.Add(new DtoTblDoctor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByUsernameAndPassword")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByUsernameAndPassword(List<object> usernamePassword)
        {
            string username = JsonConvert.DeserializeObject<string>(usernamePassword[0].ToString());
            string password = JsonConvert.DeserializeObject<string>(usernamePassword[1].ToString());
            var task = Task.Run(() => new DoctorService().SelectDoctorByUsernameAndPassword(username, password));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByUsername")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByUsername(string username)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByUsername(username));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByPassword")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByPassword(string password)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByPassword(password));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        
        [Route("SelectDoctorBySection")]
        [HttpPost]
        public IHttpActionResult SelectDoctorBySection(string section)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorBySection(section));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                {
                    List<DtoTblDoctor> dto = new List<DtoTblDoctor>();
                    foreach (TblDoctor obj in task.Result)
                        dto.Add(new DtoTblDoctor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProgramByDoctorId")]
        [HttpPost]
        public IHttpActionResult SelectProgramByDoctorId(int doctorId)
        {
            var task = Task.Run(() => new DoctorService().SelectProgramsByDoctorId(doctorId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProgram> dto = new List<DtoTblProgram>();
                    foreach (TblProgram obj in task.Result)
                        dto.Add(new DtoTblProgram(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
