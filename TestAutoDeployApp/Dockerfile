#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestAutoDeployApp/TestAutoDeployApp.csproj", "TestAutoDeployApp/"]
RUN dotnet restore "TestAutoDeployApp/TestAutoDeployApp.csproj"
COPY . .
WORKDIR "/src/TestAutoDeployApp"
RUN dotnet build "TestAutoDeployApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestAutoDeployApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAutoDeployApp.dll"]