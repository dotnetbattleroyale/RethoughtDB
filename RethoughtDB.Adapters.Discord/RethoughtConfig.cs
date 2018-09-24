using Discord.WebSocket;

namespace RethoughtDB.Adapters.Discord
{
    public class RethoughtConfig
    {
        public DiscordSocketClient Client { get; }

        public ulong GuildId { get; }

        public RethoughtConfig(DiscordSocketClient client, ulong guildId)
        {
            Client = client;
            GuildId = guildId;
        }
    }
}
