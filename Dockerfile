# Contenedor para el Container Runtime de Vercel: la app escucha en $PORT.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["api.csproj", "."]
RUN dotnet restore "./api.csproj"

COPY . .
RUN dotnet publish "./api.csproj" -c Release -o /out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /out .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true
EXPOSE 3000

ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://+:${PORT:-3000} exec dotnet api.dll"]
