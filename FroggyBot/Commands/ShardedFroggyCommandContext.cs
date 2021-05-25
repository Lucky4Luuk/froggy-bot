using Discord.Commands;
using Discord.WebSocket;
using FroggyBot.Database;
using FroggyBot.Database.Models;

namespace FroggyBot.Commands
{
    public class ShardedFroggyCommandContext : ShardedCommandContext
    {
        public ShardedFroggyCommandContext(DiscordShardedClient client, SocketUserMessage msg, GuildItem gi) : base(client, msg)
            => GuildItem = gi;

        public GuildItem GuildItem { get; }

    }
}
