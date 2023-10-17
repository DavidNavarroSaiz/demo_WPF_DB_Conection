using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB.common;
namespace ConexionDB.Datos
{
    class PruebaDBDA
    {
        public static bool InsertarParametro(String Nombre, String Valor , String Tipo)
        {
            try
            {
                using (var DB = new PruebaDBEntities1())
                {
                    DB.usp_InsertarParametro(Nombre, Valor, Tipo);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public static bool ActualizarParametro(Parametros parameters)
        {
            try
            {
                using (var DB = new PruebaDBEntities1())
                {
                    DB.usp_ActualizarParametro(parameters.Nombre, parameters.Valor, parameters.Tipo);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static List<usp_Obtenerparametros_Result> LeerParametros(String Nombre)
        {
            List<usp_Obtenerparametros_Result> lista_parametros = new List<usp_Obtenerparametros_Result>();
            try
            {
                using (var DB = new PruebaDBEntities1())
                {
                    lista_parametros = DB.usp_Obtenerparametros(Nombre).ToList();
                }
                
            }
            catch (Exception ex)
            {
               
            }
            return lista_parametros;
        }
    }
}
