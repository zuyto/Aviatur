FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
#init Openshift
LABEL io.k8s.display-name="ReservaVuelos" \
      io.k8s.description="Web api ReservaVuelos" \
      io.openshift.expose-services="8080:http"

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENV TZ=America/Bogota
#end Openshift

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReservaVuelos.Api/ReservaVuelos.Api.csproj", "ReservaVuelos.Api/"]
COPY ["ReservaVuelos.Application/ReservaVuelos.Application.csproj", "ReservaVuelos.Application/"]
COPY ["ReservaVuelos.Domain/ReservaVuelos.Domain.csproj", "ReservaVuelos.Domain/"]
COPY ["ReservaVuelos.Logger/ReservaVuelos.Logger.csproj", "ReservaVuelos.Logger/"]
COPY ["ReservaVuelos.Infrastructure/ReservaVuelos.Infrastructure.csproj", "ReservaVuelos.Infrastructure/"]
RUN dotnet restore "./ReservaVuelos.Api/ReservaVuelos.Api.csproj"
COPY . .
WORKDIR "/src/ReservaVuelos.Api"
RUN dotnet build "./ReservaVuelos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ReservaVuelos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservaVuelos.Api.dll"]
