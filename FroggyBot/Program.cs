using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

using FroggyBot.Services;
using FroggyBot.Database;

namespace FroggyBot
{
    class Program
    {
        public DatabaseManager db = new DatabaseManager();

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync() {

            var config = new DiscordSocketConfig {
                TotalShards = 1,
            };

            string token = File.ReadAllText("./token.txt").Trim();

            using (var services = ConfigureServices(config)) {
                var client = services.GetRequiredService<DiscordShardedClient>();

                client.ShardReady += ReadyAsync;
                client.Log += LogAsync;

                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();

                await client.LoginAsync(TokenType.Bot, token);
                await client.StartAsync();

                await Task.Delay(Timeout.Infinite);
            }
        }

        private ServiceProvider ConfigureServices(DiscordSocketConfig config) {
            return new ServiceCollection()
                .AddSingleton(new DiscordShardedClient(config))
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .BuildServiceProvider();
        }

        private Task ReadyAsync(DiscordSocketClient shard) {
            Console.WriteLine($"Shard number {shard.ShardId} is connected and ready!");
            return Task.CompletedTask;
        }

        private Task LogAsync(LogMessage log) {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
    }
}
