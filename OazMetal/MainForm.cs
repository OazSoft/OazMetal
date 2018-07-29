/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 08/07/2018
 * Hora: 09:51 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SQLite;
using System.Data.SQLite.Generic;
using OazUtil;

namespace OazMetal
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		protected OpcionesOazMetal Opciones = new OpcionesOazMetal();
		protected Dictionary<string,TablaDef> Datos = new Dictionary<string, TablaDef>();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			pgOpciones.SelectedObject = Opciones;
		}
		void ProcesarClick(object sender, EventArgs e)
		{
			Button bt = (Button)sender;
			switch (bt.Name) {
				case "btCancelar":
					Close();
					break;
				case "btGenerar":
					GenerarClases();
					break;
			}
		}
		void GenerarClases()
		{
			string errores = "";
			
			//	Verificar datos validos
			if (Datos.Count <= 0)
				return;
			
			//	Analizar cada tabla y generar el archivo correspondiente
			foreach (string nombreTabla in clbTablas.CheckedItems) {
				TablaDef tabla = Datos[nombreTabla];
				try {
					//Crear archivo y verificar si existe
					string archivo = Opciones.CarpetaDeSalida + "\\" + nombreTabla + ".cs";
					FileStream fs = new FileStream(archivo, FileMode.Create);
					//escribir using y encabezado de clase
					string txt = "//	Creado por: OazMetal";
					txt += "\nusing System;\nusing System.Collections.Generic;\nusing System.ComponentModel.DataAnnotations.Schema;\nusing System.Data;\nusing System.Data.Linq.Mapping;\nusing System.Linq;\n\n";
					txt += Opciones.NameSpace != ""
					? "namespace " + Opciones.NameSpace + "\n{"
					: "namespace OazMetal\n{";
					txt += "\n\n\t[Table]\n\tpublic class " + nombreTabla + "\n\t{";
				
					fs.Write(txt.GetBytes(), 0, txt.Length);
					//	escribir cada campo
					foreach (KeyValuePair<string,Type> campo in tabla) {
						txt = "\n\t\t[Column]\n\t\tpublic " + campo.Value.FullName + " " + campo.Key + " {set;get;}";
						fs.Write(txt.GetBytes(), 0, txt.Length);
					}
					//	Generar constructor basico
					txt = "\n\n\t\tpublic " + nombreTabla + "()\n\t\t{\n\t\t}";
					fs.Write(txt.GetBytes(), 0, txt.Length);
				
					//	cerrar clase y archivo
					txt = "\n\t}\n}";
					fs.Write(txt.GetBytes(), 0, txt.Length);
					fs.Close();
				
				} catch (Exception Ex) {
					errores += nombreTabla + ":\t" + Ex.Message;
				}
				
				
			}
			if (Opciones.SalirAlGenerar)
				Close();
		}
		void PgOpcionesPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			DataTable tablaT = null;
			string nombreTabla="";
			TablaDef Campos = new TablaDef();
			OleDbCommand cmdt;
			
			string cns = "";
			int cnt = 0;
			clbTablas.Items.Clear();
							
			try {
				BaseDatos.Archivo = Opciones.ArchivoBD;
				//falta implementar usuario y clave
				
				//Abre base 
				switch (Opciones.MotorBD) {
					case MotorBaseDatos.SQLite:
						{
							cns = string.Format("DataSource={0};", Opciones.ArchivoBD);
							if(Opciones.Usuario!="")
								cns+=string.Format("Usuario={0};",Opciones.Usuario);
							if(Opciones.clave!="")
								cns+=string.Format("Password={0};",Opciones.clave);
							
							SQLiteConnection SQCN = new SQLiteConnection(cns);
							SQCN.Open();
							tablaT = SQCN.GetSchema("Tables", new string[]{ });
						
							foreach (DataRow ren in tablaT.Rows) {
								try{
								nombreTabla = (string)ren.ItemArray[2];
								foreach (object c in ren.ItemArray) {
									nombreTabla = (string)ren.ItemArray[2];
							
									if (!nombreTabla.StartsWith("sqlite_")) {
									Campos = new TablaDef();
									clbTablas.Items.Add(nombreTabla);
									SQLiteCommand cmdtsq = SQCN.CreateCommand();
									cmdtsq.CommandText = string.Format("select * from {0}", nombreTabla);
									SQLiteDataReader sqDr = cmdtsq.ExecuteReader();
									for (int i = 0; i < sqDr.FieldCount; i++) {
										Campos.Add(sqDr.GetName(i), sqDr.GetFieldType(i));
									}
									Datos.Add(nombreTabla, Campos);
									sqDr.Close();
								}
						
								}
								}
								catch(Exception Ex){
									Console.WriteLine(Ex.Message);
								}
							}
						}
						break;
					case MotorBaseDatos.MsAccess:
						{
							cns = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", Opciones.ArchivoBD);
							if(Opciones.Usuario!="")
								cns+=string.Format("Usuario={0};",Opciones.Usuario);
							if(Opciones.clave!="")
								cns+=string.Format("Password={0};",Opciones.clave);
							
							OleDbConnection Cn = new OleDbConnection(cns);
							Cn.Open();
							DataTable aDT = Cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[]{ });
							Datos = new Dictionary<string, TablaDef>();
							foreach (DataRow ren in aDT.Rows) {
								nombreTabla = (string)ren.ItemArray[2];
							
								if (!nombreTabla.StartsWith("MSys")) {
									Campos = new TablaDef();
									clbTablas.Items.Add(nombreTabla);
									cmdt = Cn.CreateCommand();
									cmdt.CommandText = string.Format("select * from {0}", nombreTabla);
									OleDbDataReader aDr = cmdt.ExecuteReader();
									for (int i = 0; i < aDr.FieldCount; i++) {
										Campos.Add(aDr.GetName(i), aDr.GetFieldType(i));
									}
									Datos.Add(nombreTabla, Campos);
									aDr.Close();
								}
						
							}
						}
						break;
				}
			} catch (Exception Ex) {
				Console.WriteLine(Ex.Message);
			}
		}
	}
	
	public class TablaDef : Dictionary<string,Type>
	{
		
	}
}
