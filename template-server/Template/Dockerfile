# Build Image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Template/Api/Api.csproj", "Api/"]
COPY ["Template/Application/Application.csproj", "Application/"]
COPY ["Template/Domain/Domain.csproj", "Domain/"]
COPY ["Template/Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
RUN dotnet restore Api/Api.csproj --source https://api.nuget.org/v3/index.json --source https://www.myget.org/F/npgsql-vnext/api/v3/index.json -v d

COPY Template/ .
COPY SharedKernel/ SharedKernel/

WORKDIR /src/Api
RUN dotnet publish -c Release -o /app/publish

# Production image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Api.dll"]