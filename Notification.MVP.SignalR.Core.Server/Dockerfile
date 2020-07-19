#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Notification.MVP.SignalR.Core.Server/Notification.MVP.SignalR.Core.Server.csproj", "Notification.MVP.SignalR.Core.Server/"]
RUN dotnet restore "Notification.MVP.SignalR.Core.Server/Notification.MVP.SignalR.Core.Server.csproj"
COPY . .
WORKDIR "/src/Notification.MVP.SignalR.Core.Server"
RUN dotnet build "Notification.MVP.SignalR.Core.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notification.MVP.SignalR.Core.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.MVP.SignalR.Core.Server.dll"]