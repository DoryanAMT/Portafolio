using Portafolio.Models;

namespace Portafolio.Servicios
{
    
    //creamos una interfaz IRepositorioProyectos
    public interface IRepositorioProyectos
    {
        //Creamos un lista donde se almacenan todos los proyectos
        List<Proyecto> ObtenerProyectos();
    }

    //Esta clase sirve para almacenar los proyectos

    //Usamos la intefaz de IRepositorioProyectos para esta clase
    public class RepositorioProyectos: IRepositorioProyectos
    {
       //Creamos una lista para almacenar los proyectos y luego lo usamos en la interfaz
       //Es una lista de objetos
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() {
                new Proyecto
            {
                Titulo = "Amazon",
                Descripcion = "E-Commerce realizado en ASP.NET Core",
                Link = "https://amazon.com",
                ImagenURL = "/imagenes/amazon.png"
            },
                new Proyecto
            {
                Titulo = "New York Times",
                Descripcion = "Páginas de noticias en react",
                Link = "https://nytimes.com",
                ImagenURL = "/imagenes/nyt.png"
            },
                new Proyecto
            {
                Titulo = "Reddit",
                Descripcion = "Red social para compartir en comunidades",
                Link = "https://amazon.com",
                ImagenURL = "/imagenes/reddit.png"
            },
                new Proyecto
            {
                Titulo = "Steam",
                Descripcion = "Tienda en linea para comprar videojuegos",
                Link = "https://store.steampowered.com",
                ImagenURL = "/imagenes/steam.png"
            },
            };
        }
    }
}
