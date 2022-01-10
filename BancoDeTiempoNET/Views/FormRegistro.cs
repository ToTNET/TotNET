using BancoDeTiempoNET.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeTiempoNET.Views
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBoxPassword.Text != "" && textBoxNombre.Text != "" &&
                textBox1Apellido.Text != "" && textBox2Apellido.Text != "" && textBoxTelefono.Text != "") {
                
                //agregar a login
                String email = textBoxEmail.Text;
                String password = textBoxPassword.Text;

                //agregar a usuarios
                String nombre = textBoxNombre.Text;
                String apellido1 = textBox1Apellido.Text;
                String apellido2 = textBox2Apellido.Text;
                String telefono = textBoxTelefono.Text;

                Controller.agregarUsuarioLogin(email, password, nombre, apellido1, apellido2, telefono);
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Todos los campos son requeridos");
            }
        }

    }
}
