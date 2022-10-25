using ConfLog.Models;

namespace ConfLog.Interfaces
{
    public interface IFuncType
    {
        IEnumerable<FType> AllTypes { get; }
    }
}
