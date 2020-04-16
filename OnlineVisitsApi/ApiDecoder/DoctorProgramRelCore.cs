using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.ApiDecoder
{
    public class DoctorProgramRelCore
    {
        private HttpClient _httpClient;

        public DoctorProgramRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/DoctorProgramRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Uri);

        }
        public async Task<DtoTblDoctorProgramRel> AddDoctorProgramRel(TblDoctorProgramRel doctorProgramRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorProgramRelCore/AddDoctorProgramRel", doctorProgramRel);
            DtoTblDoctorProgramRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctorProgramRel>();
            return ans;
        }
        public async Task<bool> DeleteDoctorProgramRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorProgramRelCore/DeleteDoctorProgramRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<bool> UpdateDoctorProgramRel(TblDoctorProgramRel doctorProgramRel, int logId)
        {
            List<object> doctorProgramRelAndLogId = new List<object>();
            doctorProgramRelAndLogId.Add(doctorProgramRel);
            doctorProgramRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorProgramRelCore/UpdateDoctorProgramRel", doctorProgramRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<List<DtoTblDoctorProgramRel>> SelectAllDoctorProgramRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/DoctorProgramRelCore/SelectAllDoctorProgramRels");
            List<DtoTblDoctorProgramRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctorProgramRel>>();
            return ans;
        }
        public async Task<DtoTblDoctorProgramRel> SelectDoctorProgramRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorProgramRelCore/SelectDoctorProgramRelById?id={id}", id);
            DtoTblDoctorProgramRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDoctorProgramRel>();
            return ans;
        }
        /// <summary>
        /// Select DoctorProgramRels from OnlineVisits.TblDoctorProgramRel by doctorId
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>        public async Task<List<DtoTblDoctorProgramRel>> SelectDoctorProgramRelByDoctorId(int doctorId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorProgramRelCore/SelectDoctorProgramRelByDoctorId?doctorId={doctorId}", doctorId);
            List<DtoTblDoctorProgramRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctorProgramRel>>();
            return ans;
        }
        public async Task<List<DtoTblDoctorProgramRel>> SelectDoctorProgramRelByProgramId(int programId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorProgramRelCore/SelectDoctorProgramRelByProgramId?programId={programId}", programId);
            List<DtoTblDoctorProgramRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDoctorProgramRel>>();
            return ans;
        }

    }
}