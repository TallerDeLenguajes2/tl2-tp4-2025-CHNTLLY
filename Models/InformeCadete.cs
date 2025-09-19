namespace EspacioInformeCadete
{
    public class InformeCadete
    {
        public string NombreCadete;
        public float Jornal;
        public int Pedidos;
        public InformeCadete(string nombreInsertar, float jornalInsertar, int pedidosInsertar)
        {
            this.NombreCadete = nombreInsertar;
            this.Jornal = jornalInsertar;
            this.Pedidos = pedidosInsertar;
        }
    }
}