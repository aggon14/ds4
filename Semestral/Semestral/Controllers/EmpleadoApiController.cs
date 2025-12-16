using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using Semestral.Models;

namespace Semestral.Controllers
{
    [RoutePrefix("api/empleado")]
    public class EmpleadosApiController : ApiController
    {
        private readonly string conn =
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var lista = new List<Empleado>();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                var cmd = new SqlCommand(
                    "SELECT Id, Nombre, SalarioPorHora, HorasTrabajadas FROM Empleados", con);

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Empleado
                    {
                        Id = (int)dr["Id"],
                        Nombre = dr["Nombre"].ToString(),
                        SalarioPorHora = (decimal)dr["SalarioPorHora"],
                        HorasTrabajadas = (decimal)dr["HorasTrabajadas"]
                    });
                }
            }
            return Ok(lista);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post(Empleado emp)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                var cmd = new SqlCommand(
                    @"INSERT INTO Empleados (Nombre, SalarioPorHora, HorasTrabajadas)
                      VALUES (@n,@s,0)", con);

                cmd.Parameters.AddWithValue("@n", emp.Nombre);
                cmd.Parameters.AddWithValue("@s", emp.SalarioPorHora);
                cmd.ExecuteNonQuery();
            }
            return Ok();
        }

        [HttpPut, Route("editar")]
        public IHttpActionResult Editar(Empleado emp)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                var cmd = new SqlCommand(
                    @"UPDATE Empleados 
                      SET Nombre=@n, SalarioPorHora=@s 
                      WHERE Id=@id", con);

                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@n", emp.Nombre);
                cmd.Parameters.AddWithValue("@s", emp.SalarioPorHora);
                cmd.ExecuteNonQuery();
            }
            return Ok();
        }
        // ELIMINAR
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Empleados WHERE Id = @id", con);

                cmd.Parameters.AddWithValue("@id", id);

                int filas = cmd.ExecuteNonQuery();

                if (filas == 0)
                    return NotFound();
            }

            return Ok();
        }


        [HttpPut, Route("{id:int}/horas")]
        public IHttpActionResult Horas(int id, [FromBody] decimal horas)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Empleados SET HorasTrabajadas=@h WHERE Id=@id", con);

                cmd.Parameters.AddWithValue("@h", horas);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}
