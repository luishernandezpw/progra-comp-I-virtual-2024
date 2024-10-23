﻿using System;
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
        public Form1() {
            InitializeComponent();
        }

        private void optSuma_Click(object sender, EventArgs e) {
            calcular();
        }

        private void optResta_Click(object sender, EventArgs e) {
            calcular();
        }

        private void optMultiplicacion_Click(object sender, EventArgs e) {
            calcular();
        }

        private void optDivision_Click(object sender, EventArgs e) {
            calcular();
        }

        private void calcular() {
            double n = 0;
            try {
                erpCalculadora.Clear();
                double num1 = Double.Parse(txtNum1.Text);
                double num2 = Double.Parse(txtNum2.Text);
                double respuesta = 0;
                String operacion = "";
                if (optSuma.Checked) {
                    respuesta = num1 + num2;
                    operacion = "suma";
                }
                if (optResta.Checked) {
                    respuesta = num1 - num2;
                    operacion = "resta";
                }
                if (optMultiplicacion.Checked) {
                    respuesta = num1 * num2;
                    operacion = "multiplicación";
                }
                if (optDivision.Checked) {
                    respuesta = num1 / num2;
                    operacion = "división";
                }
                lblRespuesta.Text = "La " + operacion + " es igual a: " + respuesta;
            } catch (Exception e) {
                //e.Message
                /*txtNum1.Text = "";
                txtNum2.Text = "";*/

                if (txtNum1.Text.Trim() == "" || 
                    !Double.TryParse(txtNum1.Text, out n)) {
                    erpCalculadora.SetError(txtNum1, "Por favor ingrese el primer numero");
                }
                if (txtNum2.Text.Trim() == "" || 
                    !Double.TryParse(txtNum2.Text, out n)) {
                    erpCalculadora.SetError(txtNum2, "Por favor ingrese el segundo numero");
                }
                lblRespuesta.Text = "Por favor ingrese los numero solicitados ";
            }
        }
    }
}
