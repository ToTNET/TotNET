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

namespace BancoDeTiempoNET.Views
{
    public partial class FormBuscarServicio : Form
    {

        public FormBuscarServicio()
        {
            InitializeComponent();
            inicializarServicios();
            RefrescarCombobox();
        }

        private void inicializarServicios()
        {
            
        }

        public void RefrescarCombobox()
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                comboBoxServicios.DataSource = db.Servicio.Select(m => new { m.nombre }).Distinct().ToList();
                comboBoxServicios.DisplayMember = "Nombre de servicio";
                comboBoxServicios.ValueMember = "nombre";
                comboBoxServicios.SelectedIndex = -1;
                comboBoxServicios.AutoCompleteMode = AutoCompleteMode.Append;
                comboBoxServicios.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        //Método que rellena el datagridview con el contenido de la base de datos que queremos mostrar
        private void comboBoxServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                String nombre = "";
                if (comboBoxServicios.SelectedItem == null)
                {

                    List<Servicio> serviciosDemandante = (List<Servicio>)db.Servicio.Where(x => x.emailDemandante == FormLogin.emailUsuario || x.emailOfertante == FormLogin.emailUsuario).ToList();
                    List<Servicio> serviciosTodos = (List<Servicio>)db.Servicio.ToList();

                    List<Servicio> nombreServicios = new List<Servicio>();
                    foreach (Servicio servicio in serviciosTodos)
                    {
                        if (!serviciosDemandante.Contains(servicio)) nombreServicios.Add(servicio);
                    }

                    dataGridViewServicios.DataSource = nombreServicios.ToList();
                    this.dataGridViewServicios.Columns["emailDemandante"].Visible = false;
                    this.dataGridViewServicios.Columns["fechaRealizacion"].Visible = false;
                }
                else
                {
                    nombre = comboBoxServicios.Text;

                    List<Servicio> serviciosDemandante = (List<Servicio>) db.Servicio.Where(x => x.emailDemandante == FormLogin.emailUsuario || x.emailOfertante == FormLogin.emailUsuario).ToList();
                    List<Servicio> serviciosTodos = (List<Servicio>) db.Servicio.ToList();

                    List<Servicio> nombreServicios = new List<Servicio>();
                    foreach (Servicio servicio in serviciosTodos)
                    {
                        if (!serviciosDemandante.Contains(servicio) && servicio.nombre == nombre) nombreServicios.Add(servicio);
                    } 

                    dataGridViewServicios.DataSource = nombreServicios.ToList();
                    this.dataGridViewServicios.Columns["emailDemandante"].Visible = false;
                    this.dataGridViewServicios.Columns["fechaRealizacion"].Visible = false;
                }
            }
        }

        //Solicitar servicio
        private void buttonSolicitar_Click(object sender, EventArgs e)
        {
            //update servicio
            if (dataGridViewServicios.SelectedRows.Count > 0)
            {
                Servicio servicio = (Servicio)dataGridViewServicios.CurrentRow.DataBoundItem;

                if (Controller.balanceHoras - servicio.horas < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Usted no tiene horas para poder solicitar este servicio");
                }
                else {

                    //restar al usuario en curso las horas que ha solicitado (update usuario)
                    Usuario u = Controller.buscarUsuarioEmail(FormLogin.emailUsuario);
                    u.balanceHoras -= (float)servicio.horas;
                    Controller.modificarUsuario(u);

                    servicio.fechaRealizacion = dateTimePickerBuscarServicios.Value;
                    servicio.emailDemandante = FormLogin.emailUsuario;

                    Controller.modificarServicio(servicio);

                    //Notificacion al usuario logueado
                    Notificacion notificacion = new Notificacion();
                    notificacion.asunto = "Servicio solicitado";
                    notificacion.cuerpo = "El servicio " + servicio.nombre + " ha sido solicitado por " + servicio.emailDemandante + " a " + servicio.emailOfertante;
                    notificacion.emailDemandante = FormLogin.emailUsuario;
                    notificacion.emailOfertante = servicio.emailOfertante;
                    notificacion.fecha = dateTimePickerBuscarServicios.Value;
                    Controller.agregarNotificacion(notificacion);

                    Controller.balanceHoras -= (float)servicio.horas;
                }

                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Debe seleccionar un servicio");
            }
        }

    }

}
