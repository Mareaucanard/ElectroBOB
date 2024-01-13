#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
COPY ./run.sh /run.sh
USER root
WORKDIR /app
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ENV MARIADB_PASSWORD=$MARIADB_PASSWORD
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Eletro-BOB_API.csproj", "."]
RUN dotnet restore "./././Eletro-BOB_API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./Eletro-BOB_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Eletro-BOB_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER root
RUN apt update
RUN apt install wget -y


ENTRYPOINT ["bash", "/run.sh"]
