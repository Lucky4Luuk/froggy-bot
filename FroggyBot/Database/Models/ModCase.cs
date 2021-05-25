using System;

namespace FroggyBot.Database.Models {
    public class ModCase {
        /// <summary>
        /// User ID
        /// </summary>
        public string UserId;
        /// <summary>
        /// Case reason
        /// </summary>
        public string Reason;
        /// <summary>
        /// Id of the moderator that issued the warning
        /// </summary>
        public string ModId;
    }
}
