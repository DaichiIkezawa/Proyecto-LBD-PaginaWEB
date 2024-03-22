using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using test_2.Models;

namespace test_2.Controllers
{
    public class VistasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        
        public IEnumerable<VistaCliente> ObtenerVistaCliente()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.tab_listado_clientes", db);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new VistaCliente
                    {
                        InformacionCliente = reader["Informacion_Cliente"].ToString()
                    };
                }
                db.Close();
            }
        }

        public IEnumerable<VistaEmpleado> ObtenerVistaEmpleado()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Empleados", db);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new VistaEmpleado
                    {
                        IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                        NombreEmpleado = reader["nombre_empleado"].ToString(),
                        ApellidosEmpleado = reader["apellidos_empleado"].ToString(),
                        SalarioEmpleado = Convert.ToDecimal(reader["salario_empleado"])
                    };
                }
                db.Close();
            }
        }

        public IEnumerable<VistaReclamo> ObtenerVistaReclamos()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Reclamos", db);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new VistaReclamo
                    {
                        IdCliente = Convert.ToInt32(reader["ID_Cliente"]),
                        CorreoCliente = reader["Correo_Cliente"].ToString(),
                        Reclamo = reader["Reclamo"].ToString()
                    };
                }
                db.Close();
            }
        }

        public int ObtenerTotalEmpleados()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Total_Empleados", db);
                db.Close();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int ObtenerTotalClientes()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Total_Clientes", db);
                db.Close();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public decimal ObtenerTotalSalarioEmpleados()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Empleados_Salarios", db);
                db.Close();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public IEnumerable<VistaEmpleado> ObtenerVistaEmpleadoPuesto()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Empleado_Puesto", db);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new VistaEmpleado
                    {
                        PuestoEmpleado = reader["Puesto_Empleado"].ToString(),
                        ConteoEmpleados = Convert.ToInt32(reader["Conteo_Empleados"])
                    };
                }
                db.Close();
            }
        }

        public IEnumerable<VistaEmpleado> ObtenerVistaSalariosMayMen()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Salarios_May_Men", db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new VistaEmpleado
                    {
                        IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                        NombreEmpleado = reader["nombre_empleado"].ToString(),
                        ApellidosEmpleado = reader["apellidos_empleado"].ToString(),
                        SalarioEmpleado = Convert.ToDecimal(reader["salario_empleado"])
                    };
                }
                db.Close();
            }
        }

        public IEnumerable<VistaEmpleado> ObtenerVistaEmpleadosCos()
        {
            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var cmd = new OracleCommand("SELECT * FROM C##finnk.Vista_Empleados_Cos", db);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new VistaEmpleado
                    {
                        IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                        NombreEmpleado = reader["nombre_empleado"].ToString(),
                        NacionalidadEmpleado = reader["nacionalidad_empleado"].ToString()
                    };
                }
                db.Close();
            }
        }

        public IEnumerable<VistaEmpleado> ObtenerEmpleados()
        {

            using (var db = new OracleConnection(connectionString))
            {
                db.Open();

                var command = new OracleCommand("SELECT * FROM C##finnk.Vista_Empleados_True", db);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new VistaEmpleado
                        {
                            IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                            NombreEmpleado = reader["nombre_empleado"].ToString(),
                            EstadoEmpleado_Bool = Convert.ToBoolean(reader["estado_empleado"])
                        };
                    }
                }
                db.Close();
            }
        }
    }
}
