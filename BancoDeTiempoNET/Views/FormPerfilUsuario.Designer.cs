
namespace BancoDeTiempoNET.Views
{
    partial class FormPerfilUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEliminarServicio = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonNuevoServicio = new System.Windows.Forms.Button();
            this.dataGridViewServiciosUsuario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewServiciosOfrecidos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewNotificaciones = new System.Windows.Forms.DataGridView();
            this.buttonServicios = new System.Windows.Forms.Button();
            this.buttonEditarRealizacion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelHoras = new System.Windows.Forms.Label();
            this.buttonEliminarSolicitado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiciosUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiciosOfrecidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEliminarServicio
            // 
            this.buttonEliminarServicio.Location = new System.Drawing.Point(434, 419);
            this.buttonEliminarServicio.Name = "buttonEliminarServicio";
            this.buttonEliminarServicio.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminarServicio.TabIndex = 9;
            this.buttonEliminarServicio.Text = "Eliminar";
            this.buttonEliminarServicio.UseVisualStyleBackColor = true;
            this.buttonEliminarServicio.Click += new System.EventHandler(this.buttonEliminarServicio_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Servicios Solicitados";
            // 
            // buttonNuevoServicio
            // 
            this.buttonNuevoServicio.Location = new System.Drawing.Point(353, 419);
            this.buttonNuevoServicio.Name = "buttonNuevoServicio";
            this.buttonNuevoServicio.Size = new System.Drawing.Size(75, 23);
            this.buttonNuevoServicio.TabIndex = 6;
            this.buttonNuevoServicio.Text = "Nuevo";
            this.buttonNuevoServicio.UseVisualStyleBackColor = true;
            this.buttonNuevoServicio.Click += new System.EventHandler(this.buttonNuevoServicio_Click);
            // 
            // dataGridViewServiciosUsuario
            // 
            this.dataGridViewServiciosUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewServiciosUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServiciosUsuario.Location = new System.Drawing.Point(12, 477);
            this.dataGridViewServiciosUsuario.MultiSelect = false;
            this.dataGridViewServiciosUsuario.Name = "dataGridViewServiciosUsuario";
            this.dataGridViewServiciosUsuario.ReadOnly = true;
            this.dataGridViewServiciosUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServiciosUsuario.Size = new System.Drawing.Size(852, 175);
            this.dataGridViewServiciosUsuario.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Servicios Ofrecidos";
            // 
            // dataGridViewServiciosOfrecidos
            // 
            this.dataGridViewServiciosOfrecidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewServiciosOfrecidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServiciosOfrecidos.Location = new System.Drawing.Point(12, 238);
            this.dataGridViewServiciosOfrecidos.MultiSelect = false;
            this.dataGridViewServiciosOfrecidos.Name = "dataGridViewServiciosOfrecidos";
            this.dataGridViewServiciosOfrecidos.ReadOnly = true;
            this.dataGridViewServiciosOfrecidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServiciosOfrecidos.Size = new System.Drawing.Size(852, 175);
            this.dataGridViewServiciosOfrecidos.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Notificaciones";
            // 
            // dataGridViewNotificaciones
            // 
            this.dataGridViewNotificaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewNotificaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotificaciones.Location = new System.Drawing.Point(12, 80);
            this.dataGridViewNotificaciones.MultiSelect = false;
            this.dataGridViewNotificaciones.Name = "dataGridViewNotificaciones";
            this.dataGridViewNotificaciones.ReadOnly = true;
            this.dataGridViewNotificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNotificaciones.Size = new System.Drawing.Size(628, 113);
            this.dataGridViewNotificaciones.TabIndex = 14;
            // 
            // buttonServicios
            // 
            this.buttonServicios.Location = new System.Drawing.Point(301, 658);
            this.buttonServicios.Name = "buttonServicios";
            this.buttonServicios.Size = new System.Drawing.Size(75, 23);
            this.buttonServicios.TabIndex = 15;
            this.buttonServicios.Text = "Buscar";
            this.buttonServicios.UseVisualStyleBackColor = true;
            this.buttonServicios.Click += new System.EventHandler(this.buttonServicios_Click);
            // 
            // buttonEditarRealizacion
            // 
            this.buttonEditarRealizacion.Location = new System.Drawing.Point(382, 658);
            this.buttonEditarRealizacion.Name = "buttonEditarRealizacion";
            this.buttonEditarRealizacion.Size = new System.Drawing.Size(115, 23);
            this.buttonEditarRealizacion.TabIndex = 16;
            this.buttonEditarRealizacion.Text = "Marcar realizado";
            this.buttonEditarRealizacion.UseVisualStyleBackColor = true;
            this.buttonEditarRealizacion.Click += new System.EventHandler(this.buttonEditarRealizacion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(678, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 31);
            this.label4.TabIndex = 17;
            this.label4.Text = "Total horas:";
            // 
            // labelHoras
            // 
            this.labelHoras.AutoSize = true;
            this.labelHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHoras.Location = new System.Drawing.Point(740, 135);
            this.labelHoras.Name = "labelHoras";
            this.labelHoras.Size = new System.Drawing.Size(24, 25);
            this.labelHoras.TabIndex = 18;
            this.labelHoras.Text = "0";
            // 
            // buttonEliminarSolicitado
            // 
            this.buttonEliminarSolicitado.Location = new System.Drawing.Point(503, 658);
            this.buttonEliminarSolicitado.Name = "buttonEliminarSolicitado";
            this.buttonEliminarSolicitado.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminarSolicitado.TabIndex = 19;
            this.buttonEliminarSolicitado.Text = "Eliminar";
            this.buttonEliminarSolicitado.UseVisualStyleBackColor = true;
            this.buttonEliminarSolicitado.Click += new System.EventHandler(this.buttonEliminarSolicitado_Click);
            // 
            // FormPerfilUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 708);
            this.Controls.Add(this.buttonEliminarSolicitado);
            this.Controls.Add(this.labelHoras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonEditarRealizacion);
            this.Controls.Add(this.buttonServicios);
            this.Controls.Add(this.dataGridViewNotificaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewServiciosOfrecidos);
            this.Controls.Add(this.buttonEliminarServicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonNuevoServicio);
            this.Controls.Add(this.dataGridViewServiciosUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormPerfilUsuario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfil";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiciosUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiciosOfrecidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEliminarServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNuevoServicio;
        private System.Windows.Forms.DataGridView dataGridViewServiciosUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewServiciosOfrecidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewNotificaciones;
        private System.Windows.Forms.Button buttonServicios;
        private System.Windows.Forms.Button buttonEditarRealizacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelHoras;
        private System.Windows.Forms.Button buttonEliminarSolicitado;
    }
}