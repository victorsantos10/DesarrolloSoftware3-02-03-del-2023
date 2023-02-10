using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace PrimerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            int personas;
            int contador = 0;
            int opcion = 0;
            Cliente cliente = new Cliente();
            Visita visita = new Visita();   

            do
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\vash2\\OneDrive\\Documentos\\Programas\\DesarrolloSoftware3 02-03 del 2023\\PrimerDemo\\Database1.mdf\";Integrated Security=True");
                connection.Open();
                
                Console.WriteLine(connection.State);

                Console.WriteLine("Ingrese Una Opcion");
                Console.WriteLine("1.-Registrar Persona");
                Console.WriteLine("2.-Mostrar Registros");
                Console.WriteLine("3.-Registrar Visitante");
                Console.WriteLine("4.-Mostrar Visitante");
                Console.WriteLine("5.-Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Cantidad de personas a ingresar: ");
                        personas = int.Parse(Console.ReadLine());
                        do
                        {
                            contador++;

                            Console.WriteLine("PERSONA NUMERO: " + contador);

                            Console.Write("Cedula: ");
                            cliente.Cedula = Console.ReadLine();

                            Console.Write("Nombre: ");
                            cliente.Name = Console.ReadLine();

                            Console.Write("Apellido: ");
                            cliente.Apellido = Console.ReadLine();

                            Console.Write("Fecha Nacimiento: ");
                            cliente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                            Console.Write("Sexo: ");
                            cliente.Sexo = Console.ReadLine();

                            //Console.Write("Fecha Ingreso: "); 
                            cliente.FechaIngreso = DateTime.Now;

                            Console.Write("Estado: ");

                            cliente.Estado = int.Parse(Console.ReadLine());

                            Console.Write("Cometario: ");
                            cliente.Comentario = Console.ReadLine();

                            //string Query = "INSERT INTO Registro (Nombre, Apellidos, FechaNacimiento, FechaIngreso, Sexo, Estado, Comentario, Cedula)" +
                              // "VALUES (@Nombre, @Apellido, @FechaDeNacimiento, @FechaDeIngreso, @Sexo, @Estado, @Comentario, @Cedula)";

                            SqlCommand comando = new SqlCommand($"InsertaDatos", connection);

                            comando.Parameters.AddWithValue("@Nombre", cliente.Name);
                            comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                            comando.Parameters.AddWithValue("@FechaDeNacimiento", cliente.FechaNacimiento);
                            comando.Parameters.AddWithValue("@FechaDeIngreso", cliente.FechaIngreso);
                            comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                            comando.Parameters.AddWithValue("@Estado", cliente.Estado);
                            comando.Parameters.AddWithValue("@Comentario", cliente.Comentario);
                            comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);

                            SqlParameter parameter = new SqlParameter();
                            //comando.Parameters.Add(parameter);
                            comando.CommandType = System.Data.CommandType.StoredProcedure;
                            comando.ExecuteNonQuery();
                            //comando.Parameters.Clear();
                        } while (contador != personas);
                        break;
                    case 2:
                        int registros = 0;
                        string Mensaje = "No hay Datos";
                        try
                        {
                            using (connection)
                            {

                                // Creating the command object
                                SqlCommand cmd = new SqlCommand("SELECT * FROM Registro", connection);

                                SqlDataReader sdr = cmd.ExecuteReader();
                                //Looping through each record
                                while (sdr.Read())
                                {
                                    registros++;
                                    Console.WriteLine(" ");
                                    Console.WriteLine("<---------------------------------------------->");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Registro Numero: " + registros);
                                    Console.WriteLine("Nombre: " + sdr[1]);
                                    Console.WriteLine("Apellido: " + sdr[2]);
                                    Console.WriteLine("Fecha de Nacimiento: " + sdr[3]);
                                    Console.WriteLine("Fecha de Registro " + sdr[4]);
                                    Console.WriteLine("Sexo: " + sdr[5]);
                                    Console.WriteLine("Cedula: " + sdr[8]);
                                    Console.WriteLine("Comentarios: " + sdr[7]);

                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(Mensaje + e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        int contador2 = 0;
                        int nroRegistros;
                        do
                        {
                            contador2++;
                            Console.WriteLine("Ingrese el numero de visitantes a ingresar: ");

                            nroRegistros = int.Parse(Console.ReadLine());

                            Console.WriteLine("Nombre del visitante: ");
                            visita.NombreVisitante = Console.ReadLine();

                            Console.WriteLine("Apellido del visitante: ");
                            visita.ApellidoVisitante = Console.ReadLine();

                            Console.Write("Localidad : ");
                            visita.Localidad = Console.ReadLine();

                            Console.Write("Digitado por: ");
                            visita.DigitadoPor = Console.ReadLine();

                            Console.Write("Razon de la vista: ");
                            visita.RazonVisita = Console.ReadLine();

                            Console.Write("Tipo Documento ");
                            visita.TipoDeDocumento = Console.ReadLine();

                            Console.WriteLine("Nro del documento: ");
                            visita.NroDocumento = Console.ReadLine();

                            SqlCommand comando2 = new SqlCommand($"InsertVisita", connection);
                            comando2.Parameters.AddWithValue("@Localidad", visita.Localidad);
                            comando2.Parameters.AddWithValue("@DigitadoPor", visita.DigitadoPor);
                            comando2.Parameters.AddWithValue("@razonVisita", visita.RazonVisita);
                            comando2.Parameters.AddWithValue("@TipoDocumento", visita.TipoDeDocumento);
                            comando2.Parameters.AddWithValue("@NroDocumento", visita.NroDocumento);
                            comando2.Parameters.AddWithValue("@NombreVista", visita.NombreVisitante);
                            comando2.Parameters.AddWithValue("@ApellidoVisita", visita.ApellidoVisitante);

                            SqlParameter parameter2 = new SqlParameter();

                            comando2.CommandType = System.Data.CommandType.StoredProcedure;
                            comando2.ExecuteNonQuery();
                            //comando2.Parameters.Clear();

                        } while (contador2!=nroRegistros);
                        break;
                    case 4:
                        int registros2 = 0;
                        string Mensaje2 = "No hay Datos";
                        try
                        {
                            using (connection)
                            {

                                // Creating the command object
                                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Visita", connection);

                                SqlDataReader sdr2 = cmd2.ExecuteReader();
                                //Looping through each record
                                while (sdr2.Read())
                                {
                                    registros2++;
                                    Console.WriteLine(" ");
                                    Console.WriteLine("<---------------------------------------------->");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Nro Visitante: " + registros2);
                                    Console.WriteLine("Nombre del visitante: " + sdr2[7] + " " + sdr2[8]);
                                    Console.WriteLine("Localidad: " + sdr2[1]);
                                    Console.WriteLine("Fecha de la visita: " + sdr2[2]);
                                    Console.WriteLine("Razon de la visita: " + sdr2[3]);
                                    Console.WriteLine("Digitado por " + sdr2[4]);
                                    Console.WriteLine("Tipo de Documento: " + sdr2[5]);
                                    Console.WriteLine("Nro del documento: " + sdr2[6] ) ;
                                 

                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(Mensaje2 + e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
                 Console.Clear();
            } while (opcion != 6);
            

            
          
           
        }
    }
}
