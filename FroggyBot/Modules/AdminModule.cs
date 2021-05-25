using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using FroggyBot.Commands;
using FroggyBot.Database;
using FroggyBot.Database.Models;

namespace FroggyBot.Modules
{
    public class AdminModule : ModuleBase<ShardedFroggyCommandContext>
    {
        [RequireUserPermission(GuildPermission.KickMembers)]
        [Command("warn")]
        public async Task WarnAsync(IUser user = null)
        {
            var msg = $"Guild ID: {Context.guildItem.Id}";
            await ReplyAsync(msg);
        }
    }
}
