using Discord.WebSocket;

namespace RethoughtDB.Adapters.Discord
{
    public class RethoughtConfig
    {
        public DiscordSocketClient Client { get; }

        public ulong GuildId { get; }

        public string ConnectionString { get; }

        public RethoughtConfig(DiscordSocketClient client, ulong guildId, string connectionString)
        {
            Client = client;
            GuildId = guildId;
            ConnectionString = connectionString;
        }
    }
}
