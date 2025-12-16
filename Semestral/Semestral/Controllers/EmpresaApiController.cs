using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

[RoutePrefix("api/empresa")]
public class EmpresaApiController : ApiController
{
    private readonly string conn =
        ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

    // OBTENER EMPRESA
    [HttpGet, Route("")]
    public IHttpActionResult Get()
    {
        using (SqlConnection cn = new SqlConnection(conn))
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 FondosActuales, MetaMensual FROM Empresas", cn);

            var rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                return Ok(new { FondosActuales = 0m, MetaMensual = 0m });
            }

            return Ok(new
            {
                FondosActuales = rd["FondosActuales"] == DBNull.Value ? 0m : Convert.ToDecimal(rd["FondosActuales"]),
                MetaMensual = rd["MetaMensual"] == DBNull.Value ? 0m : Convert.ToDecimal(rd["MetaMensual"])
            });
        }
    }

    // ACTUALIZAR META
    [HttpPut, Route("meta")]
    public IHttpActionResult SetMeta([FromBody] decimal meta)
    {
        using (SqlConnection cn = new SqlConnection(conn))
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(
                "UPDATE Empresas SET MetaMensual=@m", cn);
            cmd.Parameters.AddWithValue("@m", meta);
            cmd.ExecuteNonQuery();
        }
        return Ok("Meta actualizada");
    }
}
