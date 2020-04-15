using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Services.Impl;

namespace OnlineVisitsApi.Controllers
{
    [RoutePrefix("api/PatientDoctorRelCore")]
    public class PatientDoctorRelController : ApiController
    {
        [Route("AddPatientDoctorRel")]
        [HttpPost]
        public IHttpActionResult AddPatientDoctorRel(TblPatientDoctorRel patientDoctorRel)
        {
            var task = Task.Run(() => new PatientDoctorRelService().AddPatientDoctorRel(patientDoctorRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPatientDoctorRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("DeletePatientDoctorRel")]
        [HttpPost]
        public IHttpActionResult DeletePatientDoctorRel(int id)
        {
            var task = Task.Run(() => new PatientDoctorRelService().DeletePatientDoctorRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("UpdatePatientDoctorRel")]
        [HttpPost]
        public IHttpActionResult UpdatePatientDoctorRel(List<object> patientDoctorRelLogId)
        {
            TblPatientDoctorRel patientDoctorRel = JsonConvert.DeserializeObject<TblPatientDoctorRel>(patientDoctorRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(patientDoctorRelLogId[1].ToString());
            var task = Task.Run(() => new PatientDoctorRelService().UpdatePatientDoctorRel(patientDoctorRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectAllPatientDoctorRels")]
        [HttpGet]
        public IHttpActionResult SelectAllPatientDoctorRels()
        {
            var task = Task.Run(() => new PatientDoctorRelService().SelectAllPatientDoctorRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientDoctorRel> dto = new List<DtoTblPatientDoctorRel>();
                    foreach (TblPatientDoctorRel obj in task.Result)
                        dto.Add(new DtoTblPatientDoctorRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectPatientDoctorRelById")]
        [HttpPost]
        public IHttpActionResult SelectPatientDoctorRelById(int id)
        {
            var task = Task.Run(() => new PatientDoctorRelService().SelectPatientDoctorRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatientDoctorRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectPatientDoctorRelByPatientId")]
        [HttpPost]
        public IHttpActionResult SelectPatientDoctorRelByPatientId(int patientId)
        {
            var task = Task.Run(() => new PatientDoctorRelService().SelectPatientDoctorRelByPatientId(patientId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientDoctorRel> dto = new List<DtoTblPatientDoctorRel>();
                    foreach (TblPatientDoctorRel obj in task.Result)
                        dto.Add(new DtoTblPatientDoctorRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectPatientDoctorRelByDoctorId")]
        [HttpPost]
        public IHttpActionResult SelectPatientDoctorRelByDoctorId(int doctorId)
        {
            var task = Task.Run(() => new PatientDoctorRelService().SelectPatientDoctorRelByDoctorId(doctorId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientDoctorRel> dto = new List<DtoTblPatientDoctorRel>();
                    foreach (TblPatientDoctorRel obj in task.Result)
                        dto.Add(new DtoTblPatientDoctorRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
