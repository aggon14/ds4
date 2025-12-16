using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace Semestral.Controllers
{
    [RoutePrefix("api/contabilidad")]
    public class ContabilidadApiController : ApiController
    {
        private readonly string conn =
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        [HttpGet, Route("")]
        public IHttpActionResult GetResumen()
        {
            decimal ingresos = 0;
            decimal gastos = 0;
            decimal meta = 0;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                // ===== INGRESOS =====
                SqlCommand cmdIngresos =
                    new SqlCommand("SELECT SUM(Monto) FROM Ventas", con);

                object rIngresos = cmdIngresos.ExecuteScalar();
                if (rIngresos != DBNull.Value && rIngresos != null)
                    ingresos = Convert.ToDecimal(rIngresos);

                // ===== GASTOS =====
                SqlCommand cmdGastos =
                    new SqlCommand("SELECT SUM(Monto) FROM Pagos", con);

                object rGastos = cmdGastos.ExecuteScalar();
                if (rGastos != DBNull.Value && rGastos != null)
                    gastos = Convert.ToDecimal(rGastos);

                // ===== META =====
                SqlCommand cmdMeta =
                    new SqlCommand("SELECT TOP 1 MetaMensual FROM Empresas", con);

                object rMeta = cmdMeta.ExecuteScalar();
                if (rMeta != DBNull.Value && rMeta != null)
                    meta = Convert.ToDecimal(rMeta);
            }

            return Ok(new
            {
                Ingresos = ingresos,
                Gastos = gastos,
                Fondos = ingresos - gastos,
                Meta = meta
            });
        }
    }
}
