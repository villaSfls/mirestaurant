namespace Restaurant.Modelos{
    public class Nro_Factura{
        public int Id_Factura { get; set; }
        public string Nro_Control { get; set; }
        public string Fec_Factura { get; set; }
        public string Nro_Mesa { get; set; }
        public string Fec_Mesa { get; set; }
        public int Id_Personal { get; set; }
        public float Por_Personal { get; set; }       
         public int Id_Cliente { get; set; }
         public float Iva { get; set; }
         public float Mon_Factura { get; set; }
         public string Cond_Pago { get; set; }
         public string Edo_Factura { get; set; }

         }
   }