FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BuddyDMS/BuddyDMS.csproj", "BuddyDMS/"]
RUN dotnet restore "BuddyDMS/BuddyDMS.csproj"
COPY . .
WORKDIR "/src/BuddyDMS"
RUN dotnet build "BuddyDMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuddyDMS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuddyDMS.dll"]
