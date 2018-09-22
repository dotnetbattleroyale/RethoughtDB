using System.Threading.Tasks;
using Discord.WebSocket;
using Newtonsoft.Json;
using RethoughtDB.Core;

namespace RethoughtDB.Adapters.Discord
{
    public class DiscordRethoughtDocument: IRethoughtDocument
    {
        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("data")]
        public string Content { get; }
        
        public async Task<bool> UpdateAsync(string newContent)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}