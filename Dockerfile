FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["PiWeb.csproj", ""]
RUN dotnet restore "PiWeb.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PiWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PiWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PiWeb.dll"]