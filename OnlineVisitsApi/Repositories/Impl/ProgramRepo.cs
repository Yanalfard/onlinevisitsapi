using System.Collections.Generic;
using System.Linq;
using OnlineVisitsApi.Models.Regular;
using OnlineVisitsApi.Repositories.Api;
using OnlineVisitsApi.Utillities;

namespace OnlineVisitsApi.Repositories.Impl
{
    public class ProgramRepo : IProgramRepo
    {
        public TblProgram AddProgram(TblProgram program)
        {
            return (TblProgram)new MainProvider().Add(program);
        }
        public bool DeleteProgram(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblProgram, id);
        }
        public bool UpdateProgram(TblProgram program, int logId)
        {
            return new MainProvider().Update(program, logId);
        }
        public List<TblProgram> SelectAllPrograms()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblProgram).Cast<TblProgram>().ToList();
        }
        public TblProgram SelectProgramById(int id)
        {
            return (TblProgram)new MainProvider().SelectById(MainProvider.Tables.TblProgram, id);
        }

    }
}