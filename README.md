# Froggy bot

An open source bot written by the Frostbitten discord server! Discord: https://discord.gg/wth4ZCes

## Building/running

The only requirement is that you have `dotnet 5` installed.
After you have installed `dotnet 5`, all you have to do is cd into the FroggyBot directory, and run `dotnet run`.
Make sure you have your token in a file called `token.txt` in the FroggyBot directory!

## Deploying with Docker

Docker/Podman can be used to deploy and monitor the app on a server.
The command `docker` and `podman` are interchangeable.
It is assumed that you are in the project root directory.

For more information/guides, open Dockerfile.

### Ubuntu 20.10+/WSL2

```sh
sudo apt install podman runc
podman build -t froggy-bot -f Dockerfile .
podman run -d -p 3000:3000 froggy-bot
```

### Windows

Install Docker https://docs.docker.com/docker-for-windows/install/

Follow-Up with the same commands (*only docker command is available for windows*)