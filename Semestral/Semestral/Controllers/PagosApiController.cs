using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace Semestral.Controllers
{
    [RoutePrefix("api/pagos")]
    public class PagosApiController : ApiController
    {
        private readonly string conn =
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        // 🔹 LISTAR PAGOS
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var lista = new List<object>();

            using (SqlConnection cn = new SqlConnection(conn))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        p.Id,
                        e.Nombre,
                        p.Monto,
                        p.FechaPago
                    FROM Pagos p
                    INNER JOIN Empleados e ON e.Id = p.EmpleadoId
                    ORDER BY p.FechaPago DESC
                ", cn);

                var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lista.Add(new
                    {
                        Id = (int)rd["Id"],
                        Empleado = rd["Nombre"].ToString(),
                        Monto = (decimal)rd["Monto"],
                        Fecha = rd["FechaPago"] == DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(rd["FechaPago"])
                    });
                }
            }

            return Ok(lista);
        }

        // 🔹 PAGAR EMPLEADO
        [HttpPost, Route("pagar")]
        public IHttpActionResult Pagar(int empleadoId)
        {
            using (SqlConnection cn = new SqlConnection(conn))
            {
                cn.Open();

                // 1️⃣ EMPLEADO
                SqlCommand c1 = new SqlCommand(
                    "SELECT SalarioPorHora, HorasTrabajadas FROM Empleados WHERE Id=@id", cn);
                c1.Parameters.AddWithValue("@id", empleadoId);

                var rd = c1.ExecuteReader();
                if (!rd.Read())
                    return BadRequest("Empleado no existe");

                decimal salario = (decimal)rd["SalarioPorHora"];
                decimal horas = (decimal)rd["HorasTrabajadas"];
                rd.Close();

                decimal monto = salario * horas;

                // 2️⃣ EMPRESA
                SqlCommand c2 = new SqlCommand(
                    "SELECT TOP 1 Id, FondosActuales FROM Empresas", cn);

                var rd2 = c2.ExecuteReader();
                if (!rd2.Read())
                    return BadRequest("Empresa no encontrada");

                int empresaId = (int)rd2["Id"];
                decimal fondos = (decimal)rd2["FondosActuales"];
                rd2.Close();

                if (fondos < monto)
                    return BadRequest("Fondos insuficientes");

                // 3️⃣ REGISTRAR PAGO
                SqlCommand c3 = new SqlCommand(@"
                    INSERT INTO Pagos (EmpleadoId, Monto, FechaPago)
                    VALUES (@e, @m, GETDATE())", cn);

                c3.Parameters.AddWithValue("@e", empleadoId);
                c3.Parameters.AddWithValue("@m", monto);
                c3.ExecuteNonQuery();

                // 4️⃣ DESCONTAR FONDOS
                SqlCommand c4 = new SqlCommand(
                    "UPDATE Empresas SET FondosActuales = FondosActuales - @m WHERE Id=@id", cn);

                c4.Parameters.AddWithValue("@m", monto);
                c4.Parameters.AddWithValue("@id", empresaId);
                c4.ExecuteNonQuery();

                // 5️⃣ REINICIAR HORAS (🔥 LO QUE FALTABA 🔥)
                SqlCommand c5 = new SqlCommand(
                    "UPDATE Empleados SET HorasTrabajadas = 0 WHERE Id=@id", cn);

                c5.Parameters.AddWithValue("@id", empleadoId);
                c5.ExecuteNonQuery();

                // 6️⃣ RESPUESTA CORRECTA
                return Ok(new { monto });
            }
        }
    }
}
