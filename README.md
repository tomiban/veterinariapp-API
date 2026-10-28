# veterinariapp-API

API REST en .NET 8 para la gestión de una veterinaria: mascotas, dueños, vacunas y dosis
aplicadas. El cliente web vive en [veterinariapp-FE](https://github.com/tomiban/veterinariapp-FE)
(Angular 17 + Material UI).

## Stack

- .NET 8 / ASP.NET Core
- Entity Framework Core sobre SQL Server, con migraciones versionadas
- Patrón repositorio (`Interfaces/`, `Repository/`)
- DTOs y mappers dedicados (`DTOs/`, `Mappers/`)
- Swagger / OpenAPI para documentación interactiva
- Docker

## Estructura

| Carpeta | Responsabilidad |
| --- | --- |
| `Controllers/` | Endpoints de la API |
| `DTOs/` | Contratos de entrada y salida |
| `Mappers/` | Conversión entre entidades y DTOs |
| `Models/` | Entidades del dominio: mascota, dueño, vacuna, dosis |
| `Interfaces/` | Contratos de los repositorios |
| `Repository/` | Implementación de acceso a datos |
| `Data/` | `ApplicationDbContext` |
| `Migrations/` | Migraciones de Entity Framework Core |
| `Docs/` | Capturas de Swagger |

## Recursos

Las vacunas y las dosis cuelgan de la mascota que las recibe.

| Método | Ruta | Descripción |
| --- | --- | --- |
| `GET` | `/api/mascotas` | Lista todas las mascotas |
| `GET` | `/api/mascotas/{id}` | Obtiene una mascota |
| `POST` | `/api/mascotas` | Crea una mascota |
| `PUT` | `/api/mascotas/{id}` | Actualiza una mascota |
| `DELETE` | `/api/mascotas/{id}` | Elimina una mascota |
| `GET` | `/api/mascotas/{mascotaId}/dueño/{id}` | Obtiene el dueño de la mascota |
| `POST` | `/api/mascotas/{mascotaId}/dueño` | Asigna el dueño de la mascota |
| `GET` | `/api/mascotas/{mascotaId}/vacunas` | Lista las vacunas de la mascota |
| `GET` | `/api/mascotas/{mascotaId}/vacunas/{id}` | Obtiene una vacuna |
| `POST` | `/api/mascotas/{mascotaId}/vacunas` | Registra una vacuna |
| `PUT` | `/api/mascotas/{mascotaId}/vacunas/{id}` | Actualiza una vacuna |
| `DELETE` | `/api/mascotas/{mascotaId}/vacunas/{id}` | Elimina una vacuna |
| `POST` | `/api/mascotas/{mascotaId}/vacunas/{vacunaId}/dosis` | Registra una dosis aplicada |
| `DELETE` | `/api/mascotas/{mascotaId}/vacunas/{vacunaId}/dosis/{id}` | Elimina una dosis |

## Puesta en marcha

Requisitos: SDK de .NET 8 y una instancia de SQL Server accesible.

1. Configurá la cadena de conexión en `appsettings.json`, sección
   `ConnectionStrings:DbConnection`.
2. Aplicá las migraciones: `dotnet ef database update`.
3. Levantá la API: `dotnet run`.
4. Abrí Swagger en `/swagger` para explorar los endpoints.

### Docker

```bash
docker build -t veterinariapp-api .
docker run --rm -p 8080:8080 veterinariapp-api
```

El contenedor expone `8080` y `8081`; la cadena de conexión se pasa por configuración o
variables de entorno.

## Licencia

MIT. Ver [LICENSE](LICENSE).
