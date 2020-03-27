using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.ApiDecoder
{
    public class DoctorCore : ApiController
    {
        private HttpClient _httpClient;

        public DoctorCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/DoctorCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");

        }
        /// <summary>
        /// Adds a doctor to OnlineVisits.TblDoctor
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> AddDoctor(TblDoctor doctor)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorCore/AddDoctor", doctor);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Deletes a doctor from OnlineVisits.TblDoctor using its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDoctor(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/DeleteDoctor?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a doctor at OnlineVisits.TblDoctor
        /// </summary>
        /// <param name="doctor">New doctor</param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>        public async Task<bool> UpdateDoctor(TblDoctor doctor, int logId)
        {
            List<object> doctorAndLogId = new List<object>();
            doctorAndLogId.Add(doctor);
            doctorAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorCore/UpdateDoctor", doctorAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all doctors from OnlineVisits.TblDoctor
        /// </summary>
        /// <returns></returns>        public async Task<List<DtoTblDoctor>> SelectAllDoctors()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/DoctorCore/SelectAllDoctors");
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctors from OnlineVisits.TblDoctor by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TblDoctor> SelectDoctorById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorById?id={id}", id);
            TblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<TblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> SelectDoctorByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByName?name={name}", name);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects doctors from OnlineVisits.TblDoctor by sectionId
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblDoctor>> SelectDoctorBySectionId(int sectionId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorBySectionId?sectionId={sectionId}", sectionId);
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        /// <summary>
        /// Selects doctors from OnlineVisits.TblDoctor by nowActive
        /// </summary>
        /// <param name="nowActive"></param>
        /// <returns></returns>
        public async Task<List<DtoTblDoctor>> SelectDoctorByNowActive(bool nowActive)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByNowActive?nowActive={nowActive}", nowActive);
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by firstName
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> SelectDoctorByFirstName(string firstName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByFirstName?firstName={firstName}", firstName);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by lastName
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> SelectDoctorByLastName(string lastName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByLastName?lastName={lastName}", lastName);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by tellNo
        /// </summary>
        /// <param name="tellNo"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> SelectDoctorByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByTellNo?tellNo={tellNo}", tellNo);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by identificationNo
        /// </summary>
        /// <param name="identificationNo"></param>
        /// <returns></returns>
        public async Task<List<DtoTblDoctor>> SelectDoctorByIdentificationNo(int identificationNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByIdentificationNo?identificationNo={identificationNo}", identificationNo);
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> SelectDoctorByUsernameAndPassword(string username, string password)
        {
            List<object> obj = new List<object>();
            obj.Add(username);
            obj.Add(password);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByUsernameAndPassword", obj);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> SelectDoctorByUsername(string username)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByUsername?username={username}", username);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblDoctor by password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<DtoTblDoctor> SelectDoctorByPassword(string password)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByPassword?password={password}", password);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        /// <summary>
        /// Selects a program from OnlineVisits.TblProgram by doctorId (NOTE: It uses relation table of TblDoctorProgramRel in between)
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProgram>> SelectProgramByDoctorId(int doctorId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProgramCore/SelectProgramByDoctorId?doctorId={doctorId}", doctorId);
            List<DtoTblProgram> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProgram>>();
            return ans;
        }

    }
}