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

        [RequireUserPermission(GuildPermission.ManageGuild)]
        [Command("prefix", true)]
        public async Task PrefixAsync(string prefix = null)
        {
            if(string.IsNullOrWhiteSpace(prefix))
            {
				await ReplyAsync($"Current prefix is `{Context.guildItem.prefix}`."
                +$"\nTo chage current prefix: `{Context.guildItem.prefix}prefix <new prefix>`");
				return;
			}
			Context.guildItem.prefix = prefix;
			Context.db.Save<GuildItem>(Context.guildItem);
			await ReplyAsync($"Server prefix set to {prefix}");
		}
    }
}
