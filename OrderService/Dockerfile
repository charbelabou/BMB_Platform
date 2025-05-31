# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all csproj files (so dotnet restore doesn't fail)
COPY Presentation/Presentation.csproj Presentation/
COPY Application/Application.csproj Application/
COPY Persistance/Persistance.csproj Persistance/
COPY Domain/Domain.csproj Domain/

# Restore
RUN dotnet restore "Presentation/Presentation.csproj"

# Copy everything else
COPY . .

# Build
WORKDIR /src/Presentation
RUN dotnet build "Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.dll"]
