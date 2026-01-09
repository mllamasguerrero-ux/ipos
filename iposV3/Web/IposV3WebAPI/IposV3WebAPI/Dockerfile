#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IposV3WebAPI/IposV3WebAPI.csproj", "IposV3WebAPI/"]
RUN dotnet restore "IposV3WebAPI/IposV3WebAPI.csproj"
COPY . .
WORKDIR "/src/IposV3WebAPI"
RUN dotnet build "IposV3WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IposV3WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "IposV3WebAPI.dll"]