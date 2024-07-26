FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Little_Conqueror.csproj", "./"]
RUN dotnet restore "Little_Conqueror.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Little_Conqueror.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Little_Conqueror.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Little_Conqueror.dll"]
