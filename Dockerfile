FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY AspNetCoreAPI/*.csproj      ./AspNetCoreAPI/
COPY AspNetCoreAPI.Test/*.csproj ./AspNetCoreAPI.Test/
RUN dotnet restore

# copy everything else and build app
COPY AspNetCoreAPI/. ./AspNetCoreAPI/
WORKDIR /app/AspNetCoreAPI
RUN dotnet publish -c release -o out

FROM  mcr.microsoft.com/dotnet/sdk:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/AspNetCoreAPI/out ./
ENV ASPNETCORE_URLS="http://0.0.0.0:3000"

ENTRYPOINT ["dotnet", "AspNetCoreAPI.dll"]

