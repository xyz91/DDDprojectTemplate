#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MediPlus.API/MediPlus.API.csproj", "MediPlus.API/"]
COPY ["MediPlus.Service/MediPlus.Service.csproj", "MediPlus.Service/"]
COPY ["MediPlus.DTO/MediPlus.DTO.csproj", "MediPlus.DTO/"]
COPY ["MeidPlus.Repository/MeidPlus.Repository.csproj", "MeidPlus.Repository/"]
COPY ["MediPlus.Utility/MediPlus.Utility.csproj", "MediPlus.Utility/"]
COPY ["MediPlus.Domain/MediPlus.Domain.csproj", "MediPlus.Domain/"]
RUN dotnet restore "MediPlus.API/MediPlus.API.csproj"
COPY . .
WORKDIR "/src/MediPlus.API"
RUN dotnet build "MediPlus.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MediPlus.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediPlus.API.dll"]
