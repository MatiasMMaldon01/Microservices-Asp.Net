#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Rutine.Api/Rutine.Api.csproj", "Rutine.Api/"]
COPY ["Rutine.Infraestructure/Rutine.Infraestructure.csproj", "Rutine.Infraestructure/"]
COPY ["Rutine.Domain/Rutine.Domain.csproj", "Rutine.Domain/"]
COPY ["Rutine.IService/Rutine.IService.csproj", "Rutine.IService/"]
COPY ["Rutine.Service/Rutine.Service.csproj", "Rutine.Service/"]
RUN dotnet restore "Rutine.Api/Rutine.Api.csproj"
COPY . .
WORKDIR "/src/Rutine.Api"
RUN dotnet build "Rutine.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rutine.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rutine.Api.dll"]