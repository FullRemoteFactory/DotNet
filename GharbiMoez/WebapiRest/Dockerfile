FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Exposer le port sur lequel votre application REST API sera accessible
EXPOSE 5277

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier les fichiers csproj dans les dossiers respectifs
COPY ["./TravelBookingFrance.WebApi/TravelBookingFrance.WebApi.csproj", "src/TravelBookingFrance.WebApi/"]
COPY ["./TravelBookingFrance.DTO/TravelBookingFrance.DTO.csproj", "src/TravelBookingFrance.DTO/"]
COPY ["./TravelBookingFrance.DAL/TravelBookingFrance.DAL.csproj", "src/TravelBookingFrance.DAL/"]
COPY ["./TravelBookingFrance.BLL/TravelBookingFrance.BLL.csproj", "src/TravelBookingFrance.BLL/"]

# Exécuter la restauration sur le projet API - cela déclenche également la restauration sur les projets dépendants
RUN dotnet restore "src/TravelBookingFrance.WebApi/TravelBookingFrance.WebApi.csproj"

# Copier tous les fichiers du projet
COPY . .

# Exécuter la construction sur le projet API
WORKDIR "/src/TravelBookingFrance.WebApi/"
RUN dotnet build -c Release -o /app/build

# Exécuter la publication sur le projet API
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Utiliser une image de base pour l'exécution
FROM base AS runtime
WORKDIR /app

# Copier le fichier aspnetcorentier.db dans l'image Docker
COPY --from=publish /src/TravelBookingFrance.WebApi/aspnetcorentier.db ./

# Copier les fichiers publiés dans l'image
COPY --from=publish /app/publish .

# Vérifier la présence du fichier dans le répertoire de travail
RUN ls -l

# Définir l'entrée de l'application
ENTRYPOINT [ "dotnet", "TravelBookingFrance.WebApi.dll" ]
