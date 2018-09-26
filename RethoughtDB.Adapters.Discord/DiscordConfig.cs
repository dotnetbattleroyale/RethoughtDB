using Discord.WebSocket;

namespace RethoughtDB.Adapters.Discord
{
    public class DiscordConfig
    {
        public DiscordSocketClient Client { get; }

        public ulong GuildId { get; }

        public DiscordConfig(DiscordSocketClient client, ulong guildId)
        {
            Client = client;
            GuildId = guildId;
        }
    }
}
