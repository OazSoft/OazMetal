/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 08/07/2018
 * Hora: 09:51 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace OazMetal
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox clbTablas;
		private System.Windows.Forms.PropertyGrid pgOpciones;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btGenerar;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label2 = new System.Windows.Forms.Label();
			this.clbTablas = new System.Windows.Forms.CheckedListBox();
			this.pgOpciones = new System.Windows.Forms.PropertyGrid();
			this.label3 = new System.Windows.Forms.Label();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btGenerar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tablas";
			// 
			// clbTablas
			// 
			this.clbTablas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.clbTablas.CheckOnClick = true;
			this.clbTablas.FormattingEnabled = true;
			this.clbTablas.Location = new System.Drawing.Point(12, 43);
			this.clbTablas.Name = "clbTablas";
			this.clbTablas.Size = new System.Drawing.Size(217, 334);
			this.clbTablas.TabIndex = 3;
			// 
			// pgOpciones
			// 
			this.pgOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.pgOpciones.Location = new System.Drawing.Point(235, 43);
			this.pgOpciones.Name = "pgOpciones";
			this.pgOpciones.Size = new System.Drawing.Size(237, 275);
			this.pgOpciones.TabIndex = 4;
			this.pgOpciones.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PgOpcionesPropertyValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(235, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Opciones";
			// 
			// btCancelar
			// 
			this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancelar.Location = new System.Drawing.Point(254, 347);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(106, 35);
			this.btCancelar.TabIndex = 5;
			this.btCancelar.Text = "Cancelar";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.ProcesarClick);
			// 
			// btGenerar
			// 
			this.btGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btGenerar.Location = new System.Drawing.Point(366, 347);
			this.btGenerar.Name = "btGenerar";
			this.btGenerar.Size = new System.Drawing.Size(106, 35);
			this.btGenerar.TabIndex = 5;
			this.btGenerar.Text = "Generar";
			this.btGenerar.UseVisualStyleBackColor = true;
			this.btGenerar.Click += new System.EventHandler(this.ProcesarClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 401);
			this.Controls.Add(this.btGenerar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.pgOpciones);
			this.Controls.Add(this.clbTablas);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.MinimumSize = new System.Drawing.Size(500, 360);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OazMetal";
			this.ResumeLayout(false);

		}
	}
}
