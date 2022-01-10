using System;
using System.Windows.Forms;
using BancoDeTiempoNET.Controllers;
using BancoDeTiempoNET.Models;
using BancoDeTiempoNET.Views;

namespace BancoDeTiempoNET.Vistas
{
    public partial class FormNuevoServicio : Form
    {
        Servicio servicio = null;
        enum Servicios
        {
            Carpinteria,
            Fontaneria,
            Mecanica,
            Programacion,
            Reparacion_informatica,
            Obras,
            Limpieza,
            Educacion,
            Guarderia
        }

        public FormNuevoServicio()
        {
            InitializeComponent();
            comboBoxServicios.DataSource = Enum.GetValues(typeof(Servicios));
            comboBoxServicios.SelectedItem = null;
        }

        public FormNuevoServicio(Servicio servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
            CargarDatos();
        }

        private void CargarDatos()
        {
            comboBoxServicios.DataSource = Enum.GetValues(typeof(Servicios));
            comboBoxServicios.SelectedItem = null;
            textHoras.Text = this.servicio.horas.ToString();
            datetimePublicacion.Value = this.servicio.fechaPublicacion.Value;
        }

        private void GuardarDatos()
        {
            if (comboBoxServicios.Text != "" && textHoras.Text != "" && datetimePublicacion.Value != null) {
                //nuevo servicio
                Servicio servicio = new Servicio();
                servicio.nombre = comboBoxServicios.Text;
                servicio.horas = int.Parse(textHoras.Text);
                servicio.fechaRealizacion = null; // DatetimeRealizacion.Value;
                servicio.fechaPublicacion = datetimePublicacion.Value;
                servicio.servicioRealizado = 0;
                servicio.emailOfertante = FormLogin.emailUsuario;
                //servicio.emailDemandante = null;
                Controller.agregarServicio(servicio);

                //Crear notificación
                Notificacion notificacion = new Notificacion();
                notificacion.asunto = "Servicio creado";
                notificacion.cuerpo = "El servicio " + servicio.nombre + " ha sido creado";
                notificacion.emailDemandante = null;
                notificacion.emailOfertante = FormLogin.emailUsuario;
                notificacion.fecha = DateTime.Today;
                Controller.agregarNotificacion(notificacion);

                this.Close();
                this.servicio = null;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Todos los campos son requeridos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }


    }
}
