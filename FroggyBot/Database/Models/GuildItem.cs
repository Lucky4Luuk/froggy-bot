using System;
using System.Collections.Generic;

namespace FroggyBot.Database.Models {
	public class GuildItem : DatabaseItem {
		public Dictionary<string, List<ModCase>> cases;

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
	}
}
