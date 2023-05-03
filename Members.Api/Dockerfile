#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Members.Api/Members.Api.csproj", "Members.Api/"]
COPY ["Members.Infraestrucutre/Members.Infraestrucutre.csproj", "Members.Infraestrucutre/"]
COPY ["Members.Domain/Members.Domain.csproj", "Members.Domain/"]
COPY ["Members.Service/Members.Service.csproj", "Members.Service/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Members.IServicio/Members.IServicio.csproj", "Members.IServicio/"]
RUN dotnet restore "Members.Api/Members.Api.csproj"
COPY . .
WORKDIR "/src/Members.Api"
RUN dotnet build "Members.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Members.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Members.Api.dll"]