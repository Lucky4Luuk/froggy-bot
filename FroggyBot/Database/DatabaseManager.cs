using System;
using Raven.Client.Documents;
using Raven.Embedded;

using FroggyBot.Database.Models;

namespace FroggyBot.Database {
    public class DatabaseManager : IDisposable {
        public readonly IDocumentStore Store;

        public DatabaseManager() {
            var opts = new ServerOptions();
            if (Environment.GetEnvironmentVariable("CONTAINERIZED") == "true")
            {
                opts.FrameworkVersion = "5.0.x";
            }

            EmbeddedServer.Instance.StartServer(opts);
            Store = EmbeddedServer.Instance.GetDocumentStore("Froggy");
			Console.WriteLine($"RavenDB dashboard: {Store.Urls[0]}");
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
