﻿namespace ReporteAnualEmpleados
{
    partial class btnBuscarRFC
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbFileDIM = new System.Windows.Forms.TextBox();
            this.btnBuscarDIM = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnBuscarBonos = new System.Windows.Forms.Button();
            this.txbFileBonos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ofdArchivo = new System.Windows.Forms.OpenFileDialog();
            this.txbAcciones = new System.Windows.Forms.TextBox();
            this.btnBuscarCatRFC = new System.Windows.Forms.Button();
            this.txbFileCatRFC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(964, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Declaración Informativa Multiple";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo DIM:";
            // 
            // txbFileDIM
            // 
            this.txbFileDIM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbFileDIM.Location = new System.Drawing.Point(390, 40);
            this.txbFileDIM.Name = "txbFileDIM";
            this.txbFileDIM.Size = new System.Drawing.Size(342, 23);
            this.txbFileDIM.TabIndex = 2;
            // 
            // btnBuscarDIM
            // 
            this.btnBuscarDIM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarDIM.Location = new System.Drawing.Point(738, 40);
            this.btnBuscarDIM.Name = "btnBuscarDIM";
            this.btnBuscarDIM.Size = new System.Drawing.Size(32, 23);
            this.btnBuscarDIM.TabIndex = 3;
            this.btnBuscarDIM.Text = "...";
            this.btnBuscarDIM.UseVisualStyleBackColor = true;
            this.btnBuscarDIM.Click += new System.EventHandler(this.btnBuscarDIM_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProcesar.Location = new System.Drawing.Point(445, 127);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(75, 26);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnBuscarBonos
            // 
            this.btnBuscarBonos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarBonos.Location = new System.Drawing.Point(738, 98);
            this.btnBuscarBonos.Name = "btnBuscarBonos";
            this.btnBuscarBonos.Size = new System.Drawing.Size(32, 23);
            this.btnBuscarBonos.TabIndex = 7;
            this.btnBuscarBonos.Text = "...";
            this.btnBuscarBonos.UseVisualStyleBackColor = true;
            this.btnBuscarBonos.Click += new System.EventHandler(this.btnBuscarBonos_Click);
            // 
            // txbFileBonos
            // 
            this.txbFileBonos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbFileBonos.Location = new System.Drawing.Point(390, 98);
            this.txbFileBonos.Name = "txbFileBonos";
            this.txbFileBonos.Size = new System.Drawing.Size(342, 23);
            this.txbFileBonos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Archivo de Bonos de Despensa:";
            // 
            // ofdArchivo
            // 
            this.ofdArchivo.FileName = "*.*";
            this.ofdArchivo.Filter = "Todos los archivos | *.*";
            // 
            // txbAcciones
            // 
            this.txbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAcciones.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAcciones.Location = new System.Drawing.Point(12, 159);
            this.txbAcciones.Multiline = true;
            this.txbAcciones.Name = "txbAcciones";
            this.txbAcciones.ReadOnly = true;
            this.txbAcciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbAcciones.Size = new System.Drawing.Size(940, 391);
            this.txbAcciones.TabIndex = 9;
            // 
            // btnBuscarCatRFC
            // 
            this.btnBuscarCatRFC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarCatRFC.Location = new System.Drawing.Point(738, 69);
            this.btnBuscarCatRFC.Name = "btnBuscarCatRFC";
            this.btnBuscarCatRFC.Size = new System.Drawing.Size(32, 23);
            this.btnBuscarCatRFC.TabIndex = 12;
            this.btnBuscarCatRFC.Text = "...";
            this.btnBuscarCatRFC.UseVisualStyleBackColor = true;
            this.btnBuscarCatRFC.Click += new System.EventHandler(this.btnBuscarCatRFC_Click);
            // 
            // txbFileCatRFC
            // 
            this.txbFileCatRFC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbFileCatRFC.Location = new System.Drawing.Point(390, 69);
            this.txbFileCatRFC.Name = "txbFileCatRFC";
            this.txbFileCatRFC.Size = new System.Drawing.Size(342, 23);
            this.txbFileCatRFC.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Catalogo de RFCs de empleados:";
            // 
            // btnBuscarRFC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 562);
            this.Controls.Add(this.btnBuscarCatRFC);
            this.Controls.Add(this.txbFileCatRFC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarBonos);
            this.Controls.Add(this.txbFileBonos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnBuscarDIM);
            this.Controls.Add(this.txbFileDIM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txbAcciones);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "btnBuscarRFC";
            this.Text = "Complemento a la declaracion informativa multiple";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFileDIM;
        private System.Windows.Forms.Button btnBuscarDIM;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnBuscarBonos;
        private System.Windows.Forms.TextBox txbFileBonos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdArchivo;
        private System.Windows.Forms.TextBox txbAcciones;
        private System.Windows.Forms.Button btnBuscarCatRFC;
        private System.Windows.Forms.TextBox txbFileCatRFC;
        private System.Windows.Forms.Label label3;
    }
}

