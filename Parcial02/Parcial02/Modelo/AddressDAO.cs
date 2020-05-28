using System;
using System.Collections.Generic;
using System.Data;
using Parcial02.Controlador;

namespace Parcial02.Modelo
{
    public class AddressDAO
    {
        public static List<Address> addresslist()
        {
            string sql = "select * from address";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Address> lista = new List<Address>();
            foreach (DataRow fila in dt.Rows)
            {
                Address a = new Address();

                a.idaddress = fila[0].ToString();
                a.iduser = fila[1].ToString();
                a.address = fila[2].ToString();

                lista.Add(a);
            }

            return lista;
        }

        public static void actualizaraddress(string idAddress, string address)
        {
            string sql = String.Format(
                "update address set address ='{0}' where idaddress ='{1}';",
                address, idAddress);

            Conexion.realizarAccion(sql);
        }

        public static void crearaddress(string iduser, string address)
        {
            string sql = String.Format(
                "insert into address(iduser,address) " +
                "values('{0}','{1}');",
                iduser, address);

            Conexion.realizarAccion(sql);
        }

        public static void eliminar(string idaddress)
        {
            string sql = String.Format(
                "delete from apporder where idaddress ='{0}'; " +
                "delete from address where idaddress ='{0}';",
                idaddress);

            Conexion.realizarAccion(sql);
        }

        public static List<Address> idaddresslist(string iduser)
                 {
            string sql = String.Format(
                "select ad.idaddress, ad.address FROM address ad WHERE iduser = '{0}';",
                iduser);

            DataTable dt = Conexion.realizarConsulta(sql);
            
            List<Address> listapropia = new List<Address>();
            foreach (DataRow fila in dt.Rows)
            {
                Address p = new Address();

                p.idaddress = fila[0].ToString();
                p.address = fila[1].ToString();

                listapropia.Add(p);
            }

            return listapropia;
        }
    }
}