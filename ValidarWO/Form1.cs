using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidarWO.Runcard;
using ValidarWO.Controlador;
using ValidarWO.Modelo;

namespace ValidarWO
{
    public partial class Form1: Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {

            bool status = false;

            // Validamos que los campos no esten vacios
            if(txtPartNum.Text != string.Empty && txtWO.Text != string.Empty)
            {
                // LLenamos el metodo constructor
                Validacion val = new Validacion(txtPartNum.Text, txtRev.Text, txtWO.Text);

                // Instanciamos al controlador
                Ctrl ctrl = new Ctrl();

                string resultado = ctrl.validarCampos(val);

                if (resultado.Contains("si tiene"))
                {
                    status = true;
                    mostrarMensaje(resultado, status);
                }
                else
                {
                    mostrarMensaje(resultado, status);

                }
                
                // else de campos vacios
            }
            else
            {
                mostrarMensaje("Llene todos los ", status);
            }

        }

        // Mostrar mensaje
        public void mostrarMensaje(string mensaje, bool status)
        {

            // Validar si no hay una ventana antes

            foreach(Control control in panel1.Controls)
            {
                if(control is Form)
                {
                    // Si hay ventana la eliminamos
                    control.Dispose();
                }
            }

            Mensaje fmensaje = new Mensaje(mensaje);

            if (status)
            {
                fmensaje.BackColor = System.Drawing.Color.FromArgb(0, 127, 22); // Color verde para éxito
            }
            else
            {
                fmensaje.BackColor = System.Drawing.Color.FromArgb(196, 24, 1); // Color rojo para error

            }

            fmensaje.TopLevel = false;
            fmensaje.Parent = panel1;
            fmensaje.Size = panel1.ClientSize;
            fmensaje.Show();

        }
    }
}
