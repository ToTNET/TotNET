using BancoDeTiempoNET.Controllers;
using System;
using System.Windows.Forms;
using BancoDeTiempoNET.Views;
using BancoDeTiempoNET.Models;
using System.Data.Common;

namespace BancoDeTiempoNET.Views
{
    public partial class FormLogin : Form
    {
        public static String emailUsuario;

        public FormLogin()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (VerificarConexion() == false) this.Close();
            base.OnLoad(e);
        }

        public bool VerificarConexion()
        {
            using (var db = new BancoDeTiempoEntitiesNET())
            {
                DbConnection conn = db.Database.Connection;
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Sin conexión a la BBDD. La aplicación se cerrará");
                    return false;
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBoxPassword.Text != "")
            {
                String usuario = textBoxEmail.Text;
                String password = textBoxPassword.Text;
                Boolean existe = Controller.LoginUsuario(usuario, password);
                if (existe)
                {
                    emailUsuario = usuario;
                    Views.FormPerfilUsuario formulario = new Views.FormPerfilUsuario();
                    formulario.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Usuario y/o contraseña incorrectos");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Todos los campos son requeridos");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Views.FormRegistro formulario = new Views.FormRegistro();
            formulario.ShowDialog();
        }
    }
}
