# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY HouseOfJordan.Api/HouseOfJordan.Api.csproj HouseOfJordan.Api/
RUN dotnet restore HouseOfJordan.Api/HouseOfJordan.Api.csproj

# Copy everything else and build
COPY HouseOfJordan.Api/ HouseOfJordan.Api/
WORKDIR /src/HouseOfJordan.Api
RUN dotnet build -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port
EXPOSE 8080

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "HouseOfJordan.Api.dll"]
