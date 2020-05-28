using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial02.Modelo
{
    public class EnterpriseDAO
    {
        public static List<Enterprise> businesslist()
        {
            string sql = "select * from business";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Enterprise> lista = new List<Enterprise>();
            foreach (DataRow fila in dt.Rows)
            {
               Enterprise e = new Enterprise();

                e.idbusiness = fila[0].ToString();
                e.name = fila[1].ToString();
                e.description = fila[2].ToString();
                lista.Add(e); 
            }
            return lista;
        }

        public static void addbusiness(string name, string description)
        {
            string sql = String.Format(
                "INSERT INTO business(name,description) " +
                "values('{0}', '{1}');" ,
                name,description);
            
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminar(string idbusiness)
        {
            string sql = String.Format(
                "delete from business where idbusiness = '{0}';" ,
                idbusiness);
            
            Conexion.realizarAccion(sql);
        }
    }
}