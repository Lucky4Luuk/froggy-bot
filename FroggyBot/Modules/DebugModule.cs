using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using FroggyBot.Commands;
using FroggyBot.Database;
using FroggyBot.Database.Models;

namespace FroggyBot.Modules
{
    public class DebugModule : ModuleBase<ShardedFroggyCommandContext>
    {
		[RequireOwner] //Require the owner of the bot to call this
        [Command("read_guild_item")]
        public async Task ReadAsync(string guildId)
        {
			var guild = Context.db.Get<GuildItem>("GUILD" + guildId);
            var msg = $"Guild ID: {Context.guildItem.Id}\nGuild prefix: {guild.prefix}";
            await ReplyAsync(msg);
        }
    }
}
