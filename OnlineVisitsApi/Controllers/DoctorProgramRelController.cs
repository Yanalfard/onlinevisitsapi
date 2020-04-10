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
    [RoutePrefix("api/DoctorProgramRelCore")]
    public class DoctorProgramRelController : ApiController
    {
        [Route("AddDoctorProgramRel")]
        [HttpPost]
        public IHttpActionResult AddDoctorProgramRel(TblDoctorProgramRel doctorProgramRel)
        {
            var task = Task.Run(() => new DoctorProgramRelService().AddDoctorProgramRel(doctorProgramRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteDoctorProgramRel")]
        [HttpPost]
        public IHttpActionResult DeleteDoctorProgramRel(int id)
        {
            var task = Task.Run(() => new DoctorProgramRelService().DeleteDoctorProgramRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateDoctorProgramRel")]
        [HttpPost]
        public IHttpActionResult UpdateDoctorProgramRel(List<object> doctorProgramRelLogId)
        {
            TblDoctorProgramRel doctorProgramRel = JsonConvert.DeserializeObject<TblDoctorProgramRel>(doctorProgramRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(doctorProgramRelLogId[1].ToString());
            var task = Task.Run(() => new DoctorProgramRelService().UpdateDoctorProgramRel(doctorProgramRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllDoctorProgramRels")]
        [HttpGet]
        public IHttpActionResult SelectAllDoctorProgramRels()
        {
            var task = Task.Run(() => new DoctorProgramRelService().SelectAllDoctorProgramRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctorProgramRel> dto = new List<DtoTblDoctorProgramRel>();
                    foreach (TblDoctorProgramRel obj in task.Result)
                        dto.Add(new DtoTblDoctorProgramRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorProgramRelById")]
        [HttpPost]
        public IHttpActionResult SelectDoctorProgramRelById(int id)
        {
            var task = Task.Run(() => new DoctorProgramRelService().SelectDoctorProgramRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDoctorProgramRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorProgramRelsByDoctorId")]
        [HttpPost]
        public IHttpActionResult SelectDoctorProgramRelByDoctorId(int doctorId)
        {
            var task = Task.Run(() => new DoctorProgramRelService().SelectDoctorProgramRelByDoctorId(doctorId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctorProgramRel> dto = new List<DtoTblDoctorProgramRel>();
                    foreach (TblDoctorProgramRel obj in task.Result)
                        dto.Add(new DtoTblDoctorProgramRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorProgramRelsByProgramId")]
        [HttpPost]
        public IHttpActionResult SelectDoctorProgramRelByProgramId(int programId)
        {
            var task = Task.Run(() => new DoctorProgramRelService().SelectDoctorProgramRelByProgramId(programId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctorProgramRel> dto = new List<DtoTblDoctorProgramRel>();
                    foreach (TblDoctorProgramRel obj in task.Result)
                        dto.Add(new DtoTblDoctorProgramRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
