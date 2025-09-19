namespace EspacioInformeCadeteria
{
    public class InformeGeneral
    {
        public int EnviosTotales {get; set;}
        public float GananciaTotal {get; set;}
        public float PromedioEnvios {get; set;}
        public InformeGeneral(int enviosIngresar, float gananciaIngresar, float promIngresar)
        {
            this.EnviosTotales = enviosIngresar;
            this.GananciaTotal = gananciaIngresar;
            this.PromedioEnvios = promIngresar;
        }
    }
}