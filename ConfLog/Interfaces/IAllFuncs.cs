using ConfLog.Models;

namespace ConfLog.Interfaces
{
    public interface IAllFuncs
    {
        IEnumerable<Function> Funcs { get; }
        IEnumerable<Function> getBaseLogFuncs { get;  }
        IEnumerable<Function> getNonBaseLogFuncs { get;  }
        IEnumerable<Function> getBaseFuncs { get; }
        IEnumerable<Function> getNonBaseFuncs { get; }
        Function getObjectFunc(int funcId);
    }
}
