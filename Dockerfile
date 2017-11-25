FROM node:9.2.0-stretch AS frontend-env

WORKDIR /app

COPY . ./
RUN npm install
RUN npm run lint
RUN npm run build:prod

FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
COPY NuGet.config ./
RUN dotnet restore

# copy everything else and build
COPY . ./
COPY --from=frontend-env /app/wwwroot ./wwwroot

RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out ./
ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "ClimateMeter.Web.dll"]