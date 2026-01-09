using System;
using System.Data;
	
	
	
	
	public   class ManejadorFechas
	{
		public static DateTime ConvertirFecha(string Fecha) 
		{
				
			String Delimitador= "/";
			string[] FechaArreglo;
			DateTime FechaMDA;
			FechaArreglo = Fecha.Split(Delimitador.ToCharArray(), 3);
			int Dia, Mes, Año;
			try
			{
				Dia = Int32.Parse(FechaArreglo[0]);
				Mes = Int32.Parse(FechaArreglo[1]);
				Año = Int32.Parse(FechaArreglo[2]);
				FechaMDA = new System.DateTime(Año, Mes, Dia);
				return FechaMDA;
			}
			catch (System.NullReferenceException)
			{
				return new System.DateTime(1900, 1, 1); 
			}
			catch  (System.InvalidCastException)
			{
				return new System.DateTime(1900, 1, 1);
			}
			catch  (System.IndexOutOfRangeException )
			{
				return new System.DateTime(1900, 1, 1);
			}
			catch (System.ArgumentOutOfRangeException ) 
			{
				return new System.DateTime(1900, 1, 1);
			}
		}
	}
					
