#  Proyecto #2 --- API Calculadora

**Asignatura:** Desarrollo de Software IV\
**Profesor:** Regis Rivera

##  Integrantes del Grupo

-   *\[Anel Gonzalez\]*\
-   *\[Enrique Lajon\]*

------------------------------------------------------------------------

## Descripción del Proyecto

Este proyecto corresponde al **Proyecto #2**, donde se desarrolla una
**API REST en ASP.NET Web API** que expone los datos almacenados en la
base de datos utilizada en el **Proyecto #1** (Windows Forms
Calculadora).

La API permite consultar diferentes tipos de cálculos realizados, así
como agregar nuevos registros opcionalmente mediante un método POST.

------------------------------------------------------------------------

##  Tecnologías Utilizadas

-   C#\
-   ASP.NET Web API (Framework)\
-   SQL Server\
-   Visual Studio 2022\
-   Postman (para pruebas)

------------------------------------------------------------------------

##  URL Base de la API

    https://localhost:44363/


------------------------------------------------------------------------

# Endpoints Disponibles

##  GET --- Consultas

  ---------------------------------------------------------------------------------
  Descripción                            Endpoint
  -------------------------------------- ------------------------------------------
  Obtener todos los cálculos             `/api/calculadora/todos`

  Obtener todas las sumas                `/api/calculadora/sumas`

  Obtener todas las restas               `/api/calculadora/restas`

  Obtener todas las multiplicaciones     `/api/calculadora/multiplicaciones`

  Obtener todas las divisiones           `/api/calculadora/divisiones`

  Datos libres --- operaciones unitarias `/api/calculadora/operaciones-unitarias`
  (cuadrado y raíz)                      

  Estadísticas generales de la base      `/api/calculadora/estadisticas`
  ---------------------------------------------------------------------------------

------------------------------------------------------------------------

## ✔ POST --- Guardar un cálculo

  Descripción                              Endpoint
  ---------------------------------------- ----------------------------
  Guardar un cálculo en la base de datos   `/api/calculadora/guardar`

### Ejemplo JSON:

``` json
{
  "Operacion": "suma",
  "Numero1": 10,
  "Numero2": 5
}
```

------------------------------------------------------------------------

# 🛢 Base de Datos

Se utiliza la misma base del Proyecto #1.

### 📄 Tabla: Resultados

  Campo       Descripción
  ----------- -------------------------------------------------------
  Id          Identificador
  Operacion   Suma, Resta, Multiplicacion, Division, Cuadrado, Raiz
  Numero1     Primer número
  Numero2     Segundo número (o 0 para operaciones unitarias)
  Resultado   Resultado del cálculo
  Fecha       Fecha de registro automática

------------------------------------------------------------------------
