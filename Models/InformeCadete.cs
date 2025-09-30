using System.Text.Json.Serialization;

namespace EspacioInformeCadete
{
    public class InformeCadete
    {
        public string NombreCadete { get; set;}
        public float Jornal { get; set;}
        public int Pedidos { get; set;}

        [JsonConstructor]
        public InformeCadete(string NombreCadete, float Jornal, int Pedidos)
        {
            this.NombreCadete = NombreCadete;
            this.Jornal = Jornal;
            this.Pedidos = Pedidos;
        }
    }
}