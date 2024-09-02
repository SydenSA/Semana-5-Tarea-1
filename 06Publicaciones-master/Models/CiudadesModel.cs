using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _06Publicaciones.config;
using System.Data.SqlClient;

namespace _06Publicaciones.Models
{
    
    class CiudadesModel
    {
        
        public int IdCiudad { get; set; }
        public string Detalle { get; set; }
        public int IdPais { get; set; }

        public DataTable todosconrelacion() {
            var cadena = "SELECT Ciudades.IdCiudad, Ciudades.Detalle as Ciudad, Paises.IdPais, Paises.Detalle AS 'Pais' FROM Ciudades INNER JOIN Paises ON Ciudades.idPais = Paises.IdPais";
            using (var cn = Conexion.GetConnection()) {
                try
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(cadena, cn);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al insertar el autor.");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el autor.");
                }
                return null;
            }      
        }

        public DataRow obtenerPorId(string idCiudad)
        {
            var cadena = "SELECT IdCiudad, Detalle, IdPais FROM Ciudades WHERE IdCiudad = @IdCiudad";
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand(cadena, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCiudad", idCiudad);
                        using (var adaptador = new SqlDataAdapter(cmd))
                        {
                            DataTable tabla = new DataTable();
                            adaptador.Fill(tabla);
                            if (tabla.Rows.Count > 0)
                            {
                                return tabla.Rows[0];
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al obtener la ciudad.");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la ciudad.");
                }
                return null;
            }
        }

        public bool actualizarCiudad(string idCiudad, string nombreCiudad, int idPais)
        {
            var cadena = "UPDATE Ciudades SET Detalle = @Detalle, IdPais = @IdPais WHERE IdCiudad = @IdCiudad";
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand(cadena, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCiudad", idCiudad);
                        cmd.Parameters.AddWithValue("@Detalle", nombreCiudad);
                        cmd.Parameters.AddWithValue("@IdPais", idPais);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al actualizar la ciudad.");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al actualizar la ciudad.");
                }
                return false;
            }
        }


    }

    //crud

}
