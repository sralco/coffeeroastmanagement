#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CoffeeRoastManagement/Server/CoffeeRoastManagement.Server.csproj", "CoffeeRoastManagement/Server/"]
COPY ["CoffeeRoastManagement/Shared/CoffeeRoastManagement.Shared.csproj", "CoffeeRoastManagement/Shared/"]
COPY ["CoffeeRoastManagement/Client/CoffeeRoastManagement.Client.csproj", "CoffeeRoastManagement/Client/"]
RUN dotnet restore "CoffeeRoastManagement/Server/CoffeeRoastManagement.Server.csproj"
COPY . .
WORKDIR "/src/CoffeeRoastManagement/Server"
RUN dotnet build "CoffeeRoastManagement.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoffeeRoastManagement.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoffeeRoastManagement.Server.dll"]