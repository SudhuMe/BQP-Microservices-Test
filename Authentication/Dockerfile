FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Authentication/AuthenticationService.csproj", "Authentication/"]
COPY ["BuildingBlock/Exceptions.Abstraction/Exceptions.Abstraction.csproj", "BuildingBlock/Exceptions.Abstraction/"]
COPY ["BuildingBlock/Infrastructure/Infrastructure.csproj", "BuildingBlock/Infrastructure/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "./Authentication/./AuthenticationService.csproj"
COPY . .
WORKDIR "/src/Authentication"
RUN dotnet build "./AuthenticationService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthenticationService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationService.dll"]