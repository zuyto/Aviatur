# Descripción del Desarrollo – Prueba Técnica .NET Senior

## 📌 Descripción

Este proyecto consiste en el diseño e implementación de una solución full stack utilizando .NET 8 y Blazor Server, aplicando principios de arquitectura limpia y arquitectura en cebolla, orientada a cumplir los requerimientos establecidos en la prueba técnica para el rol de Profesional Senior en .NET.

## 🎯 Objetivo funcional
Desarrollar una solución que permita:

Registrar reservas de vuelo, validando origen y destino contra una API externa real (AviationStack).

Consultar reservas existentes mediante un código único.

Visualizar las reservas del día en una interfaz interactiva (tipo tablero) construida con Blazor.


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
3. Debe modificar la cadena de conexión en `launchSettings.json` bajo la clave `RESERVAS_DB_CONEXION`.


## 📌 Endpoints Principales

### 🔹 Reservar

| Método | Endpoint                | Descripción      |
| ------ | ----------------------- | ---------------- |
| POST   | `/api/Reservas/CrearReserva` | Crear Reserva |
| GET   | `/api/Reservas/ObtenerReservaPorCodigo` | Consultar reserva por Código |
| GET   | `/api/Reservas/GetReservasDelDia/dia` | Consultar Reservas del dia |

**Ejemplo de petición POST:**

```json
{
  "cliente": "MAO",
  "origen": "AAA",
  "destino": "AAB",
  "fechaSalida": "2025-05-12T00:48:34.550Z"
}
```

## 🔗 Integración con API externa
Se integró el consumo de AviationStack API utilizando un cliente HTTP encapsulado en el servicio HttpServiceManager. Este componente maneja:

Construcción de URLs dinámicas.

Headers de autenticación.

Manejo centralizado de errores y logging.

Se validan los códigos IATA de origen y destino antes de registrar una reserva.

## 📦 Swagger 
```sh
https://localhost:44375/index.html
```

## 📦 Lógica de Reserva Vuelos

## 📦 Servicio `ReservaVuelosService`

Este servicio maneja la lógica de transferencias entre billeteras.

- **Validaciones Implementadas:**

  - El campo 'Cliente' es obligatorio.
  - El campo 'Cliente' no puede tener más de 100 caracteres.
  - El campo 'Origen' es obligatorio.
  - El campo 'Origen' debe tener exactamente 3 caracteres (código IATA).
  - El campo 'Destino' es obligatorio.
  - El campo 'Destino' debe tener exactamente 3 caracteres (código IATA).
  - La 'FechaSalida' debe ser igual o posterior a hoy.

## ✅ Buenas prácticas aplicadas
Principio de responsabilidad única (SRP).

Inyección de dependencias (IHttpClientFactory, ISerilogImplements).

Centralización de manejo HTTP.

Separación de lógica y presentación.

Código limpio y fácilmente testeable.

## 🧪 Pruebas

Las pruebas se realizan con **XUnit**, **Moq** y **AutoFixture**.

## 📜 Licencia

Este proyecto está bajo la licencia MIT. ¡Úsalo libremente! 🚀

Este proyecto está bajo la licencia Apache 2.0. ¡Úsalo libremente! 🚀

