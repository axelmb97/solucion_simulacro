namespace RecetasSLN.presentación
{
    partial class FrmIngresoReceta
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.ColNombreIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nupCantidad = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheff = new System.Windows.Forms.TextBox();
            this.cbIngrediente = new System.Windows.Forms.ComboBox();
            this.cbTipoReceta = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTotalIngredientes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(55, 31);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(87, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Receta #:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(106, 66);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(258, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNombreIngrediente,
            this.ColCantidad,
            this.colAcciones});
            this.dgvDetalles.Location = new System.Drawing.Point(34, 197);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.Size = new System.Drawing.Size(519, 150);
            this.dgvDetalles.TabIndex = 10;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
            // 
            // ColNombreIngrediente
            // 
            this.ColNombreIngrediente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNombreIngrediente.HeaderText = "Ingrediente";
            this.ColNombreIngrediente.Name = "ColNombreIngrediente";
            this.ColNombreIngrediente.ReadOnly = true;
            // 
            // ColCantidad
            // 
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "Acciones";
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.ReadOnly = true;
            this.colAcciones.Text = "Eliminar";
            this.colAcciones.UseColumnTextForButtonValue = true;
            // 
            // nupCantidad
            // 
            this.nupCantidad.Location = new System.Drawing.Point(287, 170);
            this.nupCantidad.Name = "nupCantidad";
            this.nupCantidad.Size = new System.Drawing.Size(156, 20);
            this.nupCantidad.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cheff:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo Receta:";
            // 
            // txtCheff
            // 
            this.txtCheff.Location = new System.Drawing.Point(106, 97);
            this.txtCheff.Name = "txtCheff";
            this.txtCheff.Size = new System.Drawing.Size(258, 20);
            this.txtCheff.TabIndex = 4;
            // 
            // cbIngrediente
            // 
            this.cbIngrediente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIngrediente.FormattingEnabled = true;
            this.cbIngrediente.Location = new System.Drawing.Point(34, 170);
            this.cbIngrediente.Name = "cbIngrediente";
            this.cbIngrediente.Size = new System.Drawing.Size(233, 21);
            this.cbIngrediente.TabIndex = 7;
            // 
            // cbTipoReceta
            // 
            this.cbTipoReceta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoReceta.FormattingEnabled = true;
            this.cbTipoReceta.Location = new System.Drawing.Point(106, 124);
            this.cbTipoReceta.Name = "cbTipoReceta";
            this.cbTipoReceta.Size = new System.Drawing.Size(201, 21);
            this.cbTipoReceta.TabIndex = 6;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(460, 168);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(93, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(192, 390);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(273, 390);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTotalIngredientes
            // 
            this.lblTotalIngredientes.AutoSize = true;
            this.lblTotalIngredientes.Location = new System.Drawing.Point(389, 359);
            this.lblTotalIngredientes.Name = "lblTotalIngredientes";
            this.lblTotalIngredientes.Size = new System.Drawing.Size(109, 13);
            this.lblTotalIngredientes.TabIndex = 11;
            this.lblTotalIngredientes.Text = "Total de ingredientes:";
            // 
            // FrmIngresoReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 419);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cbTipoReceta);
            this.Controls.Add(this.cbIngrediente);
            this.Controls.Add(this.nupCantidad);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.txtCheff);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTotalIngredientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmIngresoReceta";
            this.Text = "Nueva Receta";
            this.Load += new System.EventHandler(this.FrmIngresoReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.NumericUpDown nupCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCheff;
        private System.Windows.Forms.ComboBox cbIngrediente;
        private System.Windows.Forms.ComboBox cbTipoReceta;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTotalIngredientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombreIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colAcciones;
    }
}