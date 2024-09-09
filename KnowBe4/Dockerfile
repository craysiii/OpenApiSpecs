FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Not supposed to run as root!
# Figure out how to get rid of this (Playwright installation requiring it)
USER root
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KnowBe4.csproj", "./"]
RUN dotnet restore "KnowBe4.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "KnowBe4.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KnowBe4.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KnowBe4.dll"]