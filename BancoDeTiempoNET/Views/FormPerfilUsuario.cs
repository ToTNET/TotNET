using BancoDeTiempoNET.Controllers;
using BancoDeTiempoNET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoDeTiempoNET.Views;
using BancoDeTiempoNET.Vistas;

namespace BancoDeTiempoNET.Views
{
    public partial class FormPerfilUsuario : Form
    {
        public FormPerfilUsuario()
        {
            InitializeComponent();
            RefrescarTodo();
        }

        protected override void OnLoad(EventArgs e)
        {
            Usuario usuario = Controller.buscarUsuarioEmail(FormLogin.emailUsuario);
            Controller.balanceHoras = (float)usuario.balanceHoras;
            RefrescarTodo();
            base.OnLoad(e);
        }

        private void RefrescarServicios()
        {
            //servicios solicitados
            dataGridViewServiciosUsuario.DataSource = Controller.listaServiciosDeUsuario(FormLogin.emailUsuario);
            dataGridViewServiciosUsuario.ClearSelection();

            //servicios ofrecidos
            dataGridViewServiciosOfrecidos.DataSource = Controller.listaServiciosDeUsuarioOfrecidos(FormLogin.emailUsuario);
            dataGridViewServiciosOfrecidos.Columns["id"].Visible = false;
            dataGridViewServiciosOfrecidos.Columns["fechaRealizacion"].Visible = false;
            dataGridViewServiciosOfrecidos.Columns["servicioRealizado"].Visible = false;
            dataGridViewServiciosOfrecidos.Columns["emailDemandante"].Visible = false;
            dataGridViewServiciosOfrecidos.Columns["emailOfertante"].Visible = false;
            dataGridViewServiciosOfrecidos.ClearSelection();

            //notificaciones
            dataGridViewNotificaciones.DataSource = Controller.listaNotificacionesDeUsuario(FormLogin.emailUsuario);
            dataGridViewNotificaciones.Columns["emailDemandante"].Visible = false;
            dataGridViewNotificaciones.Columns["emailOfertante"].Visible = false;
            dataGridViewNotificaciones.Columns["id"].Visible = false;
            dataGridViewNotificaciones.ClearSelection();


        }

        private void RefrescarNotificaciones()
        {
            dataGridViewNotificaciones.DataSource = Controller.listaNotificacionesDeUsuario(FormLogin.emailUsuario);
        }

        private void RefrescarTodo()
        {
            RefrescarServicios();
            RefrescarNotificaciones();
            Usuario usuario = Controller.buscarUsuarioEmail(FormLogin.emailUsuario);
            Controller.balanceHoras = (float)usuario.balanceHoras;
            labelHoras.Text = Controller.balanceHoras.ToString();
        }

        private void buttonNuevoServicio_Click(object sender, EventArgs e)
        {
            Vistas.FormNuevoServicio formulario = new Vistas.FormNuevoServicio();
            formulario.ShowDialog();
            RefrescarTodo();
        }

        private void buttonServicios_Click(object sender, EventArgs e)
        {
            Views.FormBuscarServicio formulario = new Views.FormBuscarServicio();
            formulario.ShowDialog();
            RefrescarTodo();
        }

        //Eliminar servicio ofrecido
        private void buttonEliminarServicio_Click(object sender, EventArgs e)
        {
            if (dataGridViewServiciosOfrecidos.SelectedRows.Count > 0)
            {
                Servicio currentServicio = (Servicio)dataGridViewServiciosOfrecidos.CurrentRow.DataBoundItem;
                
                Notificacion notificacion = new Notificacion();
                notificacion.asunto = "Servicio eliminado";
                notificacion.cuerpo = "El servicio " + currentServicio.nombre + " ha sido eliminado";
                notificacion.emailDemandante = FormLogin.emailUsuario;
                notificacion.emailOfertante = null;
                notificacion.fecha = DateTime.Today;
                Controller.agregarNotificacion(notificacion);

                //Si el servicio está realizado
                if (currentServicio.servicioRealizado == 1)
                {
                    System.Windows.Forms.MessageBox.Show("No puede eliminar un servicio ya realizado");
                }
                else //si el servicio no ha sido realizado, devolver las horas al solicitante antes de eliminar el servicio.
                {
                    String emailSolicitante = currentServicio.emailDemandante;
                    if (emailSolicitante != null)
                    {
                        Usuario u = Controller.buscarUsuarioEmail(emailSolicitante);
                        u.balanceHoras += currentServicio.horas;
                        Controller.modificarUsuario(u);
                    }
                    //eliminar servicio
                    Controller.eliminarServicio(currentServicio);
                }
                

                RefrescarTodo();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Debe seleccionar un servicio a eliminar");
            }
        }

        //Marcar servicio como realizado
        private void buttonEditarRealizacion_Click(object sender, EventArgs e)
        {
            if (dataGridViewServiciosUsuario.SelectedRows.Count > 0)
            {
                Servicio servicio = (Servicio)dataGridViewServiciosUsuario.CurrentRow.DataBoundItem;

                if (servicio.servicioRealizado == 1)
                {
                    System.Windows.Forms.MessageBox.Show("No puede editar un servicio que ya ha sido realizado");
                }
                else
                {
                    servicio.servicioRealizado = 1;
                    Controller.modificarServicio(servicio);

                    Notificacion notificacion = new Notificacion();
                    notificacion.asunto = "Servicio eliminado";
                    notificacion.cuerpo = "El servicio " + servicio.nombre + " ha sido marcado como realizado";
                    notificacion.emailDemandante = FormLogin.emailUsuario;
                    notificacion.emailOfertante = null;
                    notificacion.fecha = DateTime.Today;
                    Controller.agregarNotificacion(notificacion);

                    //sumar las horas ofrecidas al usuario ofertante (modfificar usuario)
                    Usuario u = Controller.buscarUsuarioEmail(servicio.emailOfertante);
                    u.balanceHoras += (float)servicio.horas;
                    Controller.modificarUsuario(u);
                }


                //Controller.balanceHoras -= (float)servicio.horas;
                if (Controller.balanceHoras <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("Su total de horas es igual a 0, debería ofrecer servicios");
                }

                RefrescarTodo();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Debe seleccionar un servicio");
            }
        }

        //Eliminar servicio solicitado
        private void buttonEliminarSolicitado_Click(object sender, EventArgs e)
        {
            if (dataGridViewServiciosUsuario.SelectedRows.Count > 0)
            {
                //eliminar el solicitado de la lista de solicitados y devolver al ususario las horas
                Servicio servicio = (Servicio)dataGridViewServiciosUsuario.CurrentRow.DataBoundItem;
                Controller.eliminarServicio(servicio);

                //devolver horas
                if (servicio.servicioRealizado == 0)
                {
                    Usuario u = Controller.buscarUsuarioEmail(FormLogin.emailUsuario);
                    u.balanceHoras += (float)servicio.horas;
                    Controller.balanceHoras = (float)u.balanceHoras;
                    Controller.modificarUsuario(u);
                }

                //notificacion
                Notificacion notificacion = new Notificacion();
                notificacion.asunto = "Servicio eliminado";
                notificacion.cuerpo = "El servicio " + servicio.nombre + " ha sido eliminado de tu lista";
                notificacion.emailDemandante = FormLogin.emailUsuario;
                notificacion.emailOfertante = servicio.emailOfertante;
                notificacion.fecha = DateTime.Today;
                Controller.agregarNotificacion(notificacion);

                RefrescarTodo();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Debe seleccionar un servicio que eliminar");
            }
        }

    }
}
