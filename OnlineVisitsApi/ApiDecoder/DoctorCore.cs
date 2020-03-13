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
        public async Task<TblDoctor> AddDoctor(TblDoctor doctor)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorCore/AddDoctor", doctor);
            TblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<TblDoctor>();
            return ans;
        }
        public async Task<bool> DeleteDoctor(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/DeleteDoctor?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<bool> UpdateDoctor(TblDoctor doctor, int logId)
        {
            List<object> doctorAndLogId = new List<object>();
            doctorAndLogId.Add(doctor);
            doctorAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorCore/UpdateDoctor", doctorAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<List<DtoTblDoctor>> SelectAllDoctors()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/DoctorCore/SelectAllDoctors");
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        public async Task<TblDoctor> SelectDoctorById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorById?id={id}", id);
            TblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<TblDoctor>();
            return ans;
        }
        public async Task<DtoTblDoctor> SelectDoctorByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByName?name={name}", name);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        public async Task<List<DtoTblDoctor>> SelectDoctorBySectionId(int sectionId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorBySectionId?sectionId={sectionId}", sectionId);
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        public async Task<List<DtoTblDoctor>> SelectDoctorByNowActive(bool nowActive)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByNowActive?nowActive={nowActive}", nowActive);
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        public async Task<DtoTblDoctor> SelectDoctorByFirstName(string firstName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByFirstName?firstName={firstName}", firstName);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        public async Task<DtoTblDoctor> SelectDoctorByLastName(string lastName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByLastName?lastName={lastName}", lastName);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        public async Task<DtoTblDoctor> SelectDoctorByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByTellNo?tellNo={tellNo}", tellNo);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        public async Task<List<DtoTblDoctor>> SelectDoctorByIdentificationNo(int identificationNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByIdentificationNo?identificationNo={identificationNo}", identificationNo);
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }
        public async Task<DtoTblDoctor> SelectDoctorByUsernameAndPassword(string username ,string password)
        {
            List<object> obj = new List<object>();
            obj.Add(username);
            obj.Add(password);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByUsernameAndPassword", obj);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        public async Task<DtoTblDoctor> SelectDoctorByUsername(string username)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByUsername?username={username}", username);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        public async Task<DtoTblDoctor> SelectDoctorByPassword(string password)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByPassword?password={password}", password);
            DtoTblDoctor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctor>();
            return ans;
        }
        public async Task<List<DtoTblProgram>> SelectProgramByDoctorId(int doctorId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProgramCore/SelectProgramByDoctorId?doctorId={doctorId}", doctorId);
            List<DtoTblProgram> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProgram>>();
            return ans;
        }

    }
}