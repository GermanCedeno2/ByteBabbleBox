## Use a lightweight Linux distribution with SQLite
#FROM alpine
#
## Install SQLite
#RUN apk add --no-cache sqlite
#
## Copy your SQLite database file into the container
#COPY D://DockerProject//SistemaBancario//SistemaBancario//bank.db /app/bank.db

# Use the official .NET 7.0 runtime image as the base
FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

# Use the official .NET 7.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SistemaBancario.csproj", "."]
RUN dotnet restore "./SistemaBancario.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SistemaBancario.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "SistemaBancario.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Create the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaBancario.dll"]
