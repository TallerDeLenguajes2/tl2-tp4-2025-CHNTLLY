namespace EspacioCliente
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string datosReferenciaDireccion { get; set; }

        public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }
        public string obtenerDireccionCLiente()
        {
            return direccion;
        }
        public string obtenerRefCLiente()
        {
            return datosReferenciaDireccion;
        }
    }
}