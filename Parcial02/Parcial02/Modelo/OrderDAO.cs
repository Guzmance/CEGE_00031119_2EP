using System;
using System.Collections.Generic;
using System.Data;

namespace Parcial02.Modelo
{
    public class OrderDAO
    {
        public static List<Order> orderlist()
        {
            string sql = "select * from apporder";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Order> lista = new List<Order>();
            foreach (DataRow fila in dt.Rows)
            {
                Order o = new Order();

                o.idorder = fila[0].ToString();
                o.createdate = Convert.ToDateTime(fila[1].ToString());
                o.idproduct = fila[2].ToString();
                o.idaddress =  fila[3].ToString();
                lista.Add(o); 
            }
            return lista;
        }
        
        public static List<Order> iduserorder(string idduser)
        {
            string sql = String.Format( 
                "SELECT ao.idorder, ao.createdate, pr.name, au.fullname, ad.address " +
            "FROM apporder ao, address ad, product pr, appuser au " +
                    $"WHERE ao.idproduct =pr.idproduct " +
              $"AND ao.idaddress =ad.idaddress " +
                $"AND ad.iduser =au.iduser " +
                $"AND au.iduser ='{0}';", idduser);
            
            DataTable dt = Conexion.realizarConsulta(sql);

            List<Order> ownlist = new List<Order>();
            foreach (DataRow fila in dt.Rows)
            {
                Order o = new Order();

                o.idorder = fila[0].ToString();
                o.idproduct = fila[1].ToString();
                o.idaddress =  fila[2].ToString();
                ownlist.Add(o); 
            }
            return ownlist;
        }

        public static void addorder(DateTime Fecha, string idproduct, string idaddress)
        {
            string sql = String.Format(
                "insert into apporder(createDate,idproduct,idaddress) " +
                "values('{0}','{1}','{2}');" ,
                Fecha,idproduct,idaddress);
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminar(string idorder)
        {
            string sql = String.Format(
                "DELETE FROM PRODUCT WHERE idproduct = '{0}'; " +
                "DELETE FROM ADDRESS WHERE idaddress = '{0}'; "+
                "DELETE FROM APPORDER WHERE idorder = '{0}';",
                idorder);
            
            Conexion.realizarAccion(sql);
        }
    }
}