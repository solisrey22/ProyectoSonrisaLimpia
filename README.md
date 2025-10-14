# ProyectoSonrisaLimpia

**ProyectoSonrisaLimpia** está desarrollado bajo una arquitectura basada en **Clean Architecture** y **Domain-Driven Design (DDD)**, utilizando principios de separación de responsabilidades, inyección de dependencias y casos de uso (CQRS/Mediator).
---

## Estructura del Proyecto

La solución está organizada en capas con responsabilidades claramente definidas:
ProyectoSonrisaLimpia
│
├── Core
│ ├── SonrisaLimpia.Aplicacion
│ ├── SonrisaLimpia.Dominio
├── Infraestructura
│ └── SonrisaLimpia.Persistencia
├── Presentacion
  └── SonrisaLimpia.API

## 1. Capa de Presentación (`SonrisaLimpia.API`)

**Responsabilidad:** Punto de entrada del sistema (API REST).

- Contiene los **Controllers** que exponen los endpoints.
- No tiene lógica de negocio.
- Utiliza el **patrón Mediator** para comunicarse con la capa de Aplicación.

##  2. Capa de Aplicación (SonrisaLimpia.Aplicacion)

**Responsabilidad:** Contiene la lógica de negocio y los casos de uso (Use Cases).
Principales componentes:

- CasosDeUso: Clases que representan una acción del negocio (CasoDeUsoObtenerListadoConsultorios).
- Contratos: Interfaces para repositorios y unidad de trabajo.
- Excepciones: Reglas de negocio personalizadas.
- Mediador: Implementa el patrón Mediator.
- RegistroServicioAplicacion.cs: Configura la inyección de dependencias.

## 3. Capa de Dominio (SonrisaLimpia.Dominio)

**Responsabilidad:** Define las entidades, reglas de negocio y objetos de valor.
Principales componentes:

- Entidades: Clases del dominio (p. ej. Consultorio).
- Enums: Enumeraciones del negocio.
- Excepciones: Excepciones específicas del dominio.
- ObjetosDeValor: Value Objects como Dirección, Telefono, etc.
**Esta capa no depende de ninguna otra. Es el núcleo puro del negocio.**

## 4. Capa de Infraestructura (Infraestructura)

**Responsabilidad:** Implementar los contratos definidos en la capa de Aplicación.

- Contiene los repositorios concretos.
- Maneja la persistencia (bases de datos, archivos, servicios externos, etc.).
- Implementa interfaces como IRepositorioConsultorios y IUnidadDeTrabajo.

## 5. Mediador y CQRS

**El proyecto utiliza un patrón Mediator/CQRS para desacoplar controladores y casos de uso:**
- IRequest → Representa una consulta o comando.
- IRequestHandler → Ejecuta la lógica del caso de uso.
- IMediator → Envía los requests al handler correspondiente.
**Esto permite que los controladores no conozcan la implementación de la lógica de negocio.**

## Flujo de Ejecución

**A continuación se describe el flujo de ejecución cuando un cliente realiza una solicitud:**
- Cliente (Swagger/Postman) envía una petición HTTP. Ejemplo: GET /api/consultorios

- Controller recibe la solicitud y envía una Query al Mediator.
- Mediator busca el Handler correspondiente y lo ejecuta.
- Caso de Uso obtiene los datos desde el Repositorio.
- Repositorio accede a la base de datos o fuente de datos.
- Los resultados se mapean a DTOs.
- Controller devuelve la respuesta al cliente.
** Los resultados se mapean a DTOs.
** Controller devuelve la respuesta al cliente.
  
