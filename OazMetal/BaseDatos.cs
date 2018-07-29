/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 08/07/2018
 * Hora: 01:45 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SQLite;
using System.Data.SQLite.Generic;


namespace OazMetal
{
	/// <summary>
	/// Description of BaseDatos.
	/// </summary>
	public static class BaseDatos
	{
		static string Archivo_;
		public static string Archivo {set {
				if (File.Exists(value)) {
					Archivo_ = value;
				}
			}
			get	{ return Archivo_; }
		}
		public static string Usuario{ set; get; }
		public static string Clave { set; get; }
		
		static string CNS(MotorBaseDatos motor)
		{
			string res="";
			if(Usuario == null)
				Usuario ="";
			
			if(Clave == null)
				Clave = "";
			
			if (Archivo_ != "" & File.Exists(Archivo_))
				
			{
				switch(motor){
					case MotorBaseDatos.SQLite:
						res = string.Format("Provider=SQLITEDB;DataSource={0};",Archivo_);
						if (Usuario.Trim() != "")
							res+=string.Format("user={0};",Usuario.Trim());
						if(Clave.Trim() != "")
							res += string.Format("Pasword={0};",Clave.Trim());
						break;
				}
			}
			
			return res;
		}
		public static OleDbConnection CN(MotorBaseDatos motor) {
			string cns =CNS(motor);
			OleDbConnection res = null;
			
			switch(motor){
					case MotorBaseDatos.SQLite:
					//res = (OleDbConnection)new SQLiteConnection(cns).t;
					break;
			}
			
			return res;
		}
		public static Dictionary<string,double> dicAdicionales(this Productos producto)
		{
			Dictionary<string,double> res = new Dictionary<string, double>();
			string[] ads = producto.Adicionales.Split(';');
			foreach (string ren in ads){
				string[] rens = ren.Split(',');
				res.Add(rens[0],double.Parse(rens[1]));
			};
			
			return res;
		}
	}
}

// uniformes cbta 5812709 o al cel. 6252831434
