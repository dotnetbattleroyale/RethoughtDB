using System;
using System.Threading.Tasks;

namespace RethoughtDB.Core
{
    public interface IRethoughtDatabase
    {
        bool IsReady { get; }
        event Action DatabaseReady;

        Task<IRethoughtTable> GetTableAsync(string name);
    }
}