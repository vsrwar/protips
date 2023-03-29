FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ProTips.API/ProTips.API.csproj", "ProTips.API/"]
COPY ["ProTips.Business/ProTips.Business.csproj", "ProTips.Business/"]
COPY ["ProTips.Entity/ProTips.Entity.csproj", "ProTips.Entity/"]
RUN dotnet restore "ProTips.API/ProTips.API.csproj"
COPY . .
WORKDIR "/src/ProTips.API"
RUN dotnet build "ProTips.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProTips.API.csproj" -c Release -o /app/publish --self-contained false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProTips.API.dll"]
