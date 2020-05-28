namespace Parcial02.Modelo
{
    public class Product
    {
        public  string idproduct { get; set; }
        public int idbusiness { get; set; }
        public string name { get; set; }
       
        
        public Product()
        { idproduct= "";
            idbusiness = 0;
            name = "";
        }
    }
}