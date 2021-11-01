FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BrewHelperWeb/BrewHelperWeb.csproj", "BrewHelperWeb/"]
RUN dotnet restore "BrewHelperWeb/BrewHelperWeb.csproj"
COPY . .
WORKDIR "/src/BrewHelperWeb"
RUN dotnet build "BrewHelperWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrewHelperWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrewHelperWeb.dll"]
