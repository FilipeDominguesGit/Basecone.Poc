#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Interface/Worker/Basecone.Poc.Worker/Basecone.Poc.Worker.csproj", "src/Interface/Worker/Basecone.Poc.Worker/"]
RUN dotnet restore "src/Interface/Worker/Basecone.Poc.Worker/Basecone.Poc.Worker.csproj"
COPY . .
WORKDIR "/src/src/Interface/Worker/Basecone.Poc.Worker"
RUN dotnet build "Basecone.Poc.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basecone.Poc.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basecone.Poc.Worker.dll"]
