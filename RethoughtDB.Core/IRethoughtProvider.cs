using System.Threading.Tasks;

namespace RethoughtDB.Core
{
    public interface IRethoughtProvider
    {
        Task<IRethoughtDatabase> GetDatabaseAsync(string name);
    }
}