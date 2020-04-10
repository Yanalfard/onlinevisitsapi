using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OnlineVisitsApi.Models.Dto;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.ApiDecoder
{
    public class ProgramCore
    {
        private HttpClient _httpClient;

        public ProgramCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProgramCore"));
            _httpClient.BaseAddress = new Uri(Config.Uri);

        }
        public async Task<DtoTblProgram> AddProgram(TblProgram program)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProgramCore/AddProgram", program);
            DtoTblProgram ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProgram>();
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

        public async Task<DtoTblProgram> SelectProgramById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProgramCore/SelectProgramById?id={id}", id);
            DtoTblProgram ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProgram>();
            return ans;
        }


    }
}