////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////
/*Tecnicamente todos los metodos quedan viejos en AccesoADatosJSON*/
/*Y son reemplazados por sus equivalentes en AccesoADatosCadeteria,AccesoADatosCadetes,AccesoADatosInforme,AccesoADatosPedidos*/
////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////
using EspacioCadeteria;
using EspacioCadete;
using EspacioPedido;
using System.Text.Json.Nodes;
using System.Text.Json;
using EspacioInformeCadeteria;
using EspacioInformeCadete;
namespace AccesoADatos
{
    public interface IAccesoADatos
    {
        public Cadeteria LeerArchivo();
    }
    public class AccesoADatosJSON : IAccesoADatos
    {
        public List<Cadete> LeerCadetes(string nombre_archivo)
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
            return LeerCadetes(ruta_json).FirstOrDefault(c => c.Id == IdCadete);
        }
        public List<Pedido> LeerPedidos(string nombre_archivo) //lee el Json y devuelve una lista con los pedidos
        {
            FileInfo info_json = new FileInfo(nombre_archivo);
            string ruta_json = info_json.FullName;
            string json_string = File.ReadAllText(ruta_json);

            List<Pedido> listadopedidos = new List<Pedido>();
            listadopedidos = JsonSerializer.Deserialize<List<Pedido>>(json_string) ?? new List<Pedido>();
            return (listadopedidos);
        }
        public void escribirPedidosJSON(List<Pedido> ListadoPedidos,string rutaJson) //lee la lista de los pedidos y la escribe en el Json
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(ListadoPedidos, options);
            File.WriteAllText(rutaJson, json);
        }
        public Pedido AddPedido(Pedido pedidoAgregar, string rutaJson) //combina los metodos anteriores: 
        {                                                              
            List<Pedido> pedidosJson = LeerPedidos(rutaJson);          //crea una lista con los pedidos del Json
            pedidoAgregar.numero = pedidosJson.Any() ? pedidosJson.Max(p => p.numero) + 1 : 1;
            pedidosJson.Add(pedidoAgregar);                            //agrega el pedido dado
            escribirPedidosJSON(pedidosJson, rutaJson);                //actualiza el json sobreescribiendo el anterior
            return (pedidoAgregar);                                    //retorna el pedido agregado, solo por convencion, el metodo podria ser void
        }
        public Pedido? GetPedidoById(int IdPedido, string ruta_json)
        {
            return LeerPedidos(ruta_json).FirstOrDefault(p => p.numero == IdPedido);
        }
        public List<InformeCadete> LeerInformeCadetes(string nombre_archivo)
        {
            FileInfo info_json = new FileInfo(nombre_archivo);
            string ruta_json = info_json.FullName; //LEO EL PATH DEL JSON
            string json_string = File.ReadAllText(ruta_json);

            List<InformeCadete> listadoinformes = new List<InformeCadete>();
            listadoinformes = JsonSerializer.Deserialize<List<InformeCadete>>(json_string) ?? new List<InformeCadete>();
            return (listadoinformes);
        }
        public Cadeteria LeerCadeteria(string nombre_archivo)
        {
            FileInfo info_json = new FileInfo(nombre_archivo);
            string ruta_json = info_json.FullName; //LEO EL PATH DEL JSON
            string json_string = File.ReadAllText(ruta_json);

            Cadeteria servicio_cadeteria = new Cadeteria();
            servicio_cadeteria = JsonSerializer.Deserialize<Cadeteria>(json_string) ?? new Cadeteria();
            return (servicio_cadeteria);
        }
        public Cadeteria LeerArchivo() //metodo viejo, queda sin uso real
        {
            FileInfo info_json = new FileInfo("datosCadeteria.json");
            string ruta_json = info_json.FullName; //LEO EL PATH DEL JSON
            string json_string = File.ReadAllText(ruta_json);

            Cadeteria servicio_cadeteria = new Cadeteria();
            servicio_cadeteria = JsonSerializer.Deserialize<Cadeteria>(json_string) ?? new Cadeteria();

            info_json = new FileInfo("datosCadetes.json");
            ruta_json = info_json.FullName; //LEO EL PATH DEL JSON
            json_string = File.ReadAllText(ruta_json);

            List<Cadete> listadoCadetes = new List<Cadete>();
            listadoCadetes = JsonSerializer.Deserialize<List<Cadete>>(json_string) ?? new List<Cadete>();

            servicio_cadeteria.ListadoCadetes = listadoCadetes;

            return (servicio_cadeteria);
        }
    }
    public class AccesoADatosCSV : IAccesoADatos
    {
        public List<Cadete> LeerCadetes(string nombre_archivo)
        {
            FileInfo info_csv = new FileInfo(nombre_archivo);
            string ruta_csv = info_csv.FullName;
            StreamReader reader = new StreamReader(ruta_csv);
            string linea = reader.ReadLine() ?? "\0";
            string[] campos = linea.Split(';');
            List<Cadete> ListadoCadete = new List<Cadete>();

            while (linea != null)
            {
                Cadete cadete_nuevo = new Cadete(int.Parse(campos[0]), campos[1], campos[2], campos[3]);
                ListadoCadete.Add(cadete_nuevo);
                //servicio_cadeteria.AgregarALista(cadete_nuevo.ObtenerIDCadete(), cadete_nuevo.ObtenerNombreCadete(), cadete_nuevo.ObtenerDireccionCadete(), cadete_nuevo.ObtenerTelefonoCadete()); //ASIGNO A LA LISTA DE CADETES DE LA CADETERIA
                linea = reader.ReadLine() ?? "\0";
                if (linea != "\0")
                {
                    campos = linea.Split(';');
                }
            }
            reader.Close();
            return (ListadoCadete);
        }
        public Cadeteria LeerCadeteria(string nombre_archivo)
        {
            FileInfo info_csv = new FileInfo(nombre_archivo);
            string ruta_csv = info_csv.FullName; //LEO EL PATH DEL CSV

            StreamReader reader = new StreamReader(ruta_csv);
            string linea = reader.ReadLine() ?? "\0";
            string[] campos = linea.Split(';');

            Cadeteria servicio_cadeteria = new Cadeteria(campos[0], campos[1]);
            reader.Close();
            return (servicio_cadeteria);
        }
        public Cadeteria LeerArchivo() //metodo viejo, queda sin uso real
        {
            FileInfo info_csv = new FileInfo("datosCadeteria.csv");
            string ruta_csv = info_csv.FullName; //LEO EL PATH DEL CSV

            StreamReader reader = new StreamReader(ruta_csv); //CREO EL STRAMREADER DEL CSV
            string linea = reader.ReadLine() ?? "\0";
            string[] campos = linea.Split(';');

            Cadeteria servicio_cadeteria = new Cadeteria(campos[0], campos[1]); //ASIGNO LOS DATOS DE LA CADETERIA

            info_csv = new FileInfo("datosCadetes.csv");
            ruta_csv = info_csv.FullName;
            reader = new StreamReader(ruta_csv);
            linea = reader.ReadLine() ?? "\0"; //VUELVO A LEER PARA POSICIONARME EN EL PRIMER CADETE
            campos = linea.Split(';');

            while (linea != null) //LEO HASTA QUE LLEGUE AL FINAL DEL CSV
            {
                Cadete cadete_nuevo = new Cadete(int.Parse(campos[0]), campos[1], campos[2], campos[3]);
                servicio_cadeteria.AgregarALista(cadete_nuevo.ObtenerIDCadete(), cadete_nuevo.ObtenerNombreCadete(), cadete_nuevo.ObtenerDireccionCadete(), cadete_nuevo.ObtenerTelefonoCadete()); //ASIGNO A LA LISTA DE CADETES DE LA CADETERIA
                linea = reader.ReadLine() ?? "\0";
                if (linea != null)
                {
                    campos = linea.Split(';');
                }
            }
            reader.Close();
            return (servicio_cadeteria);
        }
    }
}