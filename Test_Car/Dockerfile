# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Test_Car/Test_Car.API.csproj", "Test_Car/"]
COPY ["Test_Car.Ioc/Test_Car.Ioc.csproj", "Test_Car.Ioc/"]
COPY ["Test_Car.BusinessLogic/Test_Car.BusinessLogic.csproj", "Test_Car.BusinessLogic/"]
COPY ["Test_Car.Domain/Test_Car.Domain.csproj", "Test_Car.Domain/"]
COPY ["Test_Car.Infrastructure/Test_Car.Infrastructure.csproj", "Test_Car.Infrastructure/"]
RUN dotnet restore "./Test_Car/Test_Car.API.csproj"
COPY . .
WORKDIR "/src/Test_Car"
RUN dotnet build "./Test_Car.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Test_Car.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test_Car.API.dll"]