using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using Semestral.Models;

namespace Semestral.Controllers
{
    [RoutePrefix("api/ventas")]
    public class VentasApiController : ApiController
    {
         private readonly string conn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var lista = new List<Venta>();
            using (var con = new SqlConnection(conn))
            {
                con.Open();
                var q = "SELECT Id, Fecha, Monto, EmpleadoId FROM Ventas ORDER BY Fecha DESC";
                using (var cmd = new SqlCommand(q, con))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Venta
                        {
                            Id = (int)dr["Id"],
                            Fecha = (System.DateTime)dr["Fecha"],
                            Monto = (decimal)dr["Monto"],
                            EmpleadoId = dr["EmpleadoId"] == System.DBNull.Value ? (int?)null : (int)dr["EmpleadoId"]
                        });
                    }
                }
            }
            return Ok(lista);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] Venta v)
        {
            using (var con = new SqlConnection(conn))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    // Insert venta
                    var q1 = "INSERT INTO Ventas (Fecha, Monto, EmpleadoId) VALUES (@Fecha,@Monto,@EmpleadoId)";
                    using (var cmd = new SqlCommand(q1, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@Fecha", v.Fecha == System.DateTime.MinValue ? System.DateTime.Now : v.Fecha);
                        cmd.Parameters.AddWithValue("@Monto", v.Monto);
                        if (v.EmpleadoId.HasValue) cmd.Parameters.AddWithValue("@EmpleadoId", v.EmpleadoId.Value);
                        else cmd.Parameters.AddWithValue("@EmpleadoId", System.DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert ingreso
                    var q2 = "INSERT INTO Ingresos (Fecha, Monto, Origen) VALUES (@Fecha,@Monto,@Origen)";
                    using (var cmd2 = new SqlCommand(q2, con, tran))
                    {
                        cmd2.Parameters.AddWithValue("@Fecha", System.DateTime.Now);
                        cmd2.Parameters.AddWithValue("@Monto", v.Monto);
                        cmd2.Parameters.AddWithValue("@Origen", "Venta");
                        cmd2.ExecuteNonQuery();
                    }

                    // Update empresa fondos
                    var q3 = "UPDATE Empresas SET FondosActuales = FondosActuales + @Monto";
                    using (var cmd3 = new SqlCommand(q3, con, tran))
                    {
                        cmd3.Parameters.AddWithValue("@Monto", v.Monto);
                        cmd3.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
            }

            return Ok(new { mensaje = "Venta registrada" });
        }
    }
}
