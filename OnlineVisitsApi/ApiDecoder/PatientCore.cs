using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.ApiDecoder
{
    public class PatientCore
    {
        private HttpClient _httpClient;

        public PatientCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/PatientCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");

        }
        /// <summary>
        /// Adds a patient to OnlineVisits.TblPatient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<DtoTblPatient> AddPatient(TblPatient patient)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PatientCore/AddPatient", patient);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        /// <summary>
        /// Deletes a patient from OnlineVisits.TblPatient using its id
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<bool> DeletePatient(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/DeletePatient?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a patient at OnlineVisits.TblPatient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdatePatient(TblPatient patient, int logId)
        {
            List<object> patientAndLogId = new List<object>();
            patientAndLogId.Add(patient);
            patientAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PatientCore/UpdatePatient", patientAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all patients from OnlineVisits.TblPatient
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblPatient>> SelectAllPatients()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/PatientCore/SelectAllPatients");
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblPatient by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblPatient> SelectPatientById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientById?id={id}", id);
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
        public async Task<DtoTblPatient> SelectPatientByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByTellNo?tellNo={tellNo}", tellNo);
            DtoTblPatient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatient>();
            return ans;
        }
        public async Task<List<DtoTblPatient>> SelectPatientByIdentificationNo(int identificationNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/SelectPatientByIdentificationNo?identificationNo={identificationNo}", identificationNo);
            List<DtoTblPatient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatient>>();
            return ans;
        }
        /// <summary>
        /// Selects doctors from OnlineVisits.TblPatient by sectionId
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public async Task<DtoTblPatient> SelectPatientByUsernameAndPassword(string username, string password)
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
        public async Task<List<DtoTblDoctor>> SelectDoctorByPatientId(int patientId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorCore/SelectDoctorByPatientId?patientId={patientId}", patientId);
            List<DtoTblDoctor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctor>>();
            return ans;
        }

        public async Task<string> ReserveStage1(int doctorId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/ReserveStage1?doctorId={doctorId}", doctorId);
            string ans = await httpResponseMessage.Content.ReadAsAsync<string>();
            return ans;
        }
        public async Task<DtoTblPatientDoctorRel> ReserveStage2(int doctorId, int patientId, string stageOnesTime)
        {
            List<object> objs = new List<object>();
            objs.Add(doctorId);
            objs.Add(patientId);
            objs.Add(stageOnesTime);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientCore/ReserveStage2", objs);
            DtoTblPatientDoctorRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatientDoctorRel>();
            return ans;
        }
    }
}