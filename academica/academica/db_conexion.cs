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
            miConexion.Open(); //abrimos la conexion
        }
        public DataSet obtenerDatos() {
            ds.Clear(); //limpiamos el dataset
            miComando.Connection = miConexion; //asignamos la conexion al comando para pueda ejecutar las consultas
            miComando.CommandText = "SELECT * FROM alumnos"; //consulta SQL

            miAdaptador.SelectCommand = miComando; //asignamos el comando al adaptador
            miAdaptador.Fill(ds, "alumnos"); //llenamos el dataset con la tabla alumnos

            return ds;
        }
        public String administrarAlumnos(String[] alumno) {
            String sql = "";
            if (alumno[0] == "nuevo") {//accion nuevo
                sql = "INSERT INTO alumnos(codigo, nombre, direccion, telefono) VALUES(" +
                    "'" + alumno[2] + "'," +
                    "'" + alumno[3] + "'," +
                    "'" + alumno[4] + "'," +
                    "'" + alumno[5] + "')";
            } else if (alumno[0] == "modificar") {
                sql = "UPDATE alumnos SET codigo='" + alumno[2] + "', nombre='" + alumno[3] + "', " +
                    "direccion='" + alumno[4] + "', telefono='" + alumno[5] + "' WHERE idAlumno=" + alumno[1];
            } else if (alumno[0] == "eliminar") {
                sql = "DELETE FROM alumnos WHERE idAlumno='" + alumno[1] + "'";
            }
            return ejecutarSQL(sql);
        }
        private string ejecutarSQL(String sql) {
            try {
                miComando.Connection = miConexion;
                miComando.CommandText = sql;
                return miComando.ExecuteNonQuery().ToString();
            } catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
