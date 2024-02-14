# Étape de construction de l'application ASP.NET Core
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-api
WORKDIR /src

# Copie du code source de l'API REST
COPY . .

# Restauration des dépendances et construction de l'API REST
RUN dotnet restore "TravelAgencyAPI.csproj"
RUN dotnet build "TravelAgencyAPI.csproj" -c Release -o /app/build

# Publication de l'API REST
FROM build-api AS publish-api
RUN dotnet publish "TravelAgencyAPI.csproj" -c Release -o /app/publish

# Configuration de l'image pour exécuter l'API REST
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final-api
WORKDIR /app
COPY --from=publish-api /app/publish .

# Exposer le port 80 pour l'API REST
EXPOSE 80

# Variables d'environnement pour configurer l'URL de l'API GraphQL
ENV GRAPHQL_URL=http://localhost:5000/graphql

# Démarrer l'API REST
CMD ["dotnet", "TravelAgencyAPI.dll"]

# Étape de construction de l'application React
FROM node:14 AS build-frontend
WORKDIR /app

# Copie du code source du front-end React
COPY . .

# Installation des dépendances et construction du front-end React
RUN npm install
RUN npm run build

# Configuration de l'image pour exécuter le front-end React
FROM nginx:alpine AS final-frontend
COPY --from=build-frontend /app/build /usr/share/nginx/html

# Exposer le port 80 pour le front-end React
EXPOSE 80

# Démarrer nginx pour servir le front-end React
CMD ["nginx", "-g", "daemon off;"]
