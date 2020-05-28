namespace Parcial02.Modelo
{
    public class Usuario
    {
         public string iduser { get; set; }
         public string fullname { get; set; }
         public string username { get; set; }
         public string password { get; set; }
         public bool usertype { get; set; }
        
         public Usuario()
         { iduser= "";
           fullname = "";
           username = "";
           password = "";
           usertype = false;
                }
    }
}