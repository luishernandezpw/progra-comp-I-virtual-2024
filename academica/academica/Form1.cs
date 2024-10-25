using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace academica {
    public partial class Form1 : Form {
        db_conexion objConexion = new db_conexion();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public int posicion = 0;
        String accion = "nuevo";

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            obtenerDatos();
        }
        private void obtenerDatos() {
            ds = objConexion.obtenerDatos();
            dt = ds.Tables["alumnos"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["idAlumno"] };
            mostrarDatos();
        }
        private void mostrarDatos() {
            txtCodigo.Text = dt.Rows[posicion].ItemArray[1].ToString();
            txtNombre.Text = dt.Rows[posicion].ItemArray[2].ToString();
            txtDireccion.Text = dt.Rows[posicion].ItemArray[3].ToString();
            txtTelefono.Text = dt.Rows[posicion].ItemArray[4].ToString();
            lblregistros.Text = (posicion + 1) + " de " + dt.Rows.Count;
        }
        private void btnSiguiente_Click(object sender, EventArgs e) {
            if(posicion<dt.Rows.Count - 1) { 
                posicion+= 1;
                mostrarDatos();

                btnAnterior.Enabled = true;
                btnPrimero.Enabled = true;
            } else {
                btnSiguiente.Enabled = false;
                btnUltimo.Enabled = false;
            }
        }
        private void btnUltimo_Click(object sender, EventArgs e) {
            posicion = dt.Rows.Count - 1;
            mostrarDatos();

            btnAnterior.Enabled = true;
            btnPrimero.Enabled = true;
        }

        private void btnPrimero_Click(object sender, EventArgs e) {
            posicion = 0;
            mostrarDatos();

            btnSiguiente.Enabled = true;
            btnUltimo.Enabled = true;
        }

        private void btnAnterior_Click(object sender, EventArgs e) {
            if(posicion > 0) {
                posicion -= 1;
                mostrarDatos();

                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            } else {
                btnAnterior.Enabled = false;
                btnPrimero.Enabled = false;
            }
            
        }
    }
}
