using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace FroggyBot.Services
{
    public class CommandHandlingService
    {
        private readonly CommandService _commands;
        private readonly DiscordShardedClient _discord;
        private readonly IServiceProvider _services;

		//TODO: Prefix per server?
		private readonly String _prefix;

        public CommandHandlingService(IServiceProvider services)
        {
            _commands = services.GetRequiredService<CommandService>();
            _discord = services.GetRequiredService<DiscordShardedClient>();
            _services = services;

			_prefix = "!";

            _commands.CommandExecuted += CommandExecutedAsync;
            _commands.Log += LogAsync;
            _discord.MessageReceived += MessageReceivedAsync;
        }

        public async Task InitializeAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        public async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            // Ignore system messages, or messages from other bots
            if (!(rawMessage is SocketUserMessage message))
                return;
            else if (message.Source != MessageSource.User)
                return;

            // This value holds the offset where the prefix ends
            var argPos = 0;
            if (!message.HasMentionPrefix(_discord.CurrentUser, ref argPos))
				if (!message.HasStringPrefix(_prefix, ref argPos))
					return;

            // A new kind of command context, ShardedCommandContext can be utilized with the commands framework
            var context = new ShardedCommandContext(_discord, message);
            await _commands.ExecuteAsync(context, argPos, _services);
        }

        public async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            // command is unspecified when there was a search failure (command not found); we don't care about these errors
            if (!command.IsSpecified)
                return;

            // the command was succesful, we don't care about this result, unless we want to log that a command succeeded.
            if (result.IsSuccess)
                return;

            // the command failed, let's notify the user that something happened.
            await context.Channel.SendMessageAsync($"error: {result.ToString()}");
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }
    }
}
