using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace test_2.Controllers
{
    public class PaqueteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        //paquete 1
        public void InsertarCliente(int idCliente, string correoCliente)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("pkg_gestion_clientes.InsertarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_cliente", OracleDbType.Int32).Value = idCliente;
                    command.Parameters.Add("p_correo_cliente", OracleDbType.Varchar2).Value = correoCliente;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCliente(int idCliente, string correoCliente)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("pkg_gestion_clientes.actualizar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_cliente", OracleDbType.Int32).Value = idCliente;
                    command.Parameters.Add("p_correo_cliente", OracleDbType.Varchar2).Value = correoCliente;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCliente(int idCliente)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("pkg_gestion_clientes.eliminar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_cliente", OracleDbType.Int32).Value = idCliente;
                    command.ExecuteNonQuery();
                }
            }
        }

        //paquete 2
        public void ActualizarExistenciasComida(int idCatalogo, int existenciasComida)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_comidas.actualizarExistenciasComida", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_catalogo", OracleDbType.Int32).Value = idCatalogo;
                    command.Parameters.Add("p_existencias_comida", OracleDbType.Int32).Value = existenciasComida;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ObtenerComidasAgotadas()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_comidas.obtenerComidasAgotadas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ObtenerComidasDisponibles()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_comidas.obtenerComidaDisponibles", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        //paquete 3
        public void ContarClientes()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_contar.contarClientes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ContarRestaurantesActivos()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_contar.contarRestaurantesActivos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        //paquete 4


        public void SeleccionarRestaurantes()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_seleccion_datos.seleccionarRestaurantes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SeleccionarClientes()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_seleccion_datos.seleccionarClientes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        //paquete 5

        public void EliminarReclamo(int idReclamo)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_eliminar.kEliminarReclamo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_reclamo", OracleDbType.Int32).Value = idReclamo;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarComida(int idCatalogo)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_eliminar.eliminarComida", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_catalogo", OracleDbType.Int32).Value = idCatalogo;
                    command.ExecuteNonQuery();
                }
            }
        }

        //paquete 6
        public void ObtenerNumeroRestaurantesPorLocalidad(string localidadRestaurante, out int numeroRestaurantes)
        {
            numeroRestaurantes = 0;
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_obtener_datos.obtenerNumeroRestaurantesPorLocalidad", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_localidad_restaurante", OracleDbType.Varchar2).Value = localidadRestaurante;
                    command.Parameters.Add("p_numero_restaurantes", OracleDbType.Int32, ParameterDirection.Output);
                    command.ExecuteNonQuery();
                    numeroRestaurantes = Convert.ToInt32(command.Parameters["p_numero_restaurantes"].Value);
                }
            }
        }

        public void ObtenerEmpleadosPorRestaurante(int idRestaurante)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_obtener_datos.obtenerEmpleadosPorRestaurante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_restaurante", OracleDbType.Int32).Value = idRestaurante;
                    command.ExecuteNonQuery();
                }
            }
        }
        //paquete 7
        public void ActualizarSalarioEmpleado(int idEmpleado, decimal salarioEmpleado)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_actualizar_datos.actualizarSalarioEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_empleado", OracleDbType.Int32).Value = idEmpleado;
                    command.Parameters.Add("p_salario_empleado", OracleDbType.Decimal).Value = salarioEmpleado;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarNombreEmpleado(int idEmpleado, string nombreEmpleado)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_actualizar_datos.actualizarNombreEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_empleado", OracleDbType.Int32).Value = idEmpleado;
                    command.Parameters.Add("p_nombre_empleado", OracleDbType.Varchar2).Value = nombreEmpleado;
                    command.ExecuteNonQuery();
                }
            }
        }
        //paquete 8

        public void EliminarReclamo_Gestion(int idReclamo)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_reclamos.keliminarreclamo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_reclamo", OracleDbType.Int32).Value = idReclamo;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ObtenerTotalReclamos_Gestion(out int totalReclamos)
        {
            totalReclamos = 0;
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_reclamos.obtenertotalreclamos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_total_reclamos", OracleDbType.Int32, ParameterDirection.Output);
                    command.ExecuteNonQuery();
                    totalReclamos = Convert.ToInt32(command.Parameters["p_total_reclamos"].Value);
                }
            }
        }

        public void InsertarReclamo_Gestion(int idReclamo, string nombreReclamo, string comentarioReclamo)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_reclamos.insertarreclamo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_reclamo", OracleDbType.Int32).Value = idReclamo;
                    command.Parameters.Add("p_nombre_reclamo", OracleDbType.Varchar2).Value = nombreReclamo;
                    command.Parameters.Add("p_comentario_reclamo", OracleDbType.Varchar2).Value = comentarioReclamo;
                    command.ExecuteNonQuery();
                }
            }
        }
        //paquete 9
        public void ObtenerEmpleadosPorRestaurante_Gestion(int idRestaurante)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_empleados.obtenerempleadosporrestaurante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_restaurante", OracleDbType.Int32).Value = idRestaurante;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarSalarioEmpleado_Gestion(int idEmpleado, decimal salarioEmpleado)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_empleados.actualizarsalarioempleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_empleado", OracleDbType.Int32).Value = idEmpleado;
                    command.Parameters.Add("p_salario_empleado", OracleDbType.Decimal).Value = salarioEmpleado;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ObtenerEmpleadosPorSalarioMaximo_Gestion()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_empleados.obtenerempleadosporsalariomaximo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ObtenerEmpleadosPorSalarioMinimo_Gestion()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_empleados.obtenerempleadosporsalariominimo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarNombreEmpleado_Gestion(int idEmpleado, string nombreEmpleado)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_empleados.actualizarnombreempleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_empleado", OracleDbType.Int32).Value = idEmpleado;
                    command.Parameters.Add("p_nombre_empleado", OracleDbType.Varchar2).Value = nombreEmpleado;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ObtenerNumeroEmpleadosPorTienda_Gestion(int idRestaurante, out int numeroEmpleados)
        {
            numeroEmpleados = 0;
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_empleados.obtenernumeroempleadosportienda", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_restaurante", OracleDbType.Int32).Value = idRestaurante;
                    command.Parameters.Add("p_numero_empleados", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    numeroEmpleados = Convert.ToInt32(command.Parameters["p_numero_empleados"].Value);
                }
            }
        }
        //paquete 10
        public void ObtenerRestaurantesPorLocalidad_Gestion(string localidadRestaurante, out int numeroRestaurantes)
        {
            numeroRestaurantes = 0;
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_restaurantes_localidades.obtenerrrestaurantesporlocalidad", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_localidad_restaurante", OracleDbType.Varchar2).Value = localidadRestaurante;
                    command.Parameters.Add("p_numero_restaurantes", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    numeroRestaurantes = Convert.ToInt32(command.Parameters["p_numero_restaurantes"].Value);
                }
            }
        }

        public void InsertarRestaurante_Gestion(int idRestaurante, string localidadRestaurante, string estadoRestaurante)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_restaurantes_localidades.insertarrestaurante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_id_restaurante", OracleDbType.Int32).Value = idRestaurante;
                    command.Parameters.Add("p_localidad_restaurante", OracleDbType.Varchar2).Value = localidadRestaurante;
                    command.Parameters.Add("p_estado_restaurante", OracleDbType.Varchar2).Value = estadoRestaurante;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SeleccionarRestaurantes_Gestion()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("c##finnk.pkg_gestion_restaurantes_localidades.seleccionarrestaurantes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
