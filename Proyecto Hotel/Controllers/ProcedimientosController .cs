using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

using test_2.Models;

namespace test_2.Controllers
{
    public class ProcedimientosController : Controller
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public IActionResult Index()
        {
            return View();
        }
        public void InsertaCliente(int id_cliente, string email_cliente)
        {

            // Crear una conexión a la base de datos
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Crear un comando para ejecutar el procedimiento almacenado
                OracleCommand cmd = new OracleCommand("C##finnk.InsertarCliente", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Agregar los parámetros del procedimiento almacenado
                cmd.Parameters.Add("p_id_cliente", OracleDbType.Int32).Value = id_cliente;
                cmd.Parameters.Add("p_correo_cliente", OracleDbType.Varchar2).Value = email_cliente;

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();

                // Cerrar la conexión
                connection.Close();

                // Mostrar un mensaje de éxito
                Console.WriteLine("Cliente insertado correctamente!");
            }
        }

        public void ObtenerNumeroRestaurantesPorLocalidad(string localidad_restaurante, out int numero_restaurantes)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerNumeroRestaurantesPorLocalidad", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_localidad_restaurante", OracleDbType.Varchar2).Value = localidad_restaurante;
                cmd.Parameters.Add("p_numero_restaurantes", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                numero_restaurantes = Convert.ToInt32(cmd.Parameters["p_numero_restaurantes"].Value);
                connection.Close();
                Console.WriteLine("Número de restaurantes obtenidos correctamente!");
            }
        }
        public void EliminarReclamo(int id_reclamo)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.kEliminarReclamo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_reclamo", OracleDbType.Int32).Value = id_reclamo;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Reclamo eliminado correctamente!");
            }
        }
        public void ObtenerEmpleadosPorRestaurante(int id_restaurante)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerEmpleadosPorRestaurante", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_restaurante", OracleDbType.Int32).Value = id_restaurante;
                // Configura aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Empleados obtenidos por restaurante correctamente!");
            }
        }

        public void ObtenerTotalReclamos(out int total_reclamos)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerTotalReclamos", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_total_reclamos", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                total_reclamos = Convert.ToInt32(cmd.Parameters["p_total_reclamos"].Value);
                connection.Close();
                Console.WriteLine("Total de reclamos obtenidos correctamente!");
            }
        }

        public void EliminarCliente(int id_cliente)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.EliminarCliente", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_cliente", OracleDbType.Int32).Value = id_cliente;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Cliente eliminado correctamente!");
            }
        }

        public void ActualizarSalarioEmpleado(int id_empleado, decimal salario_empleado)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ActualizarSalarioEmpleado", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_empleado", OracleDbType.Int32).Value = id_empleado;
                cmd.Parameters.Add("p_salario_empleado", OracleDbType.Decimal).Value = salario_empleado;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Salario del empleado actualizado correctamente!");
            }
        }

        public void ObtenerNumeroEmpleadosPorTienda(int id_restaurante, out int numero_empleados)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerNumeroEmpleadosPorTienda", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_restaurante", OracleDbType.Int32).Value = id_restaurante;
                cmd.Parameters.Add("p_numero_empleados", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                numero_empleados = Convert.ToInt32(cmd.Parameters["p_numero_empleados"].Value);
                connection.Close();
                Console.WriteLine("Número de empleados obtenidos por tienda correctamente!");
            }
        }

        public void ObtenerClientesPorCorreo(string correo_cliente)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerClientesPorCorreo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_correo_cliente", OracleDbType.Varchar2).Value = correo_cliente;
                // Agregar aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Clientes obtenidos por correo electrónico correctamente!");
            }
        }
        public void ActualizarNombreEmpleado(int id_empleado, string nombre_empleado)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ActualizarNombreEmpleado", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_empleado", OracleDbType.Int32).Value = id_empleado;
                cmd.Parameters.Add("p_nombre_empleado", OracleDbType.Varchar2).Value = nombre_empleado;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Nombre del empleado actualizado correctamente!");
            }
        }

        public void ObtenerEmpleadosPorSalarioMaximo()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerEmpleadosPorSalarioMaximo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // Agregar aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Empleados obtenidos por salario máximo correctamente!");
            }
        }

        public void InsertarReclamo(int id_reclamo, string nombre_reclamo, string comentario_reclamo)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.InsertarReclamo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_reclamo", OracleDbType.Int32).Value = id_reclamo;
                cmd.Parameters.Add("p_nombre_reclamo", OracleDbType.Varchar2).Value = nombre_reclamo;
                cmd.Parameters.Add("p_comentario_reclamo", OracleDbType.Varchar2).Value = comentario_reclamo;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Reclamo insertado correctamente!");
            }
        }

        public void ObtenerEmpleadosPorSalarioMinimo()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerEmpleadosPorSalarioMinimo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // Agregar aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Empleados obtenidos por salario mínimo correctamente!");
            }
        }

        public void InsertarRestaurante(int id_restaurante, string localidad_restaurante, string estado_restaurante)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.InsertarRestaurante", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_restaurante", OracleDbType.Int32).Value = id_restaurante;
                cmd.Parameters.Add("p_localidad_restaurante", OracleDbType.Varchar2).Value = localidad_restaurante;
                cmd.Parameters.Add("p_estado_restaurante", OracleDbType.Varchar2).Value = estado_restaurante;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Restaurante insertado correctamente!");
            }
        }

        public void ActualizarExistenciasComida_1(int id_catalogo, int existencias_comida)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ActualizarExistenciasComida", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_catalogo", OracleDbType.Int32).Value = id_catalogo;
                cmd.Parameters.Add("p_existencias_comida", OracleDbType.Int32).Value = existencias_comida;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Existencias de comida actualizadas correctamente!");
            }
        }

        public void ObtenerComidasAgotados()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerComidasAgotados", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // Agregar aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Comidas agotadas obtenidas correctamente!");
            }
        }

        public void EliminarComida(int id_catalogo)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.EliminarComida", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_catalogo", OracleDbType.Int32).Value = id_catalogo;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Comida eliminada correctamente!");
            }
        }

        public void ObtenerComidaDisponibles()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerComidaDisponibles", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // Agregar aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Comidas disponibles obtenidas correctamente!");
            }
        }

        public void ObtenerNumeroComidas(out int numero_comidas)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ObtenerNumeroComidas", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_numero_comidas", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                numero_comidas = Convert.ToInt32(cmd.Parameters["p_numero_comidas"].Value);
                connection.Close();
                Console.WriteLine("Número de comidas obtenido correctamente!");
            }
        }

        public void ActualizarPrecioComida(int id_catalogo, decimal precio_comida)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ActualizarPrecioComida", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_catalogo", OracleDbType.Int32).Value = id_catalogo;
                cmd.Parameters.Add("p_precio_comida", OracleDbType.Decimal).Value = precio_comida;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Precio de comida actualizado correctamente!");
            }
        }

        public void ActualizarExistenciasComida_2(int id_catalogo, int existencias_comida)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ActualizarExistenciasComida", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("p_id_catalogo", OracleDbType.Int32).Value = id_catalogo;
                cmd.Parameters.Add("p_existencias_comida", OracleDbType.Int32).Value = existencias_comida;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Existencias de comida actualizadas correctamente!");
            }
        }

        public void SeleccionarClientes()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.SeleccionarClientes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // Agregar aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Clientes seleccionados correctamente!");
            }
        }

        public void ContarClientes(out int total_clientes)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ContarClientes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("v_total_clientes", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                total_clientes = Convert.ToInt32(cmd.Parameters["v_total_clientes"].Value);
                connection.Close();
                Console.WriteLine("Total de clientes contados correctamente!");
            }
        }

        public void SeleccionarRestaurantes()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.SeleccionarRestaurantes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // Agregar aquí parámetros de salida si los hay
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Restaurantes seleccionados correctamente!");
            }
        }

        public void ContarRestaurantesActivos(out int total_activos)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("C##finnk.ContarRestaurantesActivos", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("v_total_activos", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                total_activos = Convert.ToInt32(cmd.Parameters["v_total_activos"].Value);
                connection.Close();
                Console.WriteLine("Total de restaurantes activos contados correctamente!");
            }
        }
    }
}

