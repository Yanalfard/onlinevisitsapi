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
    [RoutePrefix("api/ProgramCore")]
    public class ProgramController : ApiController
    {
        [Route("AddProgram")]
        [HttpPost]
        public IHttpActionResult AddProgram(TblProgram program)
        {
            var task = Task.Run(() => new ProgramService().AddProgram(program));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProgram")]
        [HttpPost]
        public IHttpActionResult DeleteProgram(int id)
        {
            var task = Task.Run(() => new ProgramService().DeleteProgram(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProgram")]
        [HttpPost]
        public IHttpActionResult UpdateProgram(List<object> programLogId)
        {
            TblProgram program = JsonConvert.DeserializeObject<TblProgram>(programLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(programLogId[1].ToString());
            var task = Task.Run(() => new ProgramService().UpdateProgram(program, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPrograms")]
        [HttpGet]
        public IHttpActionResult SelectAllPrograms()
        {
            var task = Task.Run(() => new ProgramService().SelectAllPrograms());
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
        [Route("SelectProgramById")]
        [HttpPost]
        public IHttpActionResult SelectProgramById(int id)
        {
            var task = Task.Run(() => new ProgramService().SelectProgramById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProgram(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
