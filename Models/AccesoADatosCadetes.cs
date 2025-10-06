using System.Text.Json;
using EspacioCadete;
namespace EspacioAccesoADatosCadetes
{
    public class AccesoADatosCadetes()
    {
        public List<Cadete> Obtener(string nombre_archivo)
        {
            FileInfo info_json = new FileInfo(nombre_archivo);
            string ruta_json = info_json.FullName; //LEO EL PATH DEL JSON
            string json_string = File.ReadAllText(ruta_json);

            List<Cadete> listadoCadetes = new List<Cadete>();
            listadoCadetes = JsonSerializer.Deserialize<List<Cadete>>(json_string) ?? new List<Cadete>();
            return (listadoCadetes);
        }
        public Cadete? GetCadeteById(int IdCadete,string ruta_json)
        {
            return Obtener(ruta_json).FirstOrDefault(c => c.Id == IdCadete);
        }
    }
}