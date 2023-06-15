#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RetailInMotion.OrdersManagement.Api/RetailInMotion.OrdersManagement.Api.csproj", "RetailInMotion.OrdersManagement.Api/"]
RUN dotnet restore "RetailInMotion.OrdersManagement.Api/RetailInMotion.OrdersManagement.Api.csproj"
COPY . .
WORKDIR "/src/RetailInMotion.OrdersManagement.Api"
RUN dotnet build "RetailInMotion.OrdersManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RetailInMotion.OrdersManagement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetailInMotion.OrdersManagement.Api.dll"]