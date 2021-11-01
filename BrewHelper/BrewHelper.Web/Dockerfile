FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BrewHelper.Web/BrewHelper.Web.csproj", "BrewHelper.Web/"]
RUN dotnet restore "BrewHelper.Web/BrewHelper.Web.csproj"
COPY . .
WORKDIR "/src/BrewHelper.Web"
RUN dotnet build "BrewHelper.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrewHelper.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrewHelper.Web.dll"]
