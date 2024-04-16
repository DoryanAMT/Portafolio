  using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        //no se que hace
        private readonly ILogger<HomeController> _logger;
        //Esta clase Servicios/repositorioProyectos para para poder listarlos en la vista
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        //Viene por defecto se encarga de devolver la información minima necesaria a las vistas
        //En este pasando como parametros tanto el ILogger como nuestra interfaz de los proyectos para luego
        //listarlo en la vista con un for
        public HomeController(ILogger<HomeController> logger, 
            IRepositorioProyectos repositorioProyectos,
            IServicioEmail servicioEmail
            )
        { 
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }

        //Esta funcion se encarga de encapsular los proyectos para la vista index
        public IActionResult Index()
        {
            //Se guardan los proyectos de repositorioProyectos en una variable 
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
        
            //Creamos el objeto modelo que lleva dentro los proyectos
            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos 
            
            };
            //Devuelve a la vista el objeto modelo
            return View(modelo);
        }

        //Controlador de Proyectos
        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }
        //Controlador de Contacto

        public IActionResult Contacto()
        {
            
            return View();
        }

        //Esta accion dice que realmente estamos definiendo una peticion POST
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel) 
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }
        //Una vez haber finalizado correctamente el pequeño formulario redirigira
        //al usuario a otra página para evitar errores de envios doble de formulario
        public IActionResult Gracias() 
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        //Controlador de error
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
