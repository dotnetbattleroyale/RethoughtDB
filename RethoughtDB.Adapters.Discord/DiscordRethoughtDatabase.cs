using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using RethoughtDB.Core;

namespace RethoughtDB.Adapters.Discord
{
    public class DiscordRethoughtDatabase: IRethoughtDatabase
    {
        public ulong GuildId { get; }
        public string ConnectionString { get; }
        public DiscordSocketClient Client { get; }
        public SocketGuild Guild { get; private set; }
        public IReadOnlyList<SocketTextChannel> Tables { get; private set; }
        public bool IsReady { get; private set; }
        
        public DiscordRethoughtDatabase(ulong guildId, string connectionString)
        {
            GuildId = guildId;
            ConnectionString = connectionString;
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                MessageCacheSize = 100
            });

            Client.Ready += async () =>
            {
                Guild = Client.GetGuild(guildId);
                Tables = Guild.TextChannels.ToList();
                
                IsReady = true;
                DatabaseReady?.Invoke();
            };
            
            Client.LoginAsync(TokenType.Bot, connectionString).GetAwaiter().GetResult();
            Client.StartAsync().GetAwaiter().GetResult();
        }

        public event Action DatabaseReady;
        
        public async Task<IRethoughtTable> GetTableAsync(string name)
        {
            var t = Tables.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (t == null) return null;

            await t.GetMessagesAsync().FlattenAsync();
            
            return new DiscordRethoughtTable(t);
        }
    }
}