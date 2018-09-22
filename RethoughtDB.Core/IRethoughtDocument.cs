using System.Threading.Tasks;

namespace RethoughtDB.Core
{
    public interface IRethoughtDocument
    {
        string Id { get; }
        string Content { get; }

        Task<bool> UpdateAsync(string newContent);
        Task<bool> DeleteAsync();
    }
}