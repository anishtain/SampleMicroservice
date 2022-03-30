#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Basket/BasketMicroservice.Api/BasketMicroservice.Api.csproj", "Services/Basket/BasketMicroservice.Api/"]
RUN dotnet restore "Services/Basket/BasketMicroservice.Api/BasketMicroservice.Api.csproj"
COPY . .
WORKDIR "/src/Services/Basket/BasketMicroservice.Api"
RUN dotnet build "BasketMicroservice.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketMicroservice.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketMicroservice.Api.dll"]
