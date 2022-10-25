using ConfLog.Interfaces;
using ConfLog.Models;

namespace ConfLog.Mocks
{
    public class MockFType : IFuncType 
    {
        public IEnumerable<FType> AllTypes
        {
            get {
                return new List<FType>
                {
                    new FType { functionType = "Логирующая" },
                    new FType { functionType = "Не Логирующая" }
                };
            }
        }
    }
}
