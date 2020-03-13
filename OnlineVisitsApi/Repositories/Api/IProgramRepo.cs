using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;

namespace OnlineVisitsApi.Repositories.Api
{
    public interface IProgramRepo
    {
        TblProgram AddProgram(TblProgram program);
        bool DeleteProgram(int id);
        bool UpdateProgram(TblProgram program, int logId);
        List<TblProgram> SelectAllPrograms();
        TblProgram SelectProgramById(int id);

    }
}