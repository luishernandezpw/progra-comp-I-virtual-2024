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
            grdDatos.DataSource = dt;

            mostrarDatos();
        }
        private void mostrarDatos() {
            txtCodigo.Text = dt.Rows[posicion].ItemArray[1].ToString();
            txtNombre.Text = dt.Rows[posicion].ItemArray[2].ToString();
            txtDireccion.Text = dt.Rows[posicion].ItemArray[3].ToString();
            txtTelefono.Text = dt.Rows[posicion].ItemArray[4].ToString();
            lblregistros.Text = (posicion + 1) + " de " + dt.Rows.Count;
            activarDesBtnNevegacion(true);
        }
        private void activarDesBtnNevegacion(Boolean estado) {
            bool est = (posicion > 0 && posicion <= dt.Rows.Count - 1) || !estado;
            btnAnterior.Enabled = est;
            btnPrimero.Enabled = est;

            btnSiguiente.Enabled = estado;
            btnUltimo.Enabled = estado;
        }
        private void habDesControles(Boolean estado) {

            grbNavegacion.Enabled = !estado;
            btnEliminar.Enabled = !estado;
        }
        private void btnSiguiente_Click(object sender, EventArgs e) {
            if(posicion<dt.Rows.Count - 1) { 
                posicion+= 1;
                mostrarDatos();
            } else {
                activarDesBtnNevegacion(false);
            }
        }
        private void btnUltimo_Click(object sender, EventArgs e) {
            posicion = dt.Rows.Count - 1;
            mostrarDatos();
        }

        private void btnPrimero_Click(object sender, EventArgs e) {
            posicion = 0;
            mostrarDatos();
        }

        private void btnAnterior_Click(object sender, EventArgs e) {
            if(posicion > 0) {
                posicion -= 1;
                mostrarDatos();
            } else {
                activarDesBtnNevegacion(true);
            }
        }
        private void limpiarCajas() {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }   
        private void btnNuevo_Click(object sender, EventArgs e) {
            if( btnNuevo.Text=="Nuevo") {
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                limpiarCajas();
                accion = "nuevo";
                habDesControles(true);
            } else {//guardar
                String[] datos = {
                    accion,
                    dt.Rows[posicion].ItemArray[0].ToString(), //idAlumno
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtDireccion.Text,
                    txtTelefono.Text
                };
                String response = objConexion.administrarAlumnos(datos);
                if (response != "1") {
                    MessageBox.Show("Error: " + response, "Registrando datos de alumnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    obtenerDatos();
                    habDesControles(false);
                    btnNuevo.Text = "Nuevo";
                    btnModificar.Text = "Modificar";
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            if (btnModificar.Text == "Modificar") {
                btnModificar.Text = "Cancelar";
                btnNuevo.Text = "Guardar";
                accion = "modificar";
                habDesControles(true);
            } else {//cancelar

                mostrarDatos();
                habDesControles(false);
                btnModificar.Text = "Modificar";
                btnNuevo.Text = "Nuevo";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Esta seguro de eliminar a: " + txtNombre.Text, "Eliminando Alumnos",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                String[] datos = {
                    "eliminar", dt.Rows[posicion].ItemArray[0].ToString(), //idAlumno
                };
                String response = objConexion.administrarAlumnos(datos);
                if (response != "1") {
                    MessageBox.Show("Error: " + response, "Eliminando datos de alumnos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                } else {
                    obtenerDatos();
                }
            }
        }
        private void filtrarDatos(String buscar) {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "codigo like '%"+ buscar +"%' OR nombre like '%"+ buscar +"%'";
            grdDatos.DataSource = dv;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e) {
            filtrarDatos(txtBuscar.Text);
            seleccionarDatos();
        }
        private void seleccionarDatos() {
            posicion = dt.Rows.IndexOf(dt.Rows.Find(grdDatos.CurrentRow.Cells["idAlumno"].Value.ToString()));
            mostrarDatos();
        }
    }
}
