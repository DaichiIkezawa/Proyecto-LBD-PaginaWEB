using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;

namespace test_2.Controllers
{

    public class FuncionesController : Controller
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public decimal CalcularSalarioTotal(int restauranteId)
        {
            // Conectar a la base de datos Oracle
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                // Crear un comando para ejecutar la función
                OracleCommand command = new OracleCommand("C##finnk.calcular_salario_total", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Agregar el parámetro del ID del restaurante
                OracleParameter parameter = new OracleParameter("restaurante_id", OracleDbType.Int32);
                parameter.Value = restauranteId;
                command.Parameters.Add(parameter);

                // Ejecutar la función y obtener el salario total
                return (decimal)command.ExecuteScalar();
            }
        }
        public decimal CalcularPromedioVentasDiarias(int restauranteId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.calcular_promedio_ventas_diarias", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter parameter = new OracleParameter("restaurante_id", OracleDbType.Int32);
                parameter.Value = restauranteId;
                command.Parameters.Add(parameter);

                return (decimal)command.ExecuteScalar();
            }
        }

        public void EmpleadosSalarioSuperior(int restauranteId, decimal salarioMinimo)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.empleados_salario_superior", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter[] parameters =
                {
                    new OracleParameter("restaurante_id", OracleDbType.Int32),
                    new OracleParameter("salario_minimo", OracleDbType.Decimal)
                };
                parameters[0].Value = restauranteId;
                parameters[1].Value = salarioMinimo;

                command.Parameters.AddRange(parameters);

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string nombreEmpleado = reader.GetString(0);
                    string apellidosEmpleado = reader.GetString(1);
                    decimal salarioEmpleado = reader.GetDecimal(2);
                    Console.WriteLine("Nombre: {0}, Apellidos: {1}, Salario: {2}", nombreEmpleado, apellidosEmpleado, salarioEmpleado);
                }
            }
        }

        public int CantReclamosEmpleado(int empleadoId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.cant_reclamos_empleado", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter parameter = new OracleParameter("empleado_id", OracleDbType.Int32);
                parameter.Value = empleadoId;
                command.Parameters.Add(parameter);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public decimal TotalVentasPorEmpleado(int restauranteId, int empleadoId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.total_ventas_por_empleado", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter[] parameters =
                {
                    new OracleParameter("restaurante_id", OracleDbType.Int32),
                    new OracleParameter("empleado_id", OracleDbType.Int32)
                };
                parameters[0].Value = restauranteId;
                parameters[1].Value = empleadoId;

                command.Parameters.AddRange(parameters);

                return (decimal)command.ExecuteScalar();
            }
        }

        public decimal TotalVentasPorRestaurante(int restauranteId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.total_ventas_por_restaurante", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter parameter = new OracleParameter("restaurante_id", OracleDbType.Int32);
                parameter.Value = restauranteId;
                command.Parameters.Add(parameter);

                return (decimal)command.ExecuteScalar();
            }
        }

        public decimal SalarioMasBajoRestaurante(int restauranteId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.salario_mas_bajo_restaurante", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter parameter = new OracleParameter("restaurante_id", OracleDbType.Int32);
                parameter.Value = restauranteId;
                command.Parameters.Add(parameter);

                return (decimal)command.ExecuteScalar();
            }
        }

        public int ObtenerExistenciasComida(int restauranteId, int comidaId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.obtener_existencias_comida", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter[] parameters =
                {
                    new OracleParameter("p_id_restaurante", OracleDbType.Int32),
                    new OracleParameter("p_id_comida", OracleDbType.Int32)
                };
                parameters[0].Value = restauranteId;
                parameters[1].Value = comidaId;

                command.Parameters.AddRange(parameters);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public string ClienteConMasReclamos()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.cliente_con_mas_reclamos", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                return (string)command.ExecuteScalar();
            }
        }

        public string EmpleadoMasReclamos(int restauranteId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.empleado_mas_reclamos", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter parameter = new OracleParameter("restaurante_id", OracleDbType.Int32);
                parameter.Value = restauranteId;
                command.Parameters.Add(parameter);

                return (string)command.ExecuteScalar();
            }
        }

        public string EmpleadoReciente(int restauranteId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.empleado_reciente", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter parameter = new OracleParameter("restaurante_id", OracleDbType.Int32);
                parameter.Value = restauranteId;
                command.Parameters.Add(parameter);

                return (string)command.ExecuteScalar();
            }
        }

        public decimal VentasRestauranteDiaria(int restauranteId, DateTime fechaVenta)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.ventas_restaurante_diaria", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter[] parameters =
                {
                    new OracleParameter("restaurante_id", OracleDbType.Int32),
                    new OracleParameter("fecha_venta_in", OracleDbType.Date)
                };
                parameters[0].Value = restauranteId;
                parameters[1].Value = fechaVenta;

                command.Parameters.AddRange(parameters);

                return (decimal)command.ExecuteScalar();
            }
        }

        public int ReclamosUltimoMes()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.reclamos_ultimo_mes", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                return (int)command.ExecuteScalar();
            }
        }

        public string RestauranteMenorVentas(DateTime fechaConsulta)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.restaurante_menor_ventas", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                OracleParameter parameter = new OracleParameter("fecha_consulta", OracleDbType.Date);
                parameter.Value = fechaConsulta;
                command.Parameters.Add(parameter);

                return (string)command.ExecuteScalar();
            }
        }

        public decimal PromedioPreciosComidas()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand("C##finnk.promedio_precios_comidas", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                return (decimal)command.ExecuteScalar();
            }
        }

    }

}
