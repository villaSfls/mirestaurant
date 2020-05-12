namespace Restaurant.Modelos{
    public class Deta_Factura{
        public int Id_Factura { get; set; }
        public int Id_Categoria { get; set; }
        public int  Id_Producto { get; set; }
        public int Id_Personal { get; set; }
        public float Pre_Factura { get; set; }
        public float Can_Factura { get; set; }
        public string Nro_Mesa { get; set; }       
        }
   }