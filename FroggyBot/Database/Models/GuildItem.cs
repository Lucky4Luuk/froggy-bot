using System;
using System.Collections.Generic;
using Discord.WebSocket;

namespace FroggyBot.Database.Models {
    public class GuildItem : DatabaseItem {
        public Dictionary<string, List<ModCase>> cases = new();
        public string prefix = "!";

        public GuildItem(string discordId) {
            this.Id = "GUILD" + discordId;
        }

        public void AddCase(ModCase modCase) {
            if (cases.ContainsKey(modCase.UserId)) {
                cases[modCase.UserId].Add(modCase);
            } else {
                cases.Add(modCase.UserId, new List<ModCase>{ modCase });
            }
        }

        public static GuildItem GetGuildItem(DatabaseManager db, ulong id)
        {
            var res = db.Get<GuildItem>("GUILD" + id);
            if (res == null)
            {
                res = new GuildItem(id.ToString());
                db.Save<GuildItem>(res);
            }
            return res;
        }
    }
}
