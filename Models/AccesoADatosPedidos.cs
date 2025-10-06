using System.Text.Json;
using EspacioPedido;
namespace EspacioAccesoADatosPedidos
{
    public class AccesoADatosPedidos()
    {
        public List<Pedido> Obtener(string nombre_archivo) //lee el Json y devuelve una lista con los pedidos
        {
            FileInfo info_json = new FileInfo(nombre_archivo);
            string ruta_json = info_json.FullName;
            string json_string = File.ReadAllText(ruta_json);

            List<Pedido> listadopedidos = new List<Pedido>();
            listadopedidos = JsonSerializer.Deserialize<List<Pedido>>(json_string) ?? new List<Pedido>();
            return (listadopedidos);
        }
        public void Guardar(List<Pedido> ListadoPedidos, string rutaJson) //lee la lista de los pedidos y la escribe en el Json
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(ListadoPedidos, options);
            File.WriteAllText(rutaJson, json);
        }
        public Pedido AddPedido(Pedido pedidoAgregar, string rutaJson) //combina los metodos anteriores: 
        {
            List<Pedido> pedidosJson = Obtener(rutaJson);          //crea una lista con los pedidos del Json
            pedidoAgregar.numero = pedidosJson.Any() ? pedidosJson.Max(p => p.numero) + 1 : 1;
            pedidosJson.Add(pedidoAgregar);                            //agrega el pedido dado
            Guardar(pedidosJson, rutaJson);                //actualiza el json sobreescribiendo el anterior
            return (pedidoAgregar);                                    //retorna el pedido agregado, solo por convencion, el metodo podria ser void
        }
        public Pedido? GetPedidoById(int IdPedido, string ruta_json)
        {
            return Obtener(ruta_json).FirstOrDefault(p => p.numero == IdPedido);
        }
    }
}