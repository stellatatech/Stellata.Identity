FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Stellata.Identity.Api/Stellata.Identity.Api.csproj", "Stellata.Identity.Api/"]
RUN dotnet restore "Stellata.Identity.Api/Stellata.Identity.Api.csproj"
COPY . .
WORKDIR "/src/Stellata.Identity.Api"
RUN dotnet build "Stellata.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stellata.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stellata.Identity.Api.dll"]
