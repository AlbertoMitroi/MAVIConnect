FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src
COPY ["MAVI.API/MAVI.API.csproj", "MAVI.API/"]
COPY ["MAVI.Application/MAVI.Application.csproj", "MAVI.Application/"]
COPY ["MAVI.Domain/MAVI.Domain.csproj", "MAVI.Domain/"]
COPY ["MAVI.Infrastructure/MAVI.Infrastructure.csproj", "MAVI.Infrastructure/"]
COPY ["MAVI.Contracts/MAVI.Contracts.csproj", "MAVI.Contracts/"]
RUN dotnet restore "MAVI.API/MAVI.API.csproj"

COPY . .
WORKDIR "/src/MAVI.API"
RUN dotnet publish "MAVI.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MAVI.API.dll"]
