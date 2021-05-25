using Discord.Commands;
using Discord.WebSocket;
using FroggyBot.Database;
using FroggyBot.Database.Models;

namespace FroggyBot.Commands
{
    public class ShardedFroggyCommandContext : ShardedCommandContext
    {
        public ShardedFroggyCommandContext(DiscordShardedClient client, SocketUserMessage msg, DatabaseManager _db, GuildItem gi) : base(client, msg) {
            guildItem = gi;
            db = _db;
        }

        public GuildItem guildItem { get; }
        public DatabaseManager db { get; set; }
    }
}
