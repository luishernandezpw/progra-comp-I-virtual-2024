using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //clase para conexion a base de datos
using System.Data.SqlClient; //clase para conectarnos a SQL Server;

namespace academica {
    internal class db_conexion {
        SqlConnection miConexion = new SqlConnection();//para conectarnos a la base de datos
        SqlCommand miComando = new SqlCommand(); //para ejecutar comandos SQL en la base de datos
        SqlDataAdapter miAdaptador = new SqlDataAdapter(); //Intermediario entre la base de datos y la aplicacion
        DataSet ds = new DataSet(); //Ariquitectura de la base de datos en memoria RAM.

        public db_conexion() {
            miConexion.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db_academica.mdf;Integrated Security=True";
        }
        public DataSet obtenerDatos() {
            ds.Clear(); //limpiamos el dataset
            miComando.Connection = miConexion; //asignamos la conexion al comando para pueda ejecutar las consultas
            miComando.CommandText = "SELECT * FROM alumnos"; //consulta SQL
            miAdaptador.Fill(ds, "alumnos"); //llenamos el dataset con la tabla alumnos

            return ds;
        }
    }
}
