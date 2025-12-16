using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using Semestral.Models;

namespace Semestral.Controllers
{
    [RoutePrefix("api/ingresos")]
    public class IngresosApiController : ApiController
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var lista = new List<Ingreso>();
            using (var con = new SqlConnection(conn))
            {
                con.Open();
                var q = "SELECT Id, Fecha, Monto, Origen FROM Ingresos ORDER BY Fecha DESC";
                using (var cmd = new SqlCommand(q, con))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Ingreso
                        {
                            Id = (int)dr["Id"],
                            Fecha = (System.DateTime)dr["Fecha"],
                            Monto = (decimal)dr["Monto"],
                            Origen = dr["Origen"] == System.DBNull.Value ? null : dr["Origen"].ToString()
                        });
                    }
                }
            }
            return Ok(lista);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] Ingreso i)
        {
            if (i == null) return BadRequest("Ingreso vacío");
            using (var con = new SqlConnection(conn))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    var q1 = "INSERT INTO Ingresos (Fecha, Monto, Origen) VALUES (@Fecha,@Monto,@Origen)";
                    using (var cmd = new SqlCommand(q1, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@Fecha", i.Fecha == System.DateTime.MinValue ? System.DateTime.Now : i.Fecha);
                        cmd.Parameters.AddWithValue("@Monto", i.Monto);
                        cmd.Parameters.AddWithValue("@Origen", string.IsNullOrEmpty(i.Origen) ? "Manual" : i.Origen);
                        cmd.ExecuteNonQuery();
                    }
                    var q2 = "UPDATE Empresas SET FondosActuales = FondosActuales + @Monto";
                    using (var cmd2 = new SqlCommand(q2, con, tran))
                    {
                        cmd2.Parameters.AddWithValue("@Monto", i.Monto);
                        cmd2.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
            }
            return Ok(new { mensaje = "Ingreso registrado" });
        }
    }
}
