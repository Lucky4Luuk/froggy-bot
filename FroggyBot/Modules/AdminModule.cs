using System;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using FroggyBot.Commands;
using FroggyBot.Database;
using FroggyBot.Database.Models;

namespace FroggyBot.Modules
{
    public class AdminModule : ModuleBase<ShardedFroggyCommandContext>
    {
        [RequireUserPermission(GuildPermission.KickMembers)]
        [Command("warn")]
        public async Task WarnAsync(SocketGuildUser user = null, [Remainder] string reason = null) //Will take a user id as well
        {
            reason = reason ?? "No reason provided.";
            var msg = $"Guild ID: {Context.guildItem.Id}";

            if (user == null) {
                msg = $"Please provide a user and a reason. Command format: `{Context.guildItem.prefix}warn <@user/id> [reason]`";
                throw new ArgumentNullException("WarnSync", msg);
            }

            await ReplyAsync(msg);
        }
    }
}
