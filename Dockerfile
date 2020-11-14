#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0.0-focal-arm64v8 AS base
ARG logpath
ENV logpath ${logpath}
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0.100-focal-arm64v8 AS build
WORKDIR /src
COPY ["source/", "MSmile/"]
RUN dotnet restore "MSmile/MSmile.Api/MSmile.Api.csproj"
COPY . .
WORKDIR "/src/MSmile"
RUN dotnet build "MSmile.Api/MSmile.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSmile.Api/MSmile.Api.csproj" -c Release -o /app/publish

FROM base AS final
VOLUME $logpath
RUN mkdir -p $logpath
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSmile.Api.dll"]
