using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.ApiDecoder
{
    public class PatientDoctorRelCore
    {
        private HttpClient _httpClient;

        public PatientDoctorRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/PatientDoctorRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Uri);

        }
        /// <summary>
        /// Adds a patientDoctorRel to OnlineVisits.TblPatientDoctorRel
        /// </summary>
        /// <param name="patientDoctorRel"></param>
        /// <returns></returns>
        public async Task<DtoTblPatientDoctorRel> AddPatientDoctorRel(TblPatientDoctorRel patientDoctorRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PatientDoctorRelCore/AddPatientDoctorRel", patientDoctorRel);
            DtoTblPatientDoctorRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatientDoctorRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a patientDoctorRel from OnlineVisits.TblPatientDoctorRel using its id
        /// </summary>
        /// <param name="patientDoctorRel"></param>
        /// <returns></returns>
        public async Task<bool> DeletePatientDoctorRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientDoctorRelCore/DeletePatientDoctorRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a patientDoctorRel at OnlineVisits.TblPatientDoctorRel
        /// </summary>
        /// <param name="patientDoctorRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdatePatientDoctorRel(TblPatientDoctorRel patientDoctorRel, int logId)
        {
            List<object> patientDoctorRelAndLogId = new List<object>();
            patientDoctorRelAndLogId.Add(patientDoctorRel);
            patientDoctorRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PatientDoctorRelCore/UpdatePatientDoctorRel", patientDoctorRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all patientDoctorRels from OnlineVisits.TblPatientDoctorRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblPatientDoctorRel>> SelectAllPatientDoctorRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/PatientDoctorRelCore/SelectAllPatientDoctorRels");
            List<DtoTblPatientDoctorRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatientDoctorRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from OnlineVisits.TblPatientDoctorRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblPatientDoctorRel> SelectPatientDoctorRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientDoctorRelCore/SelectPatientDoctorRelById?id={id}", id);
            DtoTblPatientDoctorRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblPatientDoctorRel>();
            return ans;
        }
        /// <summary>
        /// Select PatientDoctorRels from OnlineVisits.TblPatientDoctorRel by patientId
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<TblPatientDoctorRel>> SelectPatientDoctorRelByPatientId(int patientId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientDoctorRelCore/SelectPatientDoctorRelByPatientId?patientId={patientId}", patientId);
            List<TblPatientDoctorRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<TblPatientDoctorRel>>();
            return ans;
        }
        /// <summary>
        /// Select PatientDoctorRels from OnlineVisits.TblPatientDoctorRel by doctorId
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPatientDoctorRel>> SelectPatientDoctorRelByDoctorId(int doctorId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientDoctorRelCore/SelectPatientDoctorRelByDoctorId?doctorId={doctorId}", doctorId);
            List<DtoTblPatientDoctorRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatientDoctorRel>>();
            return ans;
        }
        /// <summary>
        /// Select PatientDoctorRels from OnlineVisits.TblPatientDoctorRel by time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPatientDoctorRel>> SelectPatientDoctorRelByTime(int time)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientDoctorRelCore/SelectPatientDoctorRelByTime?time={time}", time);
            List<DtoTblPatientDoctorRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatientDoctorRel>>();
            return ans;
        }
        /// <summary>
        /// Select PatientDoctorRels from OnlineVisits.TblPatientDoctorRel by isUp
        /// </summary>
        /// <param name="isUp"></param>
        /// <returns></returns>
        public async Task<List<DtoTblPatientDoctorRel>> SelectPatientDoctorRelByIsUp(int isUp)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PatientDoctorRelCore/SelectPatientDoctorRelByIsUp?isUp={isUp}", isUp);
            List<DtoTblPatientDoctorRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblPatientDoctorRel>>();
            return ans;
        }

    }
}