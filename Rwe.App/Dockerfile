#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Rwe.App/Rwe.App.csproj", "Rwe.App/"]
RUN dotnet restore "Rwe.App/Rwe.App.csproj"
COPY . .
WORKDIR "/src/Rwe.App"
RUN dotnet build "Rwe.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rwe.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rwe.App.dll"]