using EspacioInformeCadete;
using System.Text.Json;
namespace EspacioAccesoADatosInformes
{
    public class AccesoADatosInformes()
    {
        public List<InformeCadete> Obtener(string nombre_archivo)
        {
            FileInfo info_json = new FileInfo(nombre_archivo);
            string ruta_json = info_json.FullName; //LEO EL PATH DEL JSON
            string json_string = File.ReadAllText(ruta_json);

            List<InformeCadete> listadoinformes = new List<InformeCadete>();
            listadoinformes = JsonSerializer.Deserialize<List<InformeCadete>>(json_string) ?? new List<InformeCadete>();
            return (listadoinformes);
        }
    }
}