using EspacioCadeteria;
using System.Text.Json;
namespace EspacioAccesoADatosCadeteria
{
    public class AccesoADatosCadeteria()
    {
        public Cadeteria Obtener(string nombre_archivo)
        {
            FileInfo info_json = new FileInfo(nombre_archivo);
            string ruta_json = info_json.FullName; //LEO EL PATH DEL JSON
            string json_string = File.ReadAllText(ruta_json);

            Cadeteria servicio_cadeteria = new Cadeteria();
            servicio_cadeteria = JsonSerializer.Deserialize<Cadeteria>(json_string) ?? new Cadeteria();
            return (servicio_cadeteria);
        }
    }
}