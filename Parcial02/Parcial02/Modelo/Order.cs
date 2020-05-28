using System;
using System.Data;

namespace Parcial02.Modelo
{
    public class Order
    {
        public  string idorder { get; set; }
                 public DateTime createdate{ get; set; }
                 public string idproduct { get; set; }
                 public string idaddress{ get; set; }
        
                
                 public Order()
                 { idorder= "";
                   createdate = DateTime.Now;
                   idproduct = "";
                   idaddress= "";
                 
                        }
    }
}