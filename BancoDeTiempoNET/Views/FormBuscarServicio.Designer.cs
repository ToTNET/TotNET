
namespace BancoDeTiempoNET.Views
{
    partial class FormBuscarServicio
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewServicios = new System.Windows.Forms.DataGridView();
            this.comboBoxServicios = new System.Windows.Forms.ComboBox();
            this.buttonSolicitar = new System.Windows.Forms.Button();
            this.dateTimePickerBuscarServicios = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Servicios";
            // 
            // dataGridViewServicios
            // 
            this.dataGridViewServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServicios.Location = new System.Drawing.Point(12, 84);
            this.dataGridViewServicios.MultiSelect = false;
            this.dataGridViewServicios.Name = "dataGridViewServicios";
            this.dataGridViewServicios.ReadOnly = true;
            this.dataGridViewServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServicios.Size = new System.Drawing.Size(852, 359);
            this.dataGridViewServicios.TabIndex = 11;
            // 
            // comboBoxServicios
            // 
            this.comboBoxServicios.FormattingEnabled = true;
            this.comboBoxServicios.Location = new System.Drawing.Point(444, 39);
            this.comboBoxServicios.Name = "comboBoxServicios";
            this.comboBoxServicios.Size = new System.Drawing.Size(159, 21);
            this.comboBoxServicios.TabIndex = 15;
            this.comboBoxServicios.SelectedIndexChanged += new System.EventHandler(this.comboBoxServicios_SelectedIndexChanged);
            // 
            // buttonSolicitar
            // 
            this.buttonSolicitar.Location = new System.Drawing.Point(789, 471);
            this.buttonSolicitar.Name = "buttonSolicitar";
            this.buttonSolicitar.Size = new System.Drawing.Size(75, 23);
            this.buttonSolicitar.TabIndex = 16;
            this.buttonSolicitar.Text = "Solicitar";
            this.buttonSolicitar.UseVisualStyleBackColor = true;
            this.buttonSolicitar.Click += new System.EventHandler(this.buttonSolicitar_Click);
            // 
            // dateTimePickerBuscarServicios
            // 
            this.dateTimePickerBuscarServicios.Location = new System.Drawing.Point(568, 470);
            this.dateTimePickerBuscarServicios.Name = "dateTimePickerBuscarServicios";
            this.dateTimePickerBuscarServicios.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBuscarServicios.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Selecciona un servicio";
            // 
            // FormBuscarServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 518);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerBuscarServicios);
            this.Controls.Add(this.buttonSolicitar);
            this.Controls.Add(this.comboBoxServicios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewServicios);
            this.Name = "FormBuscarServicio";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar servicio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewServicios;
        private System.Windows.Forms.ComboBox comboBoxServicios;
        private System.Windows.Forms.Button buttonSolicitar;
        private System.Windows.Forms.DateTimePicker dateTimePickerBuscarServicios;
        private System.Windows.Forms.Label label1;
    }
}