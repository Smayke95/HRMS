#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HRMS.IdentityServer/HRMS.IdentityServer.csproj", "HRMS.IdentityServer/"]
RUN dotnet restore "HRMS.IdentityServer/HRMS.IdentityServer.csproj"
COPY . .
WORKDIR "/src/HRMS.IdentityServer"
RUN dotnet build "HRMS.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRMS.IdentityServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRMS.IdentityServer.dll"]