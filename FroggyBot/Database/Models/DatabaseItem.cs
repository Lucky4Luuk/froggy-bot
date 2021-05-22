namespace FroggyBot.Database.Models {
	/// <summary>
	/// An abstract class everything to be stored in the database has to derive from.
	/// Doesn't do much, just stores an Id for the database manager to use.
	/// </summary>
	public abstract class DatabaseItem {
		public string Id { get; set; }
	}
}
