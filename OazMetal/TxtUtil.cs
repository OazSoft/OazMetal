/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 02/07/2018
 * Hora: 09:10 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Text;


namespace OazUtil
{
	/// <summary>
	/// Description of TxtUtil.
	/// </summary>
	public static class TxtUtil
	{
		public static string Cod255(this string este){
			string res = "";
			foreach(char c in este){
				res += (char)(255- (int)c);
			}
			return res;
		}
		
		#region Nombres validos
		public static string ConvertirEspacios(this string este,bool QuitarEspeciales = true)
		{
			string res  = este;
			string NoValidos = "\"*&^%@\\/";
			
			while(res.Contains(" "))
				res = res.Replace(" ","_");
			if(QuitarEspeciales){
				foreach(char c in NoValidos)
					while(res.Contains(c.ToString()))
						res=res.Replace(c,'x');
			}
			return res;
		}
		#endregion
		
		#region Texto y bytes
		public static byte[] GetBytes(this string este){
			return Encoding.Default.GetBytes(este);
		}
		public static byte[] GetBytesUnicode(this string este){
			return Encoding.Unicode.GetBytes(este);
		}
		public static byte[] GetBytesUTF7(this string este){
			return Encoding.UTF7.GetBytes(este);
		}
		public static byte[] GetBytesUTF8(this string este){
			return Encoding.UTF8.GetBytes(este);
		}
		public static byte[] GetBytesUTF32(this string este){
			return Encoding.UTF32.GetBytes(este);
		}
		public static byte[] GetBytesASCII(this string este){
			return Encoding.ASCII.GetBytes(este);
		}
		public static byte[] GetBytesBigEndian(this string este){
			return Encoding.BigEndianUnicode.GetBytes(este);
		}
		public static string GetString(this byte[] este){
			return Encoding.Default.GetString(este);
		}
		public static string GetStringASCII(this byte[] este){
			return Encoding.ASCII.GetString(este);
		}
		public static string GetStringBigEndian(this byte[] este){
			return Encoding.BigEndianUnicode.GetString(este);
		}
		public static string GetStringUnicode(this byte[] este){
			return Encoding.Unicode.GetString(este);
		}
		public static string GetStringUTF7(this byte[] este){
			return Encoding.UTF7.GetString(este);
		}
		public static string GetStringUTF8(this byte[] este){
			return Encoding.UTF8.GetString(este);
		}
		public static string GetStringUTF32(this byte[] este){
			return Encoding.UTF32.GetString(este);
		}
		#endregion
		
	}
}
