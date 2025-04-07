FROM node:18 AS frontend-build
WORKDIR /app
COPY MAVI.Client/package*.json ./MAVI.Client/
RUN cd MAVI.Client && npm install
COPY MAVI.Client ./MAVI.Client
RUN cd MAVI.Client && npm run build --configuration=production

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS backend-build
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

FROM nginx:1.21 AS final
COPY --from=frontend-build /app/MAVI.Client/dist/mavi.client/browser /usr/share/nginx/html
COPY MAVI.Client/nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=backend-build /app/publish /backend

EXPOSE 80 8080

CMD ["sh", "-c", "dotnet /backend/MAVI.API.dll & nginx -g 'daemon off;'"]
