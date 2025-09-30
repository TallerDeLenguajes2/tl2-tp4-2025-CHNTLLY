using EspacioCadete;
using EspacioPedido;
using EspacioInformeCadete;
using EspacioInformeCadeteria;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public List<Cadete> ListadoCadetes { get; set; } = new List<Cadete>();
        public List<Pedido> ListadoPedidos { get; set; } = new List<Pedido>();
        public List<InformeCadete> ListadoInforme {get; set;} = new List<InformeCadete>();
        public InformeGeneral InformeTotal {get; set;}

        public Cadeteria(string nombreInsertar, string telefonoInsertar)
        {
            this.Nombre = nombreInsertar;
            this.Telefono = telefonoInsertar;
        }
        public Cadeteria() { }

        public string ObtenerNombreCadeteria()
        {
            return Nombre;
        }
        public string ObtenerTelefonoCadeteria()
        {
            return Telefono;
        }

        // public void AgregarALista(Cadete agregar)
        // {
        //     ListadoCadetes.Add(agregar);
        // }
        public void AgregarALista(int ID_ingresar, string nombre_ingresar, string direccion_ingresar, string telefono_ingresar)
        {
            Cadete agregar = new Cadete(ID_ingresar, nombre_ingresar, direccion_ingresar, telefono_ingresar);
            ListadoCadetes.Add(agregar);
        }

        public float JornalACobrar(int IDcadete)
        {
            float retorno = 0;
            foreach (Pedido pedido in ListadoPedidos)
            {
                if (pedido.cadete.ObtenerIDCadete() == IDcadete && pedido.ObtenerEstado() == true)
                {
                    retorno += 500;
                }
            }
            return (retorno);
        }
        public void AsignarCadeteAPedido(int IDcadete, int NroPedido)
        {
            Cadete cadeteaux = null;
            foreach (Cadete cadete in ListadoCadetes)
            {
                if (cadete.ObtenerIDCadete() == IDcadete)
                {
                    cadeteaux = cadete;
                }
            }
            //bool pedidoEncontrado = false;
            if (cadeteaux != null)
            {
                foreach (Pedido pedido in ListadoPedidos)
                {
                    if (pedido.ObtenerNro() == NroPedido)
                    {
                        pedido.cadete = cadeteaux;
                        //pedidoEncontrado = true;
                    }
                }
            }
        }
        public int EnviosRealizados(int Idcadete)
        {
            int pedidos = 0;
            foreach (Pedido pedido in ListadoPedidos)
            {
                if (pedido.cadete.ObtenerIDCadete() == Idcadete)
                {
                    pedidos++;
                }
            }
            return (pedidos);
        }
        public InformeGeneral GenerarInforme()
        {
            int EnviosTotales = 0;
            float GananciaTotal = 0;
            float ContCadetes = 0;
            foreach (InformeCadete info in ListadoInforme)
            {
                EnviosTotales += info.Pedidos;
                GananciaTotal += info.Jornal;
                ContCadetes += 1;
            }
            InformeGeneral infoG = new InformeGeneral(EnviosTotales, GananciaTotal, EnviosTotales/ContCadetes);
            return(infoG);
        }
        public void GenerarInformeCadete(Cadete cadeteinforme)
        {
            float jornal = JornalACobrar(cadeteinforme.ObtenerIDCadete());
            string nombreAgregarLista = cadeteinforme.ObtenerNombreCadete();
            int enviosCadete = EnviosRealizados(cadeteinforme.ObtenerIDCadete());
            InformeCadete nuevo_informe = new InformeCadete(nombreAgregarLista,jornal,enviosCadete);
            ListadoInforme.Add(nuevo_informe);
        }
    }
}