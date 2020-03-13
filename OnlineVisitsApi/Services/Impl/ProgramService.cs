using System.Collections.Generic;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Impl;
using OnlineVisitsApi.Services.Api;

namespace OnlineVisitsApi.Services.Impl
{
    public class ProgramService : IProgramService
    {
        public TblProgram AddProgram(TblProgram program)
        {
            return new ProgramRepo().AddProgram(program);
        }
        public bool DeleteProgram(int id)
        {
            return new ProgramRepo().DeleteProgram(id);
        }
        public bool UpdateProgram(TblProgram program, int logId)
        {
            return new ProgramRepo().UpdateProgram(program, logId);
        }
        public List<TblProgram> SelectAllPrograms()
        {
            return new ProgramRepo().SelectAllPrograms();
        }
        public TblProgram SelectProgramById(int id)
        {
            return (TblProgram)new ProgramRepo().SelectProgramById(id);
        }

    }
}