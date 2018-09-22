using System.Threading.Tasks;

namespace RethoughtDB.Core
{
    public interface IRethoughtTable
    {
        Task<IRethoughtDocument> GetDocumentAsync(string id);
        Task<bool> InsertDocumentAsync(string id, string content);
        Task<bool> ReplaceDocumentAsync(string id, string content);
    }
}