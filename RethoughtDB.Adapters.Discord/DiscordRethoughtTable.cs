using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using Newtonsoft.Json;
using RethoughtDB.Core;

namespace RethoughtDB.Adapters.Discord
{
    public class DiscordRethoughtTable: IRethoughtTable
    {
        internal SocketTextChannel Channel { get; }
        
        internal DiscordRethoughtTable(SocketTextChannel channel)
        {
            Channel = channel;
        }
        
        public async Task<IRethoughtDocument> GetDocumentAsync(string id)
        {
            var document = Channel.CachedMessages.FirstOrDefault(m =>
                m is SocketUserMessage && JsonConvert.DeserializeObject<DiscordRethoughtDocument>(m.Content).Id == id);

            return document == null ? null : JsonConvert.DeserializeObject<DiscordRethoughtDocument>(document.Content);
        }

        public async Task<bool> InsertDocumentAsync(string id, string content)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ReplaceDocumentAsync(string id, string content)
        {
            throw new System.NotImplementedException();
        }
    }
}