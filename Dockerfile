FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY AspNetCoreAPI/*.csproj ./AspNetCoreAPI/
RUN dotnet restore

# copy everything else and build app
COPY AspNetCoreAPI/. ./AspNetCoreAPI/
WORKDIR /app/AspNetCoreAPI
RUN dotnet publish -c Release -o out

FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/AspNetCoreAPI/out ./
ENV ASPNETCORE_URLS "http://0.0.0.0:5000"

ENTRYPOINT ["dotnet", "AspNetCoreAPI.dll"]

