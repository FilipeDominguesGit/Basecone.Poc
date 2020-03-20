#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Interface/Api/Basecone.Poc.Api/Basecone.Poc.Api.csproj", "src/Interface/Api/Basecone.Poc.Api/"]
RUN dotnet restore "src/Interface/Api/Basecone.Poc.Api/Basecone.Poc.Api.csproj"
COPY . .
WORKDIR "/src/src/Interface/Api/Basecone.Poc.Api"
RUN dotnet build "Basecone.Poc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basecone.Poc.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basecone.Poc.Api.dll"]
