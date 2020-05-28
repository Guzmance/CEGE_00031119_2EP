using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial02.Modelo
{
    public class ProductDAO
    {
        public static List<Product> productlist()
        {
            string sql = "select * from product";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Product> lista = new List<Product>();
            foreach (DataRow fila in dt.Rows)
            {
                Product p = new Product();

                p.idproduct = fila[0].ToString();
                p.idbusiness = Convert.ToInt32(fila[1].ToString());
                p.name = fila[2].ToString();
                lista.Add(p); 
            }
            return lista;
        }

        public static void addproduct(string idbusiness, string name)
        {
            string sql = String.Format(
                "INSERT INTO product(idbusiness,name) " +
                "values('{0}', '{1}');" ,
                idbusiness,name);
            
            Conexion.realizarAccion(sql);
        }
        
        public static void deleteproduct(string idproduct)
        {
            string sql = String.Format(
                "DELETE FROM APPORDER WHERE idproduct = '{0}'; " +
                "DELETE FROM PRODUCT WHERE idproduct = '{0}';",
                idproduct);
            
            Conexion.realizarAccion(sql);
        }
    }
}