using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HelthTourismV2.Models.Dto;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.ApiDecoder
{
    public class ProgramCore : ApiController
    {
        private HttpClient _httpClient;

        public ProgramCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProgramCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");

        }
        public async Task<TblProgram> AddProgram(TblProgram program)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProgramCore/AddProgram", program);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<bool> DeleteProgram(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProgramCore/DeleteProgram?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<bool> UpdateProgram(TblProgram program, int logId)
        {
            List<object> programAndLogId = new List<object>();
            programAndLogId.Add(program);
            programAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProgramCore/UpdateProgram", programAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<List<DtoTblProgram>> SelectAllPrograms()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ProgramCore/SelectAllPrograms");
            List<DtoTblProgram> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProgram>>();
            return ans;
        }
        public async Task<TblProgram> SelectProgramById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProgramCore/SelectProgramById?id={id}", id);
            TblProgram ans = await httpResponseMessage.Content.ReadAsAsync<TblProgram>();
            return ans;
        }

    }
}