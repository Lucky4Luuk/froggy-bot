using System;
using Raven.Client.Documents;
using Raven.Embedded;

namespace FroggyBot.Database {
	public class DatabaseInterface : IDisposable {
		public readonly IDocumentStore Store;

		public DatabaseManager() {
			EmbeddedServer.Instance.StartServer();
			Store = EmbeddedServer.Instance.GetDocumentStore("Froggy");
		}

		public void Dispose() {
			Store.Dispose();
		}

		public T Get<T>(string id) where T : DatabaseItem {
			using (var session = Store.OpenSession())
				return session.Load<T>(id);
		}

		public void Save<T>(T item) where T : DatabaseItem {
			if (item == null)
				return;

			using (var session = Store.OpenSession()) {
				session.Store(item, item.Id);
				session.SaveChanges();
			}
		}
	}
}
