using EspacioCliente;
using EspacioCadete;
using System.Text.Json.Serialization;

namespace EspacioPedido
{
    public class Pedido
    {
        public int numero { get; set; }
        public string observacion { get; set; }
        public Cliente cliente { get; set; }
        public bool estado { get; set; }
        public Cadete cadete { get; set; }

        [JsonConstructor]
        public Pedido(int numero, string observacion, bool estado)
        {
            this.numero = numero;
            this.observacion = observacion;
            this.estado = estado;
            this.cliente = new Cliente("\0", "\0", "\0", "\0");
            this.cadete = new Cadete(-999, "\0", "\0", "\0");
        }
        // public Pedido(int numero, string observaciones, bool estado)
        // {
        //     this.numero = numero;
        //     this.observacion = observaciones;
        //     this.cliente = new Cliente("\0", "\0", "\0", "\0");
        //     this.estado = estado;
        //     this.cadete = new Cadete(-999, "\0", "\0", "\0");
        // }
        public Pedido(string nroPedido, string observaciones, string nombreClientePedido, string direccionClientePedido, string telefonoClientePedido, string datosRefPedido, int IdCadetePedido, string nombreCadetePedido, string direccionCadetePedido, string telefonoCadetePedido)
        {
            numero = int.Parse(nroPedido);
            observacion = observaciones;

            cliente.nombre = nombreClientePedido;
            cliente.direccion = direccionClientePedido;
            cliente.telefono = telefonoClientePedido;
            cliente.datosReferenciaDireccion = datosRefPedido;
            estado = false;

            cadete.Id = IdCadetePedido;
            cadete.Nombre = nombreCadetePedido;
            cadete.Direccion = direccionCadetePedido;
            cadete.Telefono = telefonoCadetePedido;
        }


        public string VerDireccionCliente()
        {
            return cliente.obtenerDireccionCLiente();
        }
        public string VerDatosCliente()
        {
            return cliente.obtenerRefCLiente();
        }
        public int ObtenerNro()
        {
            return numero;
        }
        public bool ObtenerEstado()
        {
            return estado;
        }
        public void ModificarEstado()
        {
            if (estado == false)
            {
                estado = true;
                //Console.WriteLine("Estado cambiado a: ENTREGADO");
            }
            else
            {
                estado = false;
                //Console.WriteLine("Estado cambiado a: NO ENTREGADO");
            }
        }
    }
}