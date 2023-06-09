using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Api;

namespace OnlineVisitsApi.Services.Api
{
    public interface IPatientService : IPatientRepo
    {
        List<TblDoctor>SelectDoctorsByPatientId(int patientId);

    }
}