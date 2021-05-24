using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace FroggyBot.Modules
{
    public class AdminModule : ModuleBase<ShardedCommandContext>
    {
		[RequireUserPermission(GuildPermission.KickMembers)]
        [Command("warn")]
        public async Task WarnAsync()
        {
            await ReplyAsync("WIP");
        }
    }
}
