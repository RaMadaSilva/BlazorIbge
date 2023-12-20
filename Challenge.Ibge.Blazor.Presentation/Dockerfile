#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Challenge.Ibge.Blazor.Presentation/Challenge.Ibge.Blazor.Presentation.csproj", "Challenge.Ibge.Blazor.Presentation/"]
COPY ["Challenge.Ibge.Blazor.Infra/Challenge.Ibge.Blazor.Infra.csproj", "Challenge.Ibge.Blazor.Infra/"]
COPY ["Challenge.Ibge.Blazor.Domain/Challenge.Ibge.Blazor.Domain.csproj", "Challenge.Ibge.Blazor.Domain/"]
COPY ["Challenge.Ibge.Blazor.Services/Challenge.Ibge.Blazor.Applications.csproj", "Challenge.Ibge.Blazor.Services/"]
RUN dotnet restore "./Challenge.Ibge.Blazor.Presentation/./Challenge.Ibge.Blazor.Presentation.csproj"
COPY . .
WORKDIR "/src/Challenge.Ibge.Blazor.Presentation"
RUN dotnet build "./Challenge.Ibge.Blazor.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Challenge.Ibge.Blazor.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Challenge.Ibge.Blazor.Presentation.dll"]