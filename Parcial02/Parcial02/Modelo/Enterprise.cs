namespace Parcial02.Modelo
{
    public class Enterprise
    {
        public  string idbusiness { get; set; }
        public string name { get; set; }
        public string description { get; set; }
       
        
        public Enterprise()
        { idbusiness= "";
            name = "";
            description = "";
        }
    }
}