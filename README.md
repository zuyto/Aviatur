# ReservaVuelos API - Sistema de Transferencias

## 📌 Descripción

Esta API REST permite gestionar las reservas de jn usuario

## 🛠️ Stack Tecnológico

- **Framework:** .NET 8
- **Arquitectura:** Clean Architecture - Onion Architecture
- **ORM:** Entity Framework Core
- **Base de Datos:** SQL Server
- **Principios de Diseño:** SOLID
- **Pruebas:** Unitarias con XUnit, Moq y AutoFixture

## 📂 Estructura del Proyecto

```
ReservaVuelosAPI/
│── ReservaVuelos.API/               # Proyecto principal (API)
│── ReservaVuelos.Application/       # Lógica de negocio (Servicios, DTOs, Validaciones)
│── ReservaVuelos.Domain/            # Entidades y contratos
│── ReservaVuelos.Infrastructure/    # Repositorios, DbContext, Persistencia
│── ReservaVuelos.Tests/             # Pruebas unitarias e integración
│── ReservaVuelos.Blazor/            # Front del API
└── README.md                 # Documentación del proyecto
```

## 🚀 Instalación y Configuración

### 1️⃣ Clonar el Repositorio

```sh
git clone https://github.com/zuyto/Aviatur.git
cd Aviatur
```

### 2️⃣ Configurar Base de Datos

1. Asegúrate de tener **SQL Server** instalado y en ejecución.
2. La cadena de conexión está en `launchSettings.json` bajo la clave `RESERVAS_DB_CONEXION`.


## 📌 Endpoints Principales

### 🔹 Transferencias

| Método | Endpoint                | Descripción      |
| ------ | ----------------------- | ---------------- |
| POST   | `/api/Reservas/CrearReserva` | Crear Reserva |
| GET   | `/api/Reservas/ObtenerReservaPorCodigo` | Consultar reserva por Código |
| GET   | `/api/Reservas/GetReservasDelDia/dia` | Consultar Reservas del dia |

**Ejemplo de petición:**

```json
{
  "cliente": "string",
  "origen": "string",
  "destino": "string",
  "fechaSalida": "2025-05-12T08:12:55.034Z"
}
```

## 📦 Lógica de Transferencias

### 🔹 Servicio `ReservaVuelosService`

Este servicio maneja la lógica de transferencias entre billeteras.

- **Validaciones Implementadas:**

  - El campo 'Cliente' es obligatorio.
  - El campo 'Cliente' no puede tener más de 100 caracteres.
  - El campo 'Origen' es obligatorio.
  - El campo 'Origen' debe tener exactamente 3 caracteres (código IATA).
  - El campo 'Destino' es obligatorio.
  - El campo 'Destino' debe tener exactamente 3 caracteres (código IATA).
  - La 'FechaSalida' debe ser igual o posterior a hoy.

## 🧪 Pruebas

Las pruebas se realizan con **XUnit**, **Moq** y **AutoFixture**.

## 📜 Licencia

Este proyecto está bajo la licencia MIT. ¡Úsalo libremente! 🚀

Este proyecto está bajo la licencia Apache 2.0. ¡Úsalo libremente! 🚀

