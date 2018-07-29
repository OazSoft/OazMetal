/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 08/07/2018
 * Hora: 01:57 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OazMetal
{
	public class OpcionesOazMetal
	{
		[Category("Proyecto")]
		[Description("Define el espacio de nombres donde se generaran las clases")]
		public string NameSpace { set; get; }
		
		[Category("Proyecto")]
		[Description("Define la ruta donde se crearan las clases")]
		[EditorAttribute(typeof(EditorDeArchivo/*System.Windows.Forms.Design.FileNameEditor*/), typeof(System.Drawing.Design.UITypeEditor))]
		public string ArchivoBD { set; get; }
		
		[Category("Proyecto")]
		[Description("Define el motor de base de datos ")]
		public MotorBaseDatos MotorBD { set; get; }
		
		[Category("Proyecto")]
		[EditorAttribute(typeof(FolderNameEditor2), typeof(System.Drawing.Design.UITypeEditor))]
		[Description("Carpeta donde se guardaran los archivos de salida")]
		public string CarpetaDeSalida { set; get; }

		[Category("Proyecto")]
		[Description("Sobreescribir archivos de salida si existen")]
		public bool SobreEscribir { set; get; }
		
		[Category("Proyecto")]
		[Description("Genera constructor especializado, es decir incluyendo todos los campos")]
		public bool GeneraConstructorEspecializado {set;get;}
		
		[Category("Programa")]
		[Description("Termina el programa después de generar las clases")]
		public bool SalirAlGenerar {set;get;}
		
		[Category("Proyecto")]
		[Description("Prefijo que se le agregara al nombre de cada clase")]
		public string Prefijo {set;get;}
		
		[Category("Proyecto")]
		[Description("Usuario de la base de datos")]
		public string Usuario {set;get;}
		
		[Category("Proyecto")]
		[Description("Clave de acceso a la base de datos")]
		public string clave {set;get;}
		
		
		public OpcionesOazMetal()
		{
			NameSpace = "OazMetal";
			string Ruta = ".";
		}
	}
	public enum MotorBaseDatos
	{
		SQLite,
		MsAccess,
		MySQL
	}
	public class EditorDeArchivo:FileNameEditor
	{
		protected override void InitializeDialog(OpenFileDialog openFileDialog)
		{
			openFileDialog.Filter= "SQLite|*.sqlite3;*.db3|Ms Access|*.mdb;*.accdb|Todos los archivos|*.*";
			openFileDialog.Multiselect=false;
			openFileDialog.Title = "Base de datos a analizar";
			//base.InitializeDialog(openFileDialog);
		}
	}
}