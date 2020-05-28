using System;
using System.Collections.Generic;
using System.Data;
using Parcial02.Controlador;
using Parcial02.Vista;

namespace Parcial02.Modelo
{
    public class UsuarioDAO
    {
        
        public static List<Usuario> getLista()
        {
            string sql = "select * from appuser";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();

                u.iduser = fila[0].ToString();
                u.fullname = fila[1].ToString();
                u.username = fila[2].ToString();
                u.password = fila[3].ToString();
                u.usertype = Convert.ToBoolean(fila[4].ToString());

                lista.Add(u); 
            }
            return lista;
        }

        public static void actualizarContra(string iduser, string password)
        {
            string sql = String.Format(
                "update appuser set password ='{0}' where iduser ='{1}';",
              password, iduser);
                     
            Conexion.realizarAccion(sql);
        }

        public static void crearNuevo(string usuario)
        {
            
       
            string sql = String.Format(
                "insert into appuser(fullname,username,password,usertype) " +
                "values('{0}','{1}','{2}',false);" ,
                usuario,usuario, Encriptador.CrearMD5(usuario));
            
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminar(string iduser)
        {
            string sql = String.Format(
                "DELETE FROM ADDRESS WHERE idUser = '{0}'; " +
                "DELETE FROM APPUSER WHERE idUser = '{0}';",
                iduser);
            
            Conexion.realizarAccion(sql);
        }
    }
}