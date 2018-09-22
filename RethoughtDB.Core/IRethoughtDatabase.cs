using System.Threading.Tasks;

namespace RethoughtDB.Core
{
    public interface IRethoughtDatabase
    {
        Task<IRethoughtTable> GetTableAsync(string name);
    }
}