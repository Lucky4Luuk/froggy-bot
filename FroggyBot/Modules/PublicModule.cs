using System.Threading.Tasks;
using Discord.Commands;
using FroggyBot.Commands;
using FroggyBot.Database;
using FroggyBot.Database.Models;

namespace FroggyBot.Modules
{
    public class PublicModule : ModuleBase<ShardedFroggyCommandContext>
    {
        [Command("info")]
        public async Task InfoAsync()
        {
            var msg = $@"Hi {Context.User}! There are currently {Context.Client.Shards.Count} shards!
                This guild is being served by shard number {Context.Client.GetShardFor(Context.Guild).ShardId}
                Prefix: `{Context.GuildItem.prefix}`";
            await ReplyAsync(msg);
        }
    }
}
