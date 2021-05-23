# RavenDB hard strict patch version requirements
FROM mcr.microsoft.com/dotnet/sdk:5.0.203

WORKDIR /opt/Froggers
COPY . .

ENV CONTAINERIZED=true

WORKDIR /opt/Froggers/FroggyBot
CMD ["dotnet", "run"]


### General Information
# -------------------------
# It may take 10-15 seconds for "docker logs <id>" to show logs
# This is because of nuget restore running in background


### Port Mapping
# -------------------------
# Remember that it will occupy the 3000 port on your server/PC
# This can be changed using the left integer on the third command
# e.g. - "-p 4000:3000" for 4000 port. App always uses 3000 port internally.


### Cleaning Up
# --------------------------
# When containers stop/exit, they still occupy a small amount of space.

# Make sure to list the containers using `docker ps -a` and read the logs first.
# After that, follow up with `docker container prune` to remove them.

# Also, rebuilds using `docker build` occupy some space. List images by `podman images` and follow-up by removing anything named <none> by id