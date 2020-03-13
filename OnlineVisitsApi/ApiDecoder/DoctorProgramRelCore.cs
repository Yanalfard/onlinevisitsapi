using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HelthTourismV2.Models.Dto;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.ApiDecoder
{
    public class DoctorProgramRelCore : ApiController
    {
        private HttpClient _httpClient;

        public DoctorProgramRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/DoctorProgramRelCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");

        }
        public async Task<TblDoctorProgramRel> AddDoctorProgramRel(TblDoctorProgramRel doctorProgramRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DoctorProgramRelCore/AddDoctorProgramRel", doctorProgramRel);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
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
        public async Task<TblDoctorProgramRel> SelectDoctorProgramRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorProgramRelCore/SelectDoctorProgramRelById?id={id}", id);
            TblDoctorProgramRel ans = await httpResponseMessage.Content.ReadAsAsync<TblDoctorProgramRel>();
            return ans;
        }
        public async Task<List<TblDoctorProgramRel>> SelectDoctorProgramRelByDoctorId(int doctorId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorProgramRelCore/SelectDoctorProgramRelsByDoctorId?doctorId={doctorId}", doctorId);
            List<TblDoctorProgramRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<TblDoctorProgramRel>>();
            return ans;
        }
        public async Task<List<TblDoctorProgramRel>> SelectDoctorProgramRelByProgramId(int programId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DoctorProgramRelCore/SelectDoctorProgramRelsByProgramId?programId={programId}", programId);
            List<TblDoctorProgramRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<TblDoctorProgramRel>>();
            return ans;
        }

    }
}