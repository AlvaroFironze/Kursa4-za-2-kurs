using ConfLog.Interfaces;
using ConfLog.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfLog.Repository
{
    public class FuncRepository : IAllFuncs
    {
        private readonly AppDBContent appDBcontent;
        public FuncRepository(AppDBContent appDBcontent)
        {
            this.appDBcontent= appDBcontent;
        }
        public IEnumerable<Function> Funcs => appDBcontent.Functions.Include(c => c.type);
        public IEnumerable<Function> getBaseLogFuncs => appDBcontent.Functions.Where(p => p.isBase);
        public IEnumerable<Function> getNonBaseLogFuncs => appDBcontent.Functions.Where(p => !p.isBase).Include(c => c.type);
        public IEnumerable<Function> getBaseFuncs => appDBcontent.Functions.Where(p => p.isBase);
        public IEnumerable<Function> getNonBaseFuncs => appDBcontent.Functions.Where(p => !p.isBase).Include(c => c.type);

        public Function getObjectFunc(int funcId) => appDBcontent.Functions.Include(c => c.usings).Include(c => c.fields).ToList().FirstOrDefault(p => p.id == funcId);
    }
}
