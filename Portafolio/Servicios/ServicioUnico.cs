namespace Portafolio.Servicios
{

    //Esta clase sirvio para mostrar ejemplos de addTransit(), addScope() y addSingleton()
    //en program y ver sus diferencias con las peticiones https que se hagan
    public class ServicioDelimitado
    {
        public ServicioDelimitado()
        {
            obtenerGuid = Guid.NewGuid();
        }

        public Guid obtenerGuid { get; private set; }
    }

    public class ServicioUnico
    {
        public ServicioUnico()
        {
            obtenerGuid = Guid.NewGuid();
        }

        public Guid obtenerGuid { get; private set; }
    }

    public class ServicioTransitorio
    {
        public ServicioTransitorio()
        {
            obtenerGuid = Guid.NewGuid();
        }

        public Guid obtenerGuid { get; private set; }
    }
}
