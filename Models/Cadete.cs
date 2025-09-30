using System.Text.Json.Serialization;

namespace EspacioCadete
{
    public class Cadete
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        [JsonConstructor]
        public Cadete(int Id, string Nombre, string Direccion, string Telefono)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }
        // public Cadete() { }
        public int ObtenerIDCadete()
        {
            return Id;
        }
        public string ObtenerNombreCadete()
        {
            return Nombre;
        }
        public string ObtenerDireccionCadete()
        {
            return Direccion;
        }
        public string ObtenerTelefonoCadete()
        {
            return Telefono;
        }
    }
}