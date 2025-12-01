using Proyecto_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proyecto_2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/calculadora")]
    public class CalculadoraController : ApiController
    {
        // IMPORTANTE: Ajusta esta cadena de conexión según tu servidor
        private readonly string conexionBD = @"Server=.\SQLEXPRESS;Database=Proyecto1;Integrated Security=True;";

        // GET api/calculadora/todos
        [HttpGet]
        [Route("todos")]
        public IHttpActionResult GetTodosLosCalculos()
        {
            List<Calculo> calculos = new List<Calculo>();

            try
            {
                using (SqlConnection con = new SqlConnection(conexionBD))
                {
                    string query = "SELECT * FROM Resultados ORDER BY Fecha DESC";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Operacion = reader["Operacion"].ToString(),
                            Numero1 = Convert.ToDouble(reader["Numero1"]),
                            Numero2 = Convert.ToDouble(reader["Numero2"]),
                            Resultado = Convert.ToDouble(reader["Resultado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }
                    reader.Close();
                }

                return Ok(new
                {
                    success = true,
                    total = calculos.Count,
                    data = calculos
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al obtener los cálculos: " + ex.Message));
            }
        }

        // GET api/calculadora/sumas
        [HttpGet]
        [Route("sumas")]
        public IHttpActionResult GetSumas()
        {
            return GetPorOperacion("Suma");
        }

        // GET api/calculadora/restas
        [HttpGet]
        [Route("restas")]
        public IHttpActionResult GetRestas()
        {
            return GetPorOperacion("Resta");
        }

        // GET api/calculadora/multiplicaciones
        [HttpGet]
        [Route("multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            return GetPorOperacion("Multiplicacion");
        }

        // GET api/calculadora/divisiones
        [HttpGet]
        [Route("divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            return GetPorOperacion("Division");
        }

        // GET api/calculadora/operaciones-unitarias
        [HttpGet]
        [Route("operaciones-unitarias")]
        public IHttpActionResult GetOperacionesUnitarias()
        {
            List<Calculo> calculos = new List<Calculo>();

            try
            {
                using (SqlConnection con = new SqlConnection(conexionBD))
                {
                    string query = "SELECT * FROM Resultados WHERE Operacion IN ('Cuadrado', 'Raiz') ORDER BY Fecha DESC";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Operacion = reader["Operacion"].ToString(),
                            Numero1 = Convert.ToDouble(reader["Numero1"]),
                            Numero2 = Convert.ToDouble(reader["Numero2"]),
                            Resultado = Convert.ToDouble(reader["Resultado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }
                    reader.Close();
                }

                return Ok(new
                {
                    success = true,
                    total = calculos.Count,
                    operaciones = new string[] { "Cuadrado", "Raiz" },
                    data = calculos
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error: " + ex.Message));
            }
        }

        // GET api/calculadora/estadisticas
        [HttpGet]
        [Route("estadisticas")]
        public IHttpActionResult GetEstadisticas()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexionBD))
                {
                    con.Open();

                    var estadisticas = new
                    {
                        TotalCalculos = ObtenerConteo(con, "SELECT COUNT(*) FROM Resultados"),
                        TotalSumas = ObtenerConteo(con, "SELECT COUNT(*) FROM Resultados WHERE Operacion = 'Suma'"),
                        TotalRestas = ObtenerConteo(con, "SELECT COUNT(*) FROM Resultados WHERE Operacion = 'Resta'"),
                        TotalMultiplicaciones = ObtenerConteo(con, "SELECT COUNT(*) FROM Resultados WHERE Operacion = 'Multiplicacion'"),
                        TotalDivisiones = ObtenerConteo(con, "SELECT COUNT(*) FROM Resultados WHERE Operacion = 'Division'"),
                        TotalCuadrados = ObtenerConteo(con, "SELECT COUNT(*) FROM Resultados WHERE Operacion = 'Cuadrado'"),
                        TotalRaices = ObtenerConteo(con, "SELECT COUNT(*) FROM Resultados WHERE Operacion = 'Raiz'"),
                        PromedioResultados = ObtenerPromedio(con, "SELECT AVG(CAST(Resultado AS FLOAT)) FROM Resultados"),
                        ResultadoMaximo = ObtenerValor(con, "SELECT MAX(Resultado) FROM Resultados"),
                        ResultadoMinimo = ObtenerValor(con, "SELECT MIN(Resultado) FROM Resultados")
                    };

                    return Ok(new
                    {
                        success = true,
                        data = estadisticas
                    });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error: " + ex.Message));
            }
        }

        // POST api/calculadora/guardar
        [HttpPost]
        [Route("guardar")]
        public IHttpActionResult PostGuardarCalculo([FromBody] CalculoRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Los datos del cálculo son requeridos");
                }

                double resultado = 0;
                string operacion = request.Operacion.ToLower();

                // Calcular según la operación
                switch (operacion)
                {
                    case "suma":
                        resultado = request.Numero1 + request.Numero2;
                        break;
                    case "resta":
                        resultado = request.Numero1 - request.Numero2;
                        break;
                    case "multiplicacion":
                        resultado = request.Numero1 * request.Numero2;
                        break;
                    case "division":
                        if (request.Numero2 == 0)
                        {
                            return BadRequest("No se puede dividir entre cero");
                        }
                        resultado = request.Numero1 / request.Numero2;
                        break;
                    case "cuadrado":
                        resultado = request.Numero1 * request.Numero1;
                        request.Numero2 = 0;
                        break;
                    case "raiz":
                        if (request.Numero1 < 0)
                        {
                            return BadRequest("No se puede calcular la raíz de un número negativo");
                        }
                        resultado = Math.Sqrt(request.Numero1);
                        request.Numero2 = 0;
                        break;
                    default:
                        return BadRequest("Operación no válida. Use: Suma, Resta, Multiplicacion, Division, Cuadrado o Raiz");
                }

                // Guardar en la base de datos
                using (SqlConnection con = new SqlConnection(conexionBD))
                {
                    string query = "INSERT INTO Resultados (Operacion, Numero1, Numero2, Resultado) " +
                                   "VALUES (@Operacion, @Numero1, @Numero2, @Resultado); " +
                                   "SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Operacion", CapitalizarOperacion(request.Operacion));
                    cmd.Parameters.AddWithValue("@Numero1", request.Numero1);
                    cmd.Parameters.AddWithValue("@Numero2", request.Numero2);
                    cmd.Parameters.AddWithValue("@Resultado", resultado);

                    con.Open();
                    int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());

                    return Ok(new
                    {
                        success = true,
                        message = "Cálculo guardado exitosamente",
                        data = new
                        {
                            id = nuevoId,
                            operacion = CapitalizarOperacion(request.Operacion),
                            numero1 = request.Numero1,
                            numero2 = request.Numero2,
                            resultado = resultado
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al guardar el cálculo: " + ex.Message));
            }
        }

        // === MÉTODOS PRIVADOS AUXILIARES ===

        private IHttpActionResult GetPorOperacion(string operacion)
        {
            List<Calculo> calculos = new List<Calculo>();

            try
            {
                using (SqlConnection con = new SqlConnection(conexionBD))
                {
                    string query = "SELECT * FROM Resultados WHERE Operacion = @Operacion ORDER BY Fecha DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Operacion", operacion);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Operacion = reader["Operacion"].ToString(),
                            Numero1 = Convert.ToDouble(reader["Numero1"]),
                            Numero2 = Convert.ToDouble(reader["Numero2"]),
                            Resultado = Convert.ToDouble(reader["Resultado"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }
                    reader.Close();
                }

                return Ok(new
                {
                    success = true,
                    operacion = operacion,
                    total = calculos.Count,
                    data = calculos
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener {operacion}s: " + ex.Message));
            }
        }

        private int ObtenerConteo(SqlConnection con, string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            object result = cmd.ExecuteScalar();
            return result != DBNull.Value && result != null ? Convert.ToInt32(result) : 0;
        }

        private double ObtenerPromedio(SqlConnection con, string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            object result = cmd.ExecuteScalar();
            return result != DBNull.Value && result != null ? Convert.ToDouble(result) : 0;
        }

        private double ObtenerValor(SqlConnection con, string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            object result = cmd.ExecuteScalar();
            return result != DBNull.Value && result != null ? Convert.ToDouble(result) : 0;
        }

        private string CapitalizarOperacion(string operacion)
        {
            if (string.IsNullOrEmpty(operacion)) return operacion;
            return char.ToUpper(operacion[0]) + operacion.Substring(1).ToLower();
        }
    }
}