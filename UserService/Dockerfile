#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UserProfile/ContentService.csproj", "UserProfile/"]
COPY ["BuildingBlock/Core/Core.csproj", "BuildingBlock/Core/"]
COPY ["BuildingBlock/Exceptions.Abstraction/Abstraction.csproj", "BuildingBlock/Exceptions.Abstraction/"]
COPY ["BuildingBlock/Infrastructure/Infrastructure.csproj", "BuildingBlock/Infrastructure/"]
COPY ["Service.Shared/Service.Shared.csproj", "Service.Shared/"]
RUN dotnet restore "./UserProfile/ContentService.csproj"
COPY . .
WORKDIR "/src/UserProfile"
RUN dotnet build "./ContentService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ContentService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContentService.dll"]