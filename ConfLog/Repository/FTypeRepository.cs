using ConfLog.Interfaces;
using ConfLog.Models;

namespace ConfLog.Repository
{
    public class FTypeRepository:IFuncType
    {
        private readonly AppDBContent appDBcontent;
        public FTypeRepository(AppDBContent appDBcontent)
        {
            this.appDBcontent = appDBcontent;
        }

        public IEnumerable<FType> AllTypes => appDBcontent.FType;
    }
}
