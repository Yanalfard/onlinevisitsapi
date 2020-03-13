using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.ApiDecoder
{
    public class PatientCore : ApiController
    {
        private HttpClient _httpClient;

        public PatientCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/PatientCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");

        }
        public async Task<TblPatient> AddPatient(TblPatient patient)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PatientCore/AddPatient", patient);
            TblPatient ans = await httpResponseMessage.Content.ReadAsAsync<TblPatient>();
            return ans;
        }
        public async Task<bool> DeletePatient(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/DeletePatient?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<bool> UpdatePatient(TblPatient patient, int logId)
        {
            List<object> patientAndLogId = new List<object>();
            patientAndLogId.Add(patient);
            patientAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PatientCore/UpdatePatient", patientAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectAllPatients()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/PatientCore/SelectAllPatients");
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        public async Task<TblPatient> SelectPatientById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientById?id={id}", id);
            TblPatient ans = await httpResponseMessage.Content.ReadAsAsync<TblPatient>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByName?name={name}", name);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectPatientByIsMan(bool isMan)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByIsMan?isMan={isMan}", isMan);
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectPatientByCountryId(int countryId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByCountryId?countryId={countryId}", countryId);
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectPatientByCityId(int cityId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByCityId?cityId={cityId}", cityId);
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectPatientByPassNoOrIdentification(int passNoOrIdentification)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByPassNoOrIdentification?passNoOrIdentification={passNoOrIdentification}", passNoOrIdentification);
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByEmail(string email)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByEmail?email={email}", email);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByTellNo?tellNo={tellNo}", tellNo);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectPatientByUserPassId(int userPassId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByUserPassId?userPassId={userPassId}", userPassId);
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByParentalName(string parentalName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByParentalName?parentalName={parentalName}", parentalName);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByHelpName(string helpName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByHelpName?helpName={helpName}", helpName);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByFirstName(string firstName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByFirstName?firstName={firstName}", firstName);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByLastName(string lastName)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByLastName?lastName={lastName}", lastName);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectPatientByIdentificationNo(int identificationNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByIdentificationNo?identificationNo={identificationNo}", identificationNo);
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByUsernameAndPassword(string username ,string password)
        {
            List<object> obj = new List<object>();
            obj.Add(username);
            obj.Add(password);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByUsernameAndPassword", obj);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByUsername(string username)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByUsername?username={username}", username);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<DtoTblPatient> SelectPatientByPassword(string password)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByPassword?password={password}", password);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }

    }
}